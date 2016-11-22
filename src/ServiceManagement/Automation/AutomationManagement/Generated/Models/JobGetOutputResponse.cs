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
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Management.Automation.Models
{
    /// <summary>
    /// The response model for the get job output operation.
    /// </summary>
    public partial class JobGetOutputResponse : AzureOperationResponse
    {
        private string _output;
        
        /// <summary>
        /// Optional. Gets or sets the output of the job.
        /// </summary>
        public string Output
        {
            get { return this._output; }
            set { this._output = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the JobGetOutputResponse class.
        /// </summary>
        public JobGetOutputResponse()
        {
        }
    }
}
