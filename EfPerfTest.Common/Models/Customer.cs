using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Common.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CustomerNumber { get; set; } = string.Empty;
        public IList<Account> Accounts { get; set; } = new List<Account>();

        public override string ToString() => $"{Id}:{Name}:{Birthday?.ToShortDateString()??string.Empty}";
    }
}
