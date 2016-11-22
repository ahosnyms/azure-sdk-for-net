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

namespace Microsoft.Azure.Management.Dns.Models
{
    public partial class RecordSetListParameters
    {
        private string _filter;
        
        /// <summary>
        /// Optional. Gets or sets the filter for the records enumeration.
        /// </summary>
        public string Filter
        {
            get { return this._filter; }
            set { this._filter = value; }
        }
        
        private string _top;
        
        /// <summary>
        /// Optional. Gets or sets the number of elements to retrieve (first N
        /// elements).
        /// </summary>
        public string Top
        {
            get { return this._top; }
            set { this._top = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RecordSetListParameters class.
        /// </summary>
        public RecordSetListParameters()
        {
        }
    }
}
