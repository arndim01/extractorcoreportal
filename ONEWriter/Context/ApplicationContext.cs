using Microsoft.EntityFrameworkCore;
using ONEWriter.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONEWriter.Context
{
    public class ApplicationContext : DbContext
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=CAT-PROD-04\\SQLEXPRESS;Database=ExtractorDatabase_Debug;MultipleActiveResultSets=True;Integrated Security=True;");
        }
    }
}
