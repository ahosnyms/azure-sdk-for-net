// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Logic.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class RegenerateSecretKeyParameters
    {
        /// <summary>
        /// Initializes a new instance of the RegenerateSecretKeyParameters
        /// class.
        /// </summary>
        public RegenerateSecretKeyParameters() { }

        /// <summary>
        /// Initializes a new instance of the RegenerateSecretKeyParameters
        /// class.
        /// </summary>
        public RegenerateSecretKeyParameters(KeyType? keyType = default(KeyType?))
        {
            KeyType = keyType;
        }

        /// <summary>
        /// Gets or sets the key type. Possible values for this property
        /// include: 'NotSpecified', 'Primary', 'Secondary'.
        /// </summary>
        [JsonProperty(PropertyName = "keyType")]
        public KeyType? KeyType { get; set; }

    }
}
