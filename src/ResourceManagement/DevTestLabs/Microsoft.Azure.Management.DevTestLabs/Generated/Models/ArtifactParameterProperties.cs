// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DevTestLabs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Properties of an artifact parameter.
    /// </summary>
    public partial class ArtifactParameterProperties
    {
        /// <summary>
        /// Initializes a new instance of the ArtifactParameterProperties
        /// class.
        /// </summary>
        public ArtifactParameterProperties() { }

        /// <summary>
        /// Initializes a new instance of the ArtifactParameterProperties
        /// class.
        /// </summary>
        public ArtifactParameterProperties(string name = default(string), string value = default(string))
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// The name of the artifact parameter.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the artifact parameter.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
