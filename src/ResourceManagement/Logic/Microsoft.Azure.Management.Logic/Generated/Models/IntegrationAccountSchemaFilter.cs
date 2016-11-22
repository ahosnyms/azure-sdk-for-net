// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
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

    public partial class IntegrationAccountSchemaFilter
    {
        /// <summary>
        /// Initializes a new instance of the IntegrationAccountSchemaFilter
        /// class.
        /// </summary>
        public IntegrationAccountSchemaFilter() { }

        /// <summary>
        /// Initializes a new instance of the IntegrationAccountSchemaFilter
        /// class.
        /// </summary>
        public IntegrationAccountSchemaFilter(SchemaType? schemaType = default(SchemaType?))
        {
            SchemaType = schemaType;
        }

        /// <summary>
        /// Gets or sets the schema type of integration account schema.
        /// Possible values include: 'NotSpecified', 'Xml'
        /// </summary>
        [JsonProperty(PropertyName = "schemaType")]
        public SchemaType? SchemaType { get; set; }

    }
}
