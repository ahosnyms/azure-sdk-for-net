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
using System.Linq;

namespace Microsoft.WindowsAzure.Management.SiteRecovery.Models
{
    /// <summary>
    /// The definition of a recovery plan unplanned failover request object.
    /// </summary>
    public partial class RpUnplannedFailoverRequest
    {
        private string _failoverDirection;
        
        /// <summary>
        /// Optional. Failover direction.
        /// </summary>
        public string FailoverDirection
        {
            get { return this._failoverDirection; }
            set { this._failoverDirection = value; }
        }
        
        private bool _primaryAction;
        
        /// <summary>
        /// Required. Value indicating whether primary site actions are
        /// required or not.
        /// </summary>
        public bool PrimaryAction
        {
            get { return this._primaryAction; }
            set { this._primaryAction = value; }
        }
        
        private string _replicationProvider;
        
        /// <summary>
        /// Optional. Replication provider name.
        /// </summary>
        public string ReplicationProvider
        {
            get { return this._replicationProvider; }
            set { this._replicationProvider = value; }
        }
        
        private string _replicationProviderSettings;
        
        /// <summary>
        /// Optional. Replication provider settings.
        /// </summary>
        public string ReplicationProviderSettings
        {
            get { return this._replicationProviderSettings; }
            set { this._replicationProviderSettings = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RpUnplannedFailoverRequest class.
        /// </summary>
        public RpUnplannedFailoverRequest()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the RpUnplannedFailoverRequest class
        /// with required arguments.
        /// </summary>
        public RpUnplannedFailoverRequest(bool primaryAction)
            : this()
        {
            this.PrimaryAction = primaryAction;
        }
    }
}
