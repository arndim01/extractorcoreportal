using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtractorCorePortal.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }
            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
                public const string AdminAccess = "admin_access";
            }
        }
        public static class HttpRequestCode
        {
            public static class Error
            {
            }
        }
        public static class AngularOrigin
        {
            public const string HTTP = "http://localhost:4200";
        }
        public static Dictionary<string, string> GetExtensionIcon()
        {
            return new Dictionary<string, string>
            {
                {".xml", "xml-icon.png"}
            };
        }
        public static Dictionary<string, string> ContractType()
        {
            return new Dictionary<string, string>
            {
                {"CONV", "Conversion" },
                {"AMDT", "Amendment" }
            };
        }
        public static List<string> Construct()
        {
            return new List<string>
            {
                "O-D",
                "DO",
                "O",
                "D",
                "OCO",
                "DCO",
                "O-DCO",
                "OCO-D",
                "DCO-O",
                "ODO"
            };
        }
        public static List<string> RateService()
        {
            return new List<string>
            {
                "CY/CY",
                "CY/R",
                "CY/D",
                "R/CY",
                "D/CY",
                "R/R",
                "D/D",
                "FS/CFS",
                "R/D",
                "D/R"
            };
        }

        public static List<string> RateMode()
        {
            return new List<string>
            {
                "B/",
                "M/",
                "MB/",
                "R/",
                "RB/",
                "RM/",
                "/B",
                "/M",
                "/MB",
                "/R",
                "/RB",
                "/RM",
                "B/B",
                "B/M",
                "B/MB",
                "B/R",
                "B/RB",
                "B/RM",
                "M/B",
                "M/M",
                "M/MB",
                "M/R",
                "M/RB",
                "M/RM",
                "MB/B",
                "MB/M",
                "MB/MB",
                "MB/R",
                "MB/RB",
                "MB/RM",
                "R/B",
                "R/M",
                "R/MB",
                "R/R",
                "R/RB",
                "R/RM",
                "RB/B",
                "RB/M",
                "RB/MB",
                "RB/R",
                "RB/RB",
                "RB/RM",
                "RM/B",
                "RM/M",
                "RM/MB",
                "RM/R",
                "RM/RB",
                "RM/RM"
            };
        }
        public static List<string> ArbService()
        {
            return new List<string>
            {
                "CY",
                "R",
                "D",
                "CFS",
            };
        }
        public static List<string> ArbsMode()
        {
            return new List<string>
            {
                "B",
                "M",
                "MB",
                "R",
                "RB",
                "RM"
            };
        }
        public static List<string> Basis()
        {
            return new List<string>
            {
                "PC",
                "EA",
                "PS"
            };
        }
        public static List<string> ContainerType()
        {
            return new List<string>
            {
                "DC",
                "RE",
                "TK",
                "OT",
                "FR",
                "NOR",
                "GC",
                "PL",
                "TR",
                "OXX"
            };
        }
        public static List<string> Currency()
        {
            return new List<string>
            {
                "AFN",
                "ALL",
                "DZD",
                "AOA",
                "ARS",
                "AMD",
                "AWG",
                "AUD",
                "AZN",
                "BSD",
                "BHD",
                "BDT",
                "BBD",
                "BYR",
                "BZD",
                "BMD",
                "BTN",
                "BOB",
                "BAM",
                "BWP",
                "BRL",
                "BND",
                "BGN",
                "BIF",
                "KHR",
                "CAD",
                "CVE",
                "KYD",
                "CLP",
                "CNY",
                "COP",
                "XOF",
                "XAF",
                "KMF",
                "XPF",
                "CDF",
                "CRC",
                "HRK",
                "CUC",
                "CUP",
                "CYP",
                "CZK",
                "DKK",
                "DJF",
                "DOP",
                "XCD",
                "EGP",
                "SVC",
                "ERN",
                "EEK",
                "ETB",
                "EUR",
                "FKP",
                "FJD",
                "GMD",
                "GEL",
                "GHS",
                "GIP",
                "XAU",
                "GTQ",
                "GGP",
                "GNF",
                "GYD",
                "HTG",
                "HNL",
                "HKD",
                "HUF",
                "ISK",
                "INR",
                "IDR",
                "XDR",
                "IRR",
                "IQD",
                "IMP",
                "ILS",
                "JMD",
                "JPY",
                "JEP",
                "JOD",
                "KZT",
                "KES",
                "KWD",
                "KGS",
                "LAK",
                "LVL",
                "LBP",
                "LSL",
                "LRD",
                "LYD",
                "LTL",
                "MOP",
                "MKD",
                "MGA",
                "MWK",
                "MYR",
                "MVR",
                "MTL",
                "MRO",
                "MUR",
                "MXN",
                "MDL",
                "MNT",
                "MAD",
                "MZN",
                "MMK",
                "NAD",
                "NPR",
                "ANG",
                "NZD",
                "NIO",
                "NGN",
                "KPW",
                "NOK",
                "OMR",
                "PKR",
                "XPD",
                "PAB",
                "PGK",
                "PYG",
                "PEN",
                "PHP",
                "XPT",
                "PLN",
                "QAR",
                "RON",
                "RUB",
                "RWF",
                "SHP",
                "WST",
                "SAR",
                "SPL",
                "RSD",
                "SCR",
                "SLL",
                "XAG",
                "SGD",
                "SKK",
                "SBD",
                "SOS",
                "ZAR",
                "KRW",
                "LKR",
                "SDD",
                "SDG",
                "SRD",
                "SZL",
                "SEK",
                "CHF",
                "SYP",
                "TWD",
                "TJS",
                "TZS",
                "THB",
                "TOP",
                "TTD",
                "TND",
                "TRY",
                "TMM",
                "TVD",
                "UGX",
                "UAH",
                "AED",
                "GBP",
                "USD",
                "UYU",
                "UZS",
                "VUV",
                "VEB",
                "VND",
                "YER",
                "ZMK",
                "ZWD",
            };
        }

    }
}
