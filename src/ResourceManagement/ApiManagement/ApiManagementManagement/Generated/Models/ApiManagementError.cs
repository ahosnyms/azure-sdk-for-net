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

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    /// <summary>
    /// Description of a standard Api Management service response error.
    /// </summary>
    public partial class ApiManagementError
    {
        private string _code;
        
        /// <summary>
        /// Required. Gets or sets the error code returned from the server.
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        
        private IDictionary<string, string> _details;
        
        /// <summary>
        /// Optional. Gets or sets the error detais.
        /// </summary>
        public IDictionary<string, string> Details
        {
            get { return this._details; }
            set { this._details = value; }
        }
        
        private string _message;
        
        /// <summary>
        /// Required. Gets or sets the error message returned from the server.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ApiManagementError class.
        /// </summary>
        public ApiManagementError()
        {
            this.Details = new LazyDictionary<string, string>();
        }
        
        /// <summary>
        /// Initializes a new instance of the ApiManagementError class with
        /// required arguments.
        /// </summary>
        public ApiManagementError(string code, string message)
            : this()
        {
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            this.Code = code;
            this.Message = message;
        }
    }
}
