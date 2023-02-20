using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtractorCorePortal.Models
{

    public class UserDetails
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
    }

    public class Source
    {
        public long Id { get; set; }
        [StringLength(250)]
        [Required]
        public string SourceName { get; set; }
        [StringLength(500)]
        [Required]
        public string SourcePath { get; set; }
        public long Size { get; set; }
        [StringLength(20)]
        public string SourceType { get; set; }
        public DateTime Created { get; set; }
        public string CreatorRefId { get; set; }
        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }
    }
    public class StartedWorkflow
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public long AmendmendId { get; set; }
        [ForeignKey("AmendmendId")]
        public virtual Amendment Amendment { get; set; }
        [DefaultValue(false)]
        public bool Activate { get; set; }
        public string CreatorRefId { get; set; }
        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }

    }
    public class Workflow
    {
        public long Id { get; set; }
        public DateTime ClaimedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string UClaimedRefId { get; set; }
        public string UCompletedRefId { get; set; }
        public long SWorkflowRefId { get; set; }
        [DefaultValue(false)]
        public bool Completed { get; set; }
        [ForeignKey("UClaimedRefId")]
        public virtual ApplicationUser Claimed { get; set; }
        [ForeignKey("UCompletedRefId")]
        public virtual ApplicationUser Released { get; set; }
        [ForeignKey("SWorkflowRefId")]
        public virtual StartedWorkflow SWorkflow { get; set; }
        public Workflow()
        {
            ClaimedDate = DateTime.Now;
            CompletedDate = DateTime.Now;
        }
    }

    public class Contract
    {
        public long Id { get; set; }
        [Required]
        public string ContractId { get; set; }
        public DateTime Created { get; set; }

        //FILE SYSTEM INFO
        [StringLength(128)]
        public string DirectoryName { get; set; } //HASH
        [StringLength(250)]
        public string WorkflowPath { get; set; }
        [Required]


        public string CreatorRefId { get; set; }
        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }
        //CONTRACT INFO
        public long CarrierRefId { get; set; }
        [ForeignKey("CarrierRefId")]
        public virtual SysCarrier Carrier { get; set; }

        [ForeignKey("ContractRefId")]
        public ICollection<Amendment> Amendments { get; set; }
        public Contract()
        {
            Created = DateTime.Now;
        }
    }

    public class AmendmentComparePointer
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? ReferenceId { get; set; }
        public long? CurrentId { get; set; }

        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
        [ForeignKey("ReferenceId")]
        public virtual Amendment AmendmentRef { get; set; }
        [ForeignKey("CurrentId")]
        public virtual Amendment AmendmentCur { get; set; }

    }
    public class AmendmentLoaded
    {
        public long Id { get; set; }
        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
        [DefaultValue(false)]
        public bool CommodityLoaded { get; set; }
    }
    public class Amendment
    {
        public long Id { get; set; }
        public string HashId { get; set; }
        public long SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual Source Source { get; set; }
        [StringLength(200)]
        [Required]
        public string AmendmentId { get; set; }
        [StringLength(250)]
        public string WorkflowPath { get; set; } //JSON DATA
        public AmendmentType AmendmentType { get; set; } //CONV OR AMDT
        [StringLength(10)]
        [Required]
        public string ContractEff { get; set; }
        [StringLength(10)]
        [Required]
        public string ContractExp { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ContractRefId { get; set; }

        public Amendment()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public enum AmendmentType
    {
        CONV,
        AMDT
    }

    public class RateIndexed
    {
        public long Id { get; set; }
        public long? AmendmentRefId { get; set; }
        public long? RateRefId { get; set; }
        public long GroutId { get; set; }
        public long TableId { get; set; }
        [ForeignKey("RateRefId")]
        public virtual Rate Rate { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
    }

    public class RateCommodity
    {
        public long Id { get; set; }
        [Required]
        [StringLength(128)]
        public string GenId { get; set; }
        [Required]
        public string Main_value { get; set; }
        [StringLength(128)]
        [Required]
        public string Main_value_hash { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        public string Brief_description { get; set; }
        public string Nac { get; set; }
        public string Exclusion { get; set; }
        [DefaultValue(false)]
        public bool Confirmation { get; set; }
        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }

        //[ForeignKey("RatelineValidationRefId")]
        //public virtual ICollection<RateValidationLog> RateValidations { get; set; }
    }
    public class RateCity
    {
        public long Id { get; set; }
        [Required]
        [StringLength(128)]
        public string GenId { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(128)]
        [Required]
        public string HashName { get; set; }

        public long? CityRefId { get; set; }

        [DefaultValue(false)]
        public bool Confirmation { get; set; }
        [ForeignKey("CityRefId")]
        public virtual LibCity CityLib { get; set; }

        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
    }

    public class RateHazGen
    {
        public long Id { get; set; }
        public long? HazRef { get; set; }
        [StringLength(5)]
        [Required]
        public string TabType { get; set; }
        [StringLength(250)]
        public string HazCode { get; set; }
        public string HazDescription { get; set; }
        public byte HazType { get; set; }
        [StringLength(20)]
        public string HazNote { get; set; }
        [StringLength(5)]
        [Required]
        public string ShipSize { get; set; }
        [StringLength(5)]
        [Required]
        public string ShipType { get; set; }
        [StringLength(5)]
        [Required]
        public string RateBasis { get; set; }

        public long? CurrencyRefId { get; set; }
        [ForeignKey("CurrencyRefId")]
        public virtual SysCurrency Currency { get; set; }

        [StringLength(10)]
        [Required]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        [Required]
        public string ExpirationDate { get; set; }
        [StringLength(4)]
        [Required]
        public string Mode { get; set; }
        [Required]
        public string Header { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }


    }

    public class RateScope
    {
        public long Id { get; set; }
        [Required]
        public string TradeName { get; set; }
        [DefaultValue(false)]
        public bool IsMarked { get; set; }
    }

    public class RateCityDirect
    {
        public long Id { get; set; }
        public CityPoint CityPoint { get; set; }
        public long CityId { get; set; }
        public long? CityRefId { get; set; }
        [ForeignKey("CityRefId")]
        public virtual RateCity RateCity { get; set; }
    }

    public enum CityPoint
    {
        ORIG,
        ORIG_VIA,
        DEST,
        DEST_VIA
    }

    public class RateFreetimeDirect
    {
        public long Id { get; set; }
        public string Point { get; set; }
        public long FreetimeId { get; set; }

        public long? FreetimeRefId { get; set; }
        [ForeignKey("FreetimeRefId")]
        public virtual RateFreetime RateFreetime { get; set; }
    }
    public class RateBullet
    {
        public long Id { get; set; }
        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
        [Required]
        [StringLength(100)]
        public string BulletValue { get; set; }
        public long GroupId { get; set; }
    }
    public class Rate
    {
        public long Id { get; set; }
        [StringLength(128)]
        public string GenId { get; set; }
        [Required]
        [StringLength(10)]
        public string EffectiveDate { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpirationDate { get; set; }
        [StringLength(128)]
        public string CommodityHash { get; set; }

        [StringLength(10)]
        [Required]
        public TabType TabType { get; set; }
        
        [StringLength(128)]
        public string OriginValue { get; set; }
        [StringLength(128)]
        public string OriginViaValue { get; set; }
        [StringLength(128)]
        public string DestinationValue { get; set; }
        [StringLength(128)]
        public string DestinationViaValue { get; set; }
        
        [StringLength(5)]
        public string ArbsConst { get; set; }

        public long RateNoteRefId { get; set; }
        [ForeignKey("RateNoteRefId")]
        public virtual RateNote RateNote { get; set; }

        public long RateTrade { get; set; }
        [ForeignKey("RateTrade")]
        public virtual RateScope RateScope { get; set; }
        
        [ForeignKey("BRRefId")]
        public virtual ICollection<RateBR> BaseRates { get; set; }

        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }

        public long GroupId { get; set; }
        public long TableId { get; set; }
        [StringLength(5)]
        [Required]
        public string MarkedType { get; set; }

    }
    public enum TabType
    {
        RATES,
        OARBS,
        DARBS
    }

    public class RateNote
    {
        public long Id { get; set; }
        [StringLength(20)]
        public string ExportService { get; set; }
        [StringLength(20)]
        public string ImportService { get; set; }
        [StringLength(20)]
        public string ExportMode { get; set; }
        [StringLength(20)]
        public string ImportMode { get; set; }

        public string AnalystNotes { get; set; }
        public string ContractNotes { get; set; }
        public string DataEntryNotes { get; set; }
        [StringLength(4)]
        [Required]
        public string RateType { get; set; }
    }

    public class RateBR
    {
        public long Id { get; set; }
        public long? BRRefId { get; set; }
        [StringLength(5)]
        [Required]
        public string CodeType { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerSize { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerType { get; set; }
        [StringLength(5)]
        [Required]
        public string Currency { get; set; }
        [StringLength(5)]
        [Required]
        public string RateBasis { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }
        [StringLength(100)]
        public string Header { get; set; }
    }

    public class RateValidationLog
    {
        public long Id { get; set; }
        public long? RatelineValidationRefId { get; set; }
        [StringLength(50)]
        [Required]
        public string ValidationType { get; set; }
        [Required]
        public string ValidationMsg { get; set; }
        [DefaultValue(false)]
        public bool Resolve { get; set; }

    }


    public class RateGeneralNote
    {
        public long Id { get; set; }
        public long RateGeneralNoteRefId { get; set; }
        [StringLength(128)]
        public GeneralNoteType GeneralNoteType { get; set; }
        public string HashValue { get; set; }
        public string MainValue { get; set; }
        public long? Exceptional { get; set; }
        [ForeignKey("Exceptional")]
        public virtual RateExceptionalNote ExceptionalNote { get; set; }

    }
    public enum GeneralNoteType
    {
        COMM,
        SCOP,
        ALL
    }
    public class RateLineNote
    {
        public long Id { get; set; }
        public long RateLineNoteRefId { get; set; }
        [StringLength(128)]
        public string HashValue { get; set; }
        public string MainValue { get; set; }
        public string SpecificValue { get; set; }
        public long? Exceptional { get; set; }
        [ForeignKey("Exceptional")]
        public virtual RateExceptionalNote ExceptionalNote { get; set; }

    }

   
   

    public class RateSurcharge
    {
        public long Id { get; set; }
        public long? SurchargeRefId { get; set; }
        [StringLength(30)]
        [Required]
        public string Code { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerSize { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerType { get; set; }
        [StringLength(5)]
        [Required]
        public string RateBasis { get; set; }
        public long CurrencyRefId { get; set; }
        [ForeignKey("CurrencyRefId")]
        public virtual SysCurrency Currency { get; set; }
        [StringLength(10)]
        [Required]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        [Required]
        public string ExpirationDate { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }
        [StringLength(250)]
        [Required]
        public string Header { get; set; }
        [StringLength(4)]
        [Required]
        public string CodeType { get; set; }
        public SurchargeType SurchargeType { get; set; }
    }
    public enum SurchargeType
    {
        Included,
        Subject,
        Fixed
    }

    public class RateFreetime
    {
        public long Id { get; set; }
        [StringLength(100)]
        [Required]
        public string FreeCode { get; set; }
        [StringLength(30)]
        [Required]
        public string Type { get; set; }
        public int MinDay { get; set; }
        public int MaxDay { get; set; }
        [StringLength(10)]
        [Required]
        public string Price { get; set; }
        public long CurrencyRefId { get; set; }
        [ForeignKey("CurrencyRefId")]
        public virtual SysCurrency Currency { get; set; }
        [StringLength(10)]
        [Required]
        public string Unit { get; set; }
        [StringLength(10)]
        [Required]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        [Required]
        public string ExpirationDate { get; set; }
        public string Notes { get; set; }
        public long GVersion { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
        [ForeignKey("ConditionRefId")]
        public virtual ICollection<SysCondition> Condition { get; set; }
    }


    public class RateNoteIndexed
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long TableId { get; set; }
        public string MainValue { get; set; }
        public string HashValue { get; set; }
        public string NumberNotes { get; set; }
        public RateNoteType RateNoteType { get; set; }
        [StringLength(10)]
        [Required]
        public TabType TabType { get; set; }
        public long AmendmentRefId { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
    }
    public enum RateNoteType
    {
        General,
        Specific
    }

    public class RateExceptionalNote
    {
        public long Id { get; set; }
        [StringLength(10)]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        public string ExpirationDate { get; set; }
        [StringLength(5)]
        public string ArbsConstruction { get; set; }
        public string Notes { get; set; }
        [StringLength(5)]
        public string Services { get; set; }
        public string AdditionalCommodity { get; set; }
        [ForeignKey("SurchargeRefId")]
        public virtual ICollection<RateSurcharge> Surcharges { get; set; }
    }

    //LIBRARY VALUE
    public class LibCity
    {
        public long Id { get; set; }
        [StringLength(128)]
        [Required]
        public string Name_hash { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string CreatorRefId { get; set; }
        public long? AmendmentRefId { get; set; }
        public long? CarrierRefId { get; set; }

        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }
        [ForeignKey("AmendmentRefId")]
        public virtual Amendment Amendment { get; set; }
        [ForeignKey("CarrierRefId")]
        public virtual SysCarrier SysCarrier { get; set; }
        [ForeignKey("CityDetailRefId")]
        public virtual ICollection<LibCityDetail> Cities { get; set; }
    }

    public class LibCityDetail
    {
        public long Id { get; set; }
        public long? CityDetailRefId { get; set; }
        [DefaultValue(false)]
        public bool Approved { get; set; }
        public DateTime Created { get; set; }
        public string CreatorRefId { get; set; }
        public long? UnlocRefId { get; set; }
        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }
        [ForeignKey("UnlocRefId")]
        public virtual SysUnloc Unloc { get; set; }
    }

    public class LibCommodity
    {
        public long Id { get; set; }
        [Required]
        public string Main_value { get; set; }
        [Required]
        public string Main_hash_value { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        public string Exclusions { get; set; }
        public string Nac { get; set; }
        [DefaultValue(false)]
        public bool Approved { get; set; }
        public DateTime Created { get; set; }
        public string CreatorRefId { get; set; }
        public long ContractRefId { get; set; }

        [ForeignKey("CreatorRefId")]
        public virtual ApplicationUser Creator { get; set; }
        [ForeignKey("ContractRefId")]
        public virtual Contract Contract { get; set; }
    }

    public class LibContainer
    {
        public long Id { get; set; }
        [StringLength(100)]
        [Required]
        public string ContainerKeyword { get; set; }
        [StringLength(100)]
        public string ContainerDirectKeyWord { get; set; }
        [StringLength(200)]
        [Required]
        public string KeyWordMeaning { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }
        public long CarrierRefId { get; set; }
        [ForeignKey("CarrierRefId")]
        public virtual SysCarrier SysCarrier { get; set; }
    }

    //SYSTEM VALUE
    public class SysClient
    {
        public long Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Code { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }

    public class SysCarrier
    {
        public long Id { get; set; }
        [StringLength(100)]
        [Required]
        public string CarrierName { get; set; }
        [StringLength(500)]
        [Required]
        public string CarrierDescription { get; set; }
        [StringLength(10)]
        [Required]
        public string CarrierCode { get; set; }
        [StringLength(250)]
        [Required]
        public string CarrierDirPath { get; set; }
        //[StringLength(250)]
        //[Required]
        //public string CarrierLogoPath { get; set; } ----> REMOVE COMMENT AFTER 
    }
    public class SysTradelane
    {
        public long Id { get; set; }
        [StringLength(20)]
        [Required]
        public string TradelaneCode { get; set; }
    }
    public class SysUnloc
    {
        public long Id { get; set; }
        [StringLength(10)]
        public string Iso { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [StringLength(50)]
        public string State_code { get; set; }
        [StringLength(50)]
        [Required]
        public string Full_code { get; set; }
        [DefaultValue(false)]
        public bool Port { get; set; }
    }
    public class SysUnlocTrade
    {
        public long Id { get; set; }
        [StringLength(50)]
        public string Export_code { get; set; }
        [StringLength(50)]
        public string Import_code { get; set; }

        public long UnlocRefId { get; set; }

        [ForeignKey("UnlocRefId")]
        public virtual SysUnloc Unloc { get; set; }
    }
    public class SysHazTariff
    {
        public long Id { get; set; }
        public long CarrierRefId { get; set; }
        [ForeignKey("CarrierRefId")]
        public virtual SysCarrier Carrier { get; set; }
        [StringLength(30)]
        [Required]
        public string Scope { get; set; }
        [StringLength(30)]
        [Required]
        public string Trade { get; set; }
        [StringLength(4)]
        [Required]
        public string Mode { get; set; }
        [StringLength(5)]
        [Required]
        public string ShipSize { get; set; }
        [StringLength(5)]
        [Required]
        public string ShipType { get; set; }
        [StringLength(5)]
        [Required]
        public string RateBasis { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }
        [StringLength(10)]
        [Required]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        [Required]
        public string ExpirationDate { get; set; }
        public long CurrencyRefId { get; set; }
        [ForeignKey("CurrencyRefId")]
        public virtual SysCurrency Currency { get; set; }
        [ForeignKey("ConditionRefId")]
        public virtual ICollection<SysCondition> Condition { get; set; }

    }
    public class SysSurchargeGRI
    {
        public long Id { get; set; }
        public long CarrierRefId { get; set; }
        [ForeignKey("CarrierRefId")]
        public virtual SysCarrier Carrier { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerSize { get; set; }
        [StringLength(5)]
        [Required]
        public string ContainerType { get; set; }
        [StringLength(5)]
        [Required]
        public string RateBasis { get; set; }

        public long CurrencyRefId { get; set; }
        [ForeignKey("CurrencyRefId")]
        public virtual SysCurrency Currency { get; set; }
        [StringLength(10)]
        [Required]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        [Required]
        public string ExpirationDate { get; set; }
        [StringLength(10)]
        [Required]
        public string Value { get; set; }
        public bool Active { get; set; }

        [ForeignKey("ConditionRefId")]
        public virtual ICollection<SysCondition> Condition { get; set; }
    }
    public class SysSurchargeKeyword
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Code { get; set; }

    }

    public class SysCondition
    {
        public long Id { get; set; }
        public long? ConditionRefId { get; set; }
        [StringLength(10)]
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
        [StringLength(3)] //SPE (Specific) OR EXC (Exception)
        [Required]
        public string Apply { get; set; }
    }
    public class SysCurrency
    {
        public long Id { get; set; }
        [StringLength(5)]
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class SysColorSchemeIndexed
    {
        public long Id { get; set; }
        public int Indexed { get; set; }
        [StringLength(10)]
        [Required]
        public string HtmlColor { get; set; }
        [StringLength(50)]
        [Required]
        public string ColorName { get; set; }
        [DefaultValue(false)]
        public bool Prio { get; set; }

    }
    public class SysColorSchemeIndexedDetail
    {
        public long Id { get; set; }
        public long SysColorRefId { get; set; }
        public string DataType { get; set; }
        public long SysCarrierRefId { get; set; }
    }
    public class SysColorSchemeColored
    {
        public long Id { get; set; }
        [StringLength(10)]
        [Required]
        public string HtmlColor { get; set; }
        [StringLength(50)]
        [Required]
        public string ColorName { get; set; }
        [DefaultValue(false)]
        public bool IsKnown { get; set; }
        [DefaultValue(false)]
        public bool Prio { get; set; }
    }

    public class SysColorSchemeDetail
    {
        public long Id { get; set; }
        public long SysColorRefId { get; set; }
        public string DataType { get; set; }
        public long SysCarrierRefId { get; set; }
    }
}
