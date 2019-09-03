using System;
using System.Collections.Generic;

namespace WebTool.Models.DataBreach
{
    public class BreachResults
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Domain { get; set; }

        public DateTimeOffset BreachDate { get; set; }

        public DateTimeOffset AddedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public long PwnCount { get; set; }

        public string Description { get; set; }

        public string LogoPath { get; set; }

        public List<DataType> DataClasses { get; set; }

        public string IsVerified { get; set; }

        public string IsFabricated { get; set; }

        public string IsSensitive { get; set; }

        public string IsRetired { get; set; }

        public string IsSpamList { get; set; }
    }
}
