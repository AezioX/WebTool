using System;
using System.Collections.Generic;

namespace WebTool.Models.DomainDatabase
{
    public class DomainsData
    {
        public string Domain { get; set; } = "";
        public DateTime? Expiry_date { get; set; } = new DateTime?();
        public DateTime? Create_date { get; set; } = new DateTime?();
        public DateTime? Update_date { get; set; } = new DateTime?();
        public bool IsDead { get; set; } = false;
        public List<string> NameServers { get; set; } = new List<string>();
    }
}
