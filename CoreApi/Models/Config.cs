using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class LogLevel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Default { get; set; }
    }

    public class Logging
    {
        /// <summary>
        /// 
        /// </summary>
        public LogLevel LogLevel { get; set; }
    }

    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public Logging Logging { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AllowedHosts { get; set; }
    }
}
