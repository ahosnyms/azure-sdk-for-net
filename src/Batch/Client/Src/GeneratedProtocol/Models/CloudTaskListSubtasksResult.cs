// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Batch.Protocol.Models
{
    using System.Linq;

    /// <summary>
    /// Response to a CloudTaskOperations.ListSubtasks request.
    /// </summary>
    public partial class CloudTaskListSubtasksResult
    {
        /// <summary>
        /// Initializes a new instance of the CloudTaskListSubtasksResult
        /// class.
        /// </summary>
        public CloudTaskListSubtasksResult() { }

        /// <summary>
        /// Initializes a new instance of the CloudTaskListSubtasksResult
        /// class.
        /// </summary>
        /// <param name="value">The list of information of subtasks.</param>
        public CloudTaskListSubtasksResult(System.Collections.Generic.IList<SubtaskInformation> value = default(System.Collections.Generic.IList<SubtaskInformation>))
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the list of information of subtasks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public System.Collections.Generic.IList<SubtaskInformation> Value { get; set; }

    }
}
