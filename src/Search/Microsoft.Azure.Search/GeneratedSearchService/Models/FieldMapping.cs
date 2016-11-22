// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines a mapping between a field in a data source and a target field
    /// in an index.
    /// <see href="https://azure.microsoft.com/documentation/articles/search-indexer-field-mappings/" />
    /// </summary>
    public partial class FieldMapping
    {
        /// <summary>
        /// Initializes a new instance of the FieldMapping class.
        /// </summary>
        public FieldMapping() { }

        /// <summary>
        /// Initializes a new instance of the FieldMapping class.
        /// </summary>
        public FieldMapping(string sourceFieldName, string targetFieldName = default(string), FieldMappingFunction mappingFunction = default(FieldMappingFunction))
        {
            SourceFieldName = sourceFieldName;
            TargetFieldName = targetFieldName;
            MappingFunction = mappingFunction;
        }

        /// <summary>
        /// Gets or sets the name of the field in the data source.
        /// </summary>
        [JsonProperty(PropertyName = "sourceFieldName")]
        public string SourceFieldName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target field in the index. Same as
        /// the source field name by default.
        /// </summary>
        [JsonProperty(PropertyName = "targetFieldName")]
        public string TargetFieldName { get; set; }

        /// <summary>
        /// Gets or sets a function to apply to each source field value before
        /// indexing.
        /// </summary>
        [JsonProperty(PropertyName = "mappingFunction")]
        public FieldMappingFunction MappingFunction { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (SourceFieldName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SourceFieldName");
            }
            if (this.MappingFunction != null)
            {
                this.MappingFunction.Validate();
            }
        }
    }
}
