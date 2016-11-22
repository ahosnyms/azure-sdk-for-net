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

namespace Microsoft.WindowsAzure.Management.StorSimple.Models
{
    /// <summary>
    /// Device time settings
    /// </summary>
    public partial class TimeSettings
    {
        private string _primary;
        
        /// <summary>
        /// Required. Gets or sets the primary time server
        /// </summary>
        public string Primary
        {
            get { return this._primary; }
            set { this._primary = value; }
        }
        
        private IList<string> _secondary;
        
        /// <summary>
        /// Optional. Gets or sets the secondary time server.
        /// </summary>
        public IList<string> Secondary
        {
            get { return this._secondary; }
            set { this._secondary = value; }
        }
        
        private string _timeZone;
        
        /// <summary>
        /// Required. Gets or sets the time zone
        /// </summary>
        public string TimeZone
        {
            get { return this._timeZone; }
            set { this._timeZone = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the TimeSettings class.
        /// </summary>
        public TimeSettings()
        {
            this.Secondary = new List<string>();
        }
        
        /// <summary>
        /// Initializes a new instance of the TimeSettings class with required
        /// arguments.
        /// </summary>
        public TimeSettings(string primary, string timeZone)
            : this()
        {
            if (primary == null)
            {
                throw new ArgumentNullException("primary");
            }
            if (timeZone == null)
            {
                throw new ArgumentNullException("timeZone");
            }
            this.Primary = primary;
            this.TimeZone = timeZone;
        }
    }
}
