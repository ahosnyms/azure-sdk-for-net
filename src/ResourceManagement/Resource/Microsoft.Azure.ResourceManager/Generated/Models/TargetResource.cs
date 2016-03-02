// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Target resource.
    /// </summary>
    public partial class TargetResource
    {
        /// <summary>
        /// Initializes a new instance of the TargetResource class.
        /// </summary>
        public TargetResource() { }

        /// <summary>
        /// Initializes a new instance of the TargetResource class.
        /// </summary>
        public TargetResource(string id = default(string), string resourceName = default(string), string resourceType = default(string))
        {
            Id = id;
            ResourceName = resourceName;
            ResourceType = resourceType;
        }

        /// <summary>
        /// Gets or sets the ID of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "resourceName")]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; set; }

    }
}
