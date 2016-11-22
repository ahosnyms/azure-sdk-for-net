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
using Microsoft.Azure.Management.ApiManagement.Models;

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    /// <summary>
    /// Custom hostname configuration.
    /// </summary>
    public partial class HostnameConfiguration
    {
        private CertificateInformation _certificate;
        
        /// <summary>
        /// Required. Gets or sets certificate information.
        /// </summary>
        public CertificateInformation Certificate
        {
            get { return this._certificate; }
            set { this._certificate = value; }
        }
        
        private string _hostname;
        
        /// <summary>
        /// Required. Gets or sets hostname.
        /// </summary>
        public string Hostname
        {
            get { return this._hostname; }
            set { this._hostname = value; }
        }
        
        private HostnameType _type;
        
        /// <summary>
        /// Required. Gets or sets hostname type.
        /// </summary>
        public HostnameType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the HostnameConfiguration class.
        /// </summary>
        public HostnameConfiguration()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the HostnameConfiguration class with
        /// required arguments.
        /// </summary>
        public HostnameConfiguration(HostnameType type, string hostname, CertificateInformation certificate)
            : this()
        {
            if (hostname == null)
            {
                throw new ArgumentNullException("hostname");
            }
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }
            this.Type = type;
            this.Hostname = hostname;
            this.Certificate = certificate;
        }
    }
}
