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
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Management.StorSimple.Models
{
    /// <summary>
    /// The response model for the list of BackupSets.
    /// </summary>
    public partial class GetBackupResponse : AzureOperationResponse
    {
        private IList<Backup> _backupSetsList;
        
        /// <summary>
        /// Required. List of BackupSets to be returned
        /// </summary>
        public IList<Backup> BackupSetsList
        {
            get { return this._backupSetsList; }
            set { this._backupSetsList = value; }
        }
        
        private string _nextPageStartIdentifier;
        
        /// <summary>
        /// Required. Skip identifier to go to next page
        /// </summary>
        public string NextPageStartIdentifier
        {
            get { return this._nextPageStartIdentifier; }
            set { this._nextPageStartIdentifier = value; }
        }
        
        private Uri _nextPageUri;
        
        /// <summary>
        /// Required. Uri link to go to the next result page
        /// </summary>
        public Uri NextPageUri
        {
            get { return this._nextPageUri; }
            set { this._nextPageUri = value; }
        }
        
        private long _totalBackupCount;
        
        /// <summary>
        /// Required. Total number of Backupsets in the result
        /// </summary>
        public long TotalBackupCount
        {
            get { return this._totalBackupCount; }
            set { this._totalBackupCount = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the GetBackupResponse class.
        /// </summary>
        public GetBackupResponse()
        {
            this.BackupSetsList = new List<Backup>();
        }
    }
}
