using System;
using System.Collections.Generic;

namespace WebTool.Models.ServerMonitor
{
    public class Servers
    {
        public List<Server> MonitoredServers { get; set; } = new List<Server>();
    }
}
