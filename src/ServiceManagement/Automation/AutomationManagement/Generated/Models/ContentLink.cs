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
using Microsoft.WindowsAzure.Management.Automation.Models;

namespace Microsoft.WindowsAzure.Management.Automation.Models
{
    /// <summary>
    /// Definition of the content link.
    /// </summary>
    public partial class ContentLink
    {
        private ContentHash _contentHash;
        
        /// <summary>
        /// Optional. Gets or sets the hash.
        /// </summary>
        public ContentHash ContentHash
        {
            get { return this._contentHash; }
            set { this._contentHash = value; }
        }
        
        private Uri _uri;
        
        /// <summary>
        /// Optional. Gets or sets the uri of the runbook content.
        /// </summary>
        public Uri Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }
        
        private string _version;
        
        /// <summary>
        /// Optional. Gets or sets the version of the content.
        /// </summary>
        public string Version
        {
            get { return this._version; }
            set { this._version = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ContentLink class.
        /// </summary>
        public ContentLink()
        {
        }
    }
}
