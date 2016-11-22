// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
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
    /// AutoHealCustomAction - Describes the custom action to be executed
    /// when an auto heal rule is triggered.
    /// </summary>
    public partial class AutoHealCustomAction
    {
        /// <summary>
        /// Initializes a new instance of the AutoHealCustomAction class.
        /// </summary>
        public AutoHealCustomAction() { }

        /// <summary>
        /// Initializes a new instance of the AutoHealCustomAction class.
        /// </summary>
        public AutoHealCustomAction(string exe = default(string), string parameters = default(string))
        {
            Exe = exe;
            Parameters = parameters;
        }

        /// <summary>
        /// Executable to be run
        /// </summary>
        [JsonProperty(PropertyName = "exe")]
        public string Exe { get; set; }

        /// <summary>
        /// Parameters for the executable
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public string Parameters { get; set; }

    }
}
