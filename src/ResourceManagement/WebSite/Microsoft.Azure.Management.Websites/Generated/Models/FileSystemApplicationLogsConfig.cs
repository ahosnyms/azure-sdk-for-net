// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Application logs to file system configuration
    /// </summary>
    public partial class FileSystemApplicationLogsConfig
    {
        /// <summary>
        /// Initializes a new instance of the FileSystemApplicationLogsConfig
        /// class.
        /// </summary>
        public FileSystemApplicationLogsConfig() { }

        /// <summary>
        /// Initializes a new instance of the FileSystemApplicationLogsConfig
        /// class.
        /// </summary>
        public FileSystemApplicationLogsConfig(LogLevel? level = default(LogLevel?))
        {
            Level = level;
        }

        /// <summary>
        /// Log level. Possible values for this property include: 'Off',
        /// 'Verbose', 'Information', 'Warning', 'Error'.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public LogLevel? Level { get; set; }

    }
}
