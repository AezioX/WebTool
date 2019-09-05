using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebTool.Models.DomainDatabase
{
    public class JsonDomainsData
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("domains")]
        public List<Domain> Domains { get; set; }

        public class Domain
        {
            [JsonProperty("domain")]
            public string DomainDomain { get; set; }

            [JsonProperty("expiry_date")]
            public DateTime? ExpiryDate { get; set; }

            [JsonProperty("create_date")]
            public DateTime? CreateDate { get; set; }

            [JsonProperty("update_date")]
            public DateTime? UpdateDate { get; set; }

            [JsonProperty("isDead")]
            public bool IsDead { get; set; }

            [JsonProperty("A")]
            public List<string> A { get; set; }

            [JsonProperty("TXT")]
            public List<string> Txt { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("NS", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Ns { get; set; }

            [JsonProperty("resolvable")]
            public bool Resolvable { get; set; }

            [JsonProperty("CNAME")]
            public object Cname { get; set; }

            [JsonProperty("MX")]
            public List<Mx> Mx { get; set; }

            [JsonProperty("robots_txt")]
            public object RobotsTxt { get; set; }

            [JsonProperty("parser", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Parser { get; set; }

            [JsonProperty("parser_error")]
            public object ParserError { get; set; }

            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Url { get; set; }

            [JsonProperty("apps")]
            public object Apps { get; set; }
        }

        public class Mx
        {
            [JsonProperty("exchange")]
            public string Exchange { get; set; }

            [JsonProperty("priority")]
            public long Priority { get; set; }
        }
    }
}
