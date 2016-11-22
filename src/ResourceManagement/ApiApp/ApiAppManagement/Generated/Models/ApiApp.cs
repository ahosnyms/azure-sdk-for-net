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
using Microsoft.Azure.Management.ApiApps.Models;

namespace Microsoft.Azure.Management.ApiApps.Models
{
    public partial class ApiApp
    {
        private string _accessLevel;
        
        /// <summary>
        /// Optional. Gets or sets access level
        /// </summary>
        public string AccessLevel
        {
            get { return this._accessLevel; }
            set { this._accessLevel = value; }
        }
        
        private MicroserviceApi _api;
        
        /// <summary>
        /// Optional. Gets or sets api
        /// </summary>
        public MicroserviceApi Api
        {
            get { return this._api; }
            set { this._api = value; }
        }
        
        private MicroserviceAuthentication _authentication;
        
        /// <summary>
        /// Optional. Gets or sets authentication
        /// </summary>
        public MicroserviceAuthentication Authentication
        {
            get { return this._authentication; }
            set { this._authentication = value; }
        }
        
        private IList<string> _dependencies;
        
        /// <summary>
        /// Optional. Gets or sets dependencies
        /// </summary>
        public IList<string> Dependencies
        {
            get { return this._dependencies; }
            set { this._dependencies = value; }
        }
        
        private ResourceReference _gateway;
        
        /// <summary>
        /// Optional. Gets or sets gateway
        /// </summary>
        public ResourceReference Gateway
        {
            get { return this._gateway; }
            set { this._gateway = value; }
        }
        
        private ResourceReference _host;
        
        /// <summary>
        /// Optional. Gets or sets host
        /// </summary>
        public ResourceReference Host
        {
            get { return this._host; }
            set { this._host = value; }
        }
        
        private string _id;
        
        /// <summary>
        /// Optional. Gets or sets id
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _location;
        
        /// <summary>
        /// Optional. Gets or sets location
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. Gets or sets name
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private MicroservicePackage _package;
        
        /// <summary>
        /// Optional. Gets or sets package
        /// </summary>
        public MicroservicePackage Package
        {
            get { return this._package; }
            set { this._package = value; }
        }
        
        private IList<StatusCheckEntry> _status;
        
        /// <summary>
        /// Optional. Gets or sets status
        /// </summary>
        public IList<StatusCheckEntry> Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private IDictionary<string, string> _tags;
        
        /// <summary>
        /// Optional. Gets or sets tags
        /// </summary>
        public IDictionary<string, string> Tags
        {
            get { return this._tags; }
            set { this._tags = value; }
        }
        
        private string _updatePolicy;
        
        /// <summary>
        /// Optional. Gets or sets update policy
        /// </summary>
        public string UpdatePolicy
        {
            get { return this._updatePolicy; }
            set { this._updatePolicy = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ApiApp class.
        /// </summary>
        public ApiApp()
        {
            this.Dependencies = new LazyList<string>();
            this.Status = new LazyList<StatusCheckEntry>();
            this.Tags = new LazyDictionary<string, string>();
        }
    }
}
