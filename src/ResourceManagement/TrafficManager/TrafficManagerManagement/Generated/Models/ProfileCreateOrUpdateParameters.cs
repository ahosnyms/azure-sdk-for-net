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
using Microsoft.Azure.Management.TrafficManager.Models;

namespace Microsoft.Azure.Management.TrafficManager.Models
{
    /// <summary>
    /// Parameters supplied to create or update a Profile.
    /// </summary>
    public partial class ProfileCreateOrUpdateParameters
    {
        private Profile _profile;
        
        /// <summary>
        /// Required. Gets or sets information about the Profile being created
        /// or updated.
        /// </summary>
        public Profile Profile
        {
            get { return this._profile; }
            set { this._profile = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ProfileCreateOrUpdateParameters
        /// class.
        /// </summary>
        public ProfileCreateOrUpdateParameters()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ProfileCreateOrUpdateParameters
        /// class with required arguments.
        /// </summary>
        public ProfileCreateOrUpdateParameters(Profile profile)
            : this()
        {
            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }
            this.Profile = profile;
        }
    }
}
