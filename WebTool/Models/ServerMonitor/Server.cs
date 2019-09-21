using System;
using System.Collections.Generic;

namespace WebTool.Models.ServerMonitor
{
    public class Server
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string HostName { get; set; } = "";
        public string Status { get; set; } = "";
        public List<string> Logs { get; set; } = new List<string>();
    }
}
