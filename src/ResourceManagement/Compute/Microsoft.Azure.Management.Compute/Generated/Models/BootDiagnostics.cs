// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Models
{
    using System.Linq;

    /// <summary>
    /// Describes Boot Diagnostics.
    /// </summary>
    public partial class BootDiagnostics
    {
        /// <summary>
        /// Initializes a new instance of the BootDiagnostics class.
        /// </summary>
        public BootDiagnostics() { }

        /// <summary>
        /// Initializes a new instance of the BootDiagnostics class.
        /// </summary>
        /// <param name="enabled">whether boot diagnostics should be enabled
        /// on the Virtual Machine.</param>
        /// <param name="storageUri">the boot diagnostics storage Uri. It
        /// should be a valid Uri</param>
        public BootDiagnostics(bool? enabled = default(bool?), string storageUri = default(string))
        {
            Enabled = enabled;
            StorageUri = storageUri;
        }

        /// <summary>
        /// Gets or sets whether boot diagnostics should be enabled on the
        /// Virtual Machine.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the boot diagnostics storage Uri. It should be a
        /// valid Uri
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "storageUri")]
        public string StorageUri { get; set; }

    }
}
