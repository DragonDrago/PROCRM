using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace ProCrm.Ldi.Api.Domain
{
    public class LdiDomain
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string AttachedTo { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string EmailAddress { get; set; }
        public string MailAddress { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Comments { get; set; }
    }
}
