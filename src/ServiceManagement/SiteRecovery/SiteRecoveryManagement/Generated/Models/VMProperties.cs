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
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.WindowsAzure.Management.SiteRecovery.Models
{
    /// <summary>
    /// The definition of a Update VM properties input object.
    /// </summary>
    public partial class VMProperties
    {
        private string _recoveryAzureVMName;
        
        /// <summary>
        /// Optional. Recovery Azure VM given name
        /// </summary>
        public string RecoveryAzureVMName
        {
            get { return this._recoveryAzureVMName; }
            set { this._recoveryAzureVMName = value; }
        }
        
        private string _recoveryAzureVMSize;
        
        /// <summary>
        /// Optional. Recovery Azure VM size
        /// </summary>
        public string RecoveryAzureVMSize
        {
            get { return this._recoveryAzureVMSize; }
            set { this._recoveryAzureVMSize = value; }
        }
        
        private string _selectedRecoveryAzureNetworkId;
        
        /// <summary>
        /// Optional. Selected Primary NIC Id
        /// </summary>
        public string SelectedRecoveryAzureNetworkId
        {
            get { return this._selectedRecoveryAzureNetworkId; }
            set { this._selectedRecoveryAzureNetworkId = value; }
        }
        
        private IList<VMNicDetails> _vMNics;
        
        /// <summary>
        /// Optional. Recovery Azure Network Id
        /// </summary>
        public IList<VMNicDetails> VMNics
        {
            get { return this._vMNics; }
            set { this._vMNics = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the VMProperties class.
        /// </summary>
        public VMProperties()
        {
            this.VMNics = new LazyList<VMNicDetails>();
        }
    }
}
