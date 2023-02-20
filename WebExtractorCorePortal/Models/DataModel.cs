using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Attributes;

namespace WebExtractorCorePortal.Models
{
    

    public class ContractIssues
    {
        public bool ErrorFound { get; set; }
        public int TotalErrorFound { get; set; }
    }

    public class CommodityDetails
    {
        public string Id { get; set; }
        public string HashValue { get; set; }
        public string MainValue { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Bdescription { get; set; }
        public string Exclusions { get; set; }
        public string Nac { get; set; }
    }
    public class CityDetails
    {
        public string Id { get; set; }
        public string HashValue { get; set; }
        public string MainValue { get; set; }
        public List<UnlocDetails> UnlocDetails { get; set; } = new List<UnlocDetails>();
    }
    public class UnlocDetails
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Uncode { get; set; }
        public string Export { get; set; }
        public string Import { get; set; }
    }
    public class RatesDetails
    {
        public string Id { get; set; }
        public string Scope { get; set; }
        public string Commodity { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Service { get; set; }
    }
    #region Notes
    public class RateNotes
    {
        public string MainValue { get; set; }
        public string HashValue { get; set; }
        public List<ColorScheme> ColorSchemes { set; get; } = new List<ColorScheme>();
        public long GNotesId { get; set; }
        public SpecialNotes ResultValue { get; set; } = new SpecialNotes();
    }
    public class LineNotes
    {
        public string MainValue { get; set; }
        public string HashValue { get; set; }
        public long RNotesId { get; set; }
        public List<ColorScheme> ColorSchemes { get; set; } = new List<ColorScheme>();
        public int NumberNotes { get; set; }
        public SpecialNotes ResultValue { get; set; } = new SpecialNotes();
    }
    public class ColorScheme
    {
        public string Color { get; set; }
        public string Value { get; set; }
    }
    public class SpecialNotes
    {
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string ContractNotes { get; set; }
        public string CommodityAddtl { get; set; }
        public List<SurchargeOv> SurchargeOvs { get; set; } = new List<SurchargeOv>();
        public string ArbsConst { get; set; }
        public string Service { get; set; }
    }
    public class SurchargeOv
    {
        public string Code { get; set; }
        public bool Included { get; set; }
    }
    public class NotesIndexed
    {
        public string HashValue { get; set; }
        public string NumberNotes { get; set; }
        public RateNoteType RateNoteType { get; set; }
        public SpecialNotes ResultValue { get; set; } = new SpecialNotes();
    }
    #endregion
    
    public class ContractAssign
    {
        public long Carrier { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string ContractId { get; set; }
        public string AmendmentId { get; set; }
        public AmendmentType AmendmentType { get; set; }
        public string FileName { get; set; }
    }
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class FileDetails
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeImagePath { get; set; }
        public long Size { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserInfo CreatedBy { get; set; }
        public string Started { get; set; }
    }

    public class ContractFileDetails
    {
        public string CarrierLogo { get; set; }
        public string CarrierName { get; set; }
        public string ContractId { get; set; }
        public string AmendmentId { get; set; }
        public string ContractType { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserInfo CreatedBy { get; set; }
        public long StartedId { get; set; }
        public bool Started { get; set; }
    }
    
    public class WorkflowDetails
    {
        public string CarrierLogo { get; set; }
        public string CarrierName { get; set; }
        public string ContractId { get; set; }
        public string AmendmentId { get; set; }
        public string ContractType { get; set; }
        public DateTime Started { get; set; }
        public UserInfo ClaimedBy { get; set; }
        public DateTime? ClaimedDate { get; set; }
        public long StartedId { get; set; }
    }
}
