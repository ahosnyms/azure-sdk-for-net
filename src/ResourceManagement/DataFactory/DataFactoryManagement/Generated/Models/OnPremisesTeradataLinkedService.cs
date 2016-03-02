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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Linked Service for Teradata data source.
    /// </summary>
    public partial class OnPremisesTeradataLinkedService : LinkedServiceProperties
    {
        private string _authenticationType;
        
        /// <summary>
        /// Required. AuthenticationType to be used for connection.
        /// </summary>
        public string AuthenticationType
        {
            get { return this._authenticationType; }
            set { this._authenticationType = value; }
        }
        
        private string _database;
        
        /// <summary>
        /// Required. Database name for connection.
        /// </summary>
        public string Database
        {
            get { return this._database; }
            set { this._database = value; }
        }
        
        private string _encryptedCredential;
        
        /// <summary>
        /// Optional. The encryptedCredential for authentication.
        /// </summary>
        public string EncryptedCredential
        {
            get { return this._encryptedCredential; }
            set { this._encryptedCredential = value; }
        }
        
        private string _gatewayName;
        
        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        public string GatewayName
        {
            get { return this._gatewayName; }
            set { this._gatewayName = value; }
        }
        
        private string _password;
        
        /// <summary>
        /// Optional. Password for authentication.
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        
        private string _schema;
        
        /// <summary>
        /// Optional. Schema name for connection.
        /// </summary>
        public string Schema
        {
            get { return this._schema; }
            set { this._schema = value; }
        }
        
        private string _server;
        
        /// <summary>
        /// Required. Server name for connection.
        /// </summary>
        public string Server
        {
            get { return this._server; }
            set { this._server = value; }
        }
        
        private string _username;
        
        /// <summary>
        /// Optional. Username for authentication.
        /// </summary>
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the OnPremisesTeradataLinkedService
        /// class.
        /// </summary>
        public OnPremisesTeradataLinkedService()
        {
        }
    }
}
