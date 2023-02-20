using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ONEConverter.Models
{

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
