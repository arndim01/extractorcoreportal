using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WebExtractorCorePortal.Auth;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Helpers;
using WebExtractorCorePortal.Models;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using WebExtractorCorePortal.Extentions;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Repositories;
using WebExtractorCorePortal.Services;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;

namespace WebExtractorCorePortal
{
    public class Startup
    {

        private const string SecretKey = "1iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)); 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("ExtractorConnection"), 
                b => b.MigrationsAssembly("WebExtractorCorePortal"))
                );

            services.AddIdentity<ApplicationUser, IdentityRole>();

            //REPOSITORIES
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IFileRepo, FileRepo>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<ICarrierRepo, CarrierRepo>();
            services.AddScoped<IAmendmentRepo, AmendmentRepo>();
            services.AddScoped<IWorkflowRepo, WorkflowRepo>();
            services.AddScoped<ISurchargeRepo, SurchargeRepo>();
            services.AddScoped<IExtractorRepo, ExtractorRepo>();
            //services.AddScoped<ICommodityRepo, CommodityRepo>();
            //services.AddTransient<ICommodityService, CommodityService>();

            services.AddTransient<IJwtFactory, JwtFactory>();

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            var builder = services.AddIdentityCore<ApplicationUser>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAutoMapper();
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}
            

            app.UseExceptionHandler(
                 builder =>
                 {
                     builder.Run(
                                async context =>
                             {
                                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                 context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                 var error = context.Features.Get<IExceptionHandlerFeature>();
                                 if (error != null)
                                 {
                                     context.Response.AddApplicationError(error.Error.Message);
                                     await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                 }
                             });
                 });


            //app.UseHttpsRedirection();

            // ALLOWING THE ANGULAR TO ACCESS THE WEB API
            app.UseCors(options =>
            options.WithOrigins("*")
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .AllowAnyOrigin()
                                   .AllowCredentials());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
