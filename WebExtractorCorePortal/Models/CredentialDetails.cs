using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using WebExtractorCorePortal.Models.Validations;

namespace WebExtractorCorePortal.Models
{
    [Validator(typeof(CredentialDetailsValidator))]
    public class CredentialDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
