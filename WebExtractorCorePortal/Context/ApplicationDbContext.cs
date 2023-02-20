using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        //USER
        public DbSet<UserDetails> CUserDetails { get; set; }


        //TEMPLATE
        public DbSet<AmendmentLoaded> TAmendmentLoadeds { get; set; }
        public DbSet<Source> TSource { get; set; }
        public DbSet<StartedWorkflow> TStartedWorkflows { get; set; }
        public DbSet<Workflow> TWorkflows { get; set; }
        public DbSet<Contract> TContracts { get; set; }
        public DbSet<AmendmentComparePointer> TAmendmentComparePointers { get; set; }
        public DbSet<Amendment> TAmendments { get; set; }
        public DbSet<RateCommodity> TRateCommodities { get; set; }
        public DbSet<RateCity> TRateCities { get; set; }
        public DbSet<RateHazGen> TRateHazGens { get; set; }
        public DbSet<RateScope> TRateScopes { get; set; }
        public DbSet<RateIndexed> TRateIndexeds { get; set; }
        public DbSet<RateBullet> TRateBullets { get; set; }
        public DbSet<Rate> TRates { get; set; }
        public DbSet<RateCityDirect> TRateCityDirects { get; set; }
        public DbSet<RateFreetimeDirect> TRateFreetimeDirects { get; set; }
        public DbSet<RateExceptionalNote> TExceptionalNotes { get; set; }
        public DbSet<RateGeneralNote> TRateGeneralNotes { get; set; }
        public DbSet<RateLineNote> TRateLineNotes { get; set; }
        public DbSet<RateNote> TRateNotes { get; set; }
        public DbSet<RateNoteIndexed> TRateNoteIndexeds { get; set; }
        public DbSet<RateBR> TRateBRs { get; set; }
        public DbSet<RateSurcharge> TRateSurcharges { get; set; }
        public DbSet<RateFreetime> TRateFreetimes { get; set; }
        public DbSet<RateValidationLog> TRateValidationLogs { get; set; }


        //CONTRACT LIBRARIES - AUTOMATE OVERRIDE

        public DbSet<LibCity> LibCities { get; set; }
        public DbSet<LibCityDetail> LibCityDetails { get; set; }
        public DbSet<LibCommodity> LibCommodities { get; set; }
        public DbSet<LibContainer> LibContainers { get; set; }

        //SYSTEM LIBRARIES

        public DbSet<SysCarrier> SysCarriers { get; set; }
        public DbSet<SysTradelane> SysTradelanes { get; set; }
        public DbSet<SysUnloc> SysUnlocs { get; set; }
        public DbSet<SysUnlocTrade> SysUnlocTrades { get; set; }
        public DbSet<SysHazTariff> SysHazTariffs { get; set; }
        public DbSet<SysSurchargeGRI> SysSurchargeGRIs { get; set; }
        public DbSet<SysSurchargeKeyword> SysSurchargeKeywords { get; set; }
        public DbSet<SysCondition> SysConditions { get; set; }
        public DbSet<SysCurrency> SysCurrencies { get; set; }
        public DbSet<SysColorSchemeColored> SysColorSchemeColoreds { get; set; }
        public DbSet<SysColorSchemeIndexed> SysColorSchemeIndexeds { get; set; }
        public DbSet<SysColorSchemeIndexedDetail> SysColorSchemeIndexedDetails { get; set; }
        public DbSet<SysColorSchemeDetail> SysColorSchemeDetails { get; set; } 



        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                  .ToTable("CUser");
            builder.Entity<IdentityRole>()
                   .ToTable("CRole");
            builder.Entity<IdentityUserRole<string>>()
                   .ToTable("CUserRole");
            builder.Entity<IdentityUserClaim<string>>()
                   .ToTable("CUserClaim");
            builder.Entity<IdentityUserLogin<string>>()
                   .ToTable("CUserLogin");
            builder.Entity<IdentityRoleClaim<string>>()
                   .ToTable("CRoleClaim");
            builder.Entity<IdentityUserToken<string>>()
                   .ToTable("CUserToken");


            builder
                .Entity<Amendment>()
                .Property(e => e.AmendmentType)
                .HasConversion(
                    v => v.ToString(),
                    v => (AmendmentType)Enum.Parse(typeof(AmendmentType), v));

            builder
                .Entity<Rate>()
                .Property(e => e.TabType)
                .HasConversion(
                    v => v.ToString(),
                    v => (TabType)Enum.Parse(typeof(TabType), v));

            builder
                .Entity<RateGeneralNote>()
                .Property(e => e.GeneralNoteType)
                .HasConversion(
                    v => v.ToString(),
                    v => (GeneralNoteType)Enum.Parse(typeof(GeneralNoteType), v));
            
            builder
                .Entity<RateCityDirect>()
                .Property(e => e.CityPoint)
                .HasConversion(
                    v => v.ToString(),
                    v => (CityPoint)Enum.Parse(typeof(CityPoint), v));

            builder
                .Entity<RateNoteIndexed>()
                .Property(e => e.RateNoteType)
                .HasConversion(
                    v => v.ToString(),
                    v => (RateNoteType)Enum.Parse(typeof(RateNoteType), v));

            builder
                .Entity<RateSurcharge>()
                .Property(e => e.SurchargeType)
                .HasConversion(
                    v => v.ToString(),
                    v => (SurchargeType)Enum.Parse(typeof(SurchargeType), v));

            builder
                .Entity<RateNoteIndexed>()
                .Property(e => e.TabType)
                .HasConversion(
                    v => v.ToString(),
                    v => (TabType)Enum.Parse(typeof(TabType), v));
        }


    }
}
