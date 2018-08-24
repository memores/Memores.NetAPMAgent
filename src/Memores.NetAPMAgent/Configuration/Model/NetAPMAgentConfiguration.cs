﻿using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Contracts;


namespace Memores.NetAPMAgent.Configuration.Model {
    public class NetApmAgentConfiguration {
        public Service Service { get; set; }

        public SystemInfo SystemInfo { get; set; }
        
        public Process Process { get; set; }
    }
}