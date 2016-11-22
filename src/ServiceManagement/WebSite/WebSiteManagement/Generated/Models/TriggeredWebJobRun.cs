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

namespace Microsoft.WindowsAzure.WebSitesExtensions.Models
{
    /// <summary>
    /// Triggered WebJob run.
    /// </summary>
    public partial class TriggeredWebJobRun
    {
        private TimeSpan _duration;
        
        /// <summary>
        /// Optional. The duration.
        /// </summary>
        public TimeSpan Duration
        {
            get { return this._duration; }
            set { this._duration = value; }
        }
        
        private DateTime _endTime;
        
        /// <summary>
        /// Optional. The end time.
        /// </summary>
        public DateTime EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }
        
        private string _id;
        
        /// <summary>
        /// Optional. The identifier.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _jobName;
        
        /// <summary>
        /// Optional. The WebJob name.
        /// </summary>
        public string JobName
        {
            get { return this._jobName; }
            set { this._jobName = value; }
        }
        
        private Uri _outputUrl;
        
        /// <summary>
        /// Optional. The url to get the WebJob run log.
        /// </summary>
        public Uri OutputUrl
        {
            get { return this._outputUrl; }
            set { this._outputUrl = value; }
        }
        
        private DateTime _startTime;
        
        /// <summary>
        /// Optional. The start time.
        /// </summary>
        public DateTime StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }
        
        private string _status;
        
        /// <summary>
        /// Optional. The status.
        /// </summary>
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private Uri _url;
        
        /// <summary>
        /// Optional. The url for this WebJob run.
        /// </summary>
        public Uri Url
        {
            get { return this._url; }
            set { this._url = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the TriggeredWebJobRun class.
        /// </summary>
        public TriggeredWebJobRun()
        {
        }
    }
}
