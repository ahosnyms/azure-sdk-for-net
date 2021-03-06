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

namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    /// <summary>
    /// Description of a NotificationHub MpnsCredential.
    /// </summary>
    public partial class MpnsCredentialProperties
    {
        private string _certificateKey;
        
        /// <summary>
        /// Optional. Gets or sets the certificate key for this credential.
        /// </summary>
        public string CertificateKey
        {
            get { return this._certificateKey; }
            set { this._certificateKey = value; }
        }
        
        private string _mpnsCertificate;
        
        /// <summary>
        /// Optional. Gets or sets the MPNS certificate.
        /// </summary>
        public string MpnsCertificate
        {
            get { return this._mpnsCertificate; }
            set { this._mpnsCertificate = value; }
        }
        
        private string _thumbprint;
        
        /// <summary>
        /// Optional. Gets or sets the Mpns certificate Thumbprint
        /// </summary>
        public string Thumbprint
        {
            get { return this._thumbprint; }
            set { this._thumbprint = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MpnsCredentialProperties class.
        /// </summary>
        public MpnsCredentialProperties()
        {
        }
    }
}
