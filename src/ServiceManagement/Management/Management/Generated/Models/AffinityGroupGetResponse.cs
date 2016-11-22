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
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure.Management.Models
{
    /// <summary>
    /// The Get Affinity Group operation response.
    /// </summary>
    public partial class AffinityGroupGetResponse : AzureOperationResponse
    {
        private IList<string> _capabilities;
        
        /// <summary>
        /// Optional. Indicates if the virtual machine-related operations can
        /// be performed in this affinity group. If so, the string
        /// PersistentVMRole will be returned by this element. Otherwise, this
        /// element will not be present.
        /// </summary>
        public IList<string> Capabilities
        {
            get { return this._capabilities; }
            set { this._capabilities = value; }
        }
        
        private ComputeCapabilities _computeCapabilities;
        
        /// <summary>
        /// Optional. The compute capabilities in this affinity group.
        /// </summary>
        public ComputeCapabilities ComputeCapabilities
        {
            get { return this._computeCapabilities; }
            set { this._computeCapabilities = value; }
        }
        
        private System.DateTime? _createdTime;
        
        /// <summary>
        /// Optional. The time that the affinity group was created.
        /// </summary>
        public System.DateTime? CreatedTime
        {
            get { return this._createdTime; }
            set { this._createdTime = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional. The user-supplied description for this affinity group.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private IList<AffinityGroupGetResponse.HostedServiceReference> _hostedServices;
        
        /// <summary>
        /// Optional. The hosted services associated with this affinity group.
        /// </summary>
        public IList<AffinityGroupGetResponse.HostedServiceReference> HostedServices
        {
            get { return this._hostedServices; }
            set { this._hostedServices = value; }
        }
        
        private string _label;
        
        /// <summary>
        /// Optional. The user-supplied label for the affinity group, returned
        /// as a base-64-encoded string.
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        
        private string _location;
        
        /// <summary>
        /// Optional. The location of the data center that the affinity group
        /// is associated with.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. The user-supplied name for the affinity group.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private IList<AffinityGroupGetResponse.StorageServiceReference> _storageServices;
        
        /// <summary>
        /// Optional. The storage services associated with this affinity group.
        /// </summary>
        public IList<AffinityGroupGetResponse.StorageServiceReference> StorageServices
        {
            get { return this._storageServices; }
            set { this._storageServices = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the AffinityGroupGetResponse class.
        /// </summary>
        public AffinityGroupGetResponse()
        {
            this.Capabilities = new LazyList<string>();
            this.HostedServices = new LazyList<AffinityGroupGetResponse.HostedServiceReference>();
            this.StorageServices = new LazyList<AffinityGroupGetResponse.StorageServiceReference>();
        }
        
        /// <summary>
        /// Reference to a hosted service associated with an affinity group.
        /// </summary>
        public partial class HostedServiceReference
        {
            private string _serviceName;
            
            /// <summary>
            /// Optional. The name of the hosted service.
            /// </summary>
            public string ServiceName
            {
                get { return this._serviceName; }
                set { this._serviceName = value; }
            }
            
            private Uri _uri;
            
            /// <summary>
            /// Optional. The Service Management API request URI used to
            /// perform Get Hosted Service Properties requests against the
            /// hosted service.
            /// </summary>
            public Uri Uri
            {
                get { return this._uri; }
                set { this._uri = value; }
            }
            
            /// <summary>
            /// Initializes a new instance of the HostedServiceReference class.
            /// </summary>
            public HostedServiceReference()
            {
            }
        }
        
        /// <summary>
        /// Reference to a storage service associated with an affinity group.
        /// </summary>
        public partial class StorageServiceReference
        {
            private string _serviceName;
            
            /// <summary>
            /// Optional. The user supplied name of the storage account.
            /// </summary>
            public string ServiceName
            {
                get { return this._serviceName; }
                set { this._serviceName = value; }
            }
            
            private Uri _uri;
            
            /// <summary>
            /// Optional. The Service Management API request URI used to
            /// perform Get Storage Account Properties requests against the
            /// storage account.
            /// </summary>
            public Uri Uri
            {
                get { return this._uri; }
                set { this._uri = value; }
            }
            
            /// <summary>
            /// Initializes a new instance of the StorageServiceReference class.
            /// </summary>
            public StorageServiceReference()
            {
            }
        }
    }
}
