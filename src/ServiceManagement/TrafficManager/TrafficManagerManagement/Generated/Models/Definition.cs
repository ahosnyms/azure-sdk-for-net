// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Management.TrafficManager.Models
{
    /// <summary>
    /// Describes a definition.
    /// </summary>
    public partial class Definition
    {
        private DefinitionDnsOptions _dnsOptions;
        
        /// <summary>
        /// Optional. The DNS related option.
        /// </summary>
        public DefinitionDnsOptions DnsOptions
        {
            get { return this._dnsOptions; }
            set { this._dnsOptions = value; }
        }
        
        private IList<DefinitionMonitor> _monitors;
        
        /// <summary>
        /// Optional. The list of Endpoint monitoring configurations.
        /// </summary>
        public IList<DefinitionMonitor> Monitors
        {
            get { return this._monitors; }
            set { this._monitors = value; }
        }
        
        private DefinitionPolicyResponse _policy;
        
        /// <summary>
        /// Optional. The Endpoint monitoring policy.
        /// </summary>
        public DefinitionPolicyResponse Policy
        {
            get { return this._policy; }
            set { this._policy = value; }
        }
        
        private ProfileDefinitionStatus _status;
        
        /// <summary>
        /// Optional. Indicates whether this definition is enabled or disabled
        /// for the profile.
        /// </summary>
        public ProfileDefinitionStatus Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private int _version;
        
        /// <summary>
        /// Optional. Indicates the version of the definition returned. This
        /// value is always 1.
        /// </summary>
        public int Version
        {
            get { return this._version; }
            set { this._version = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Definition class.
        /// </summary>
        public Definition()
        {
            this.Monitors = new LazyList<DefinitionMonitor>();
        }
    }
}
