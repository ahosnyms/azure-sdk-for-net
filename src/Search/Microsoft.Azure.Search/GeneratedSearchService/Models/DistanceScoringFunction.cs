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
    /// Defines a function that boosts scores based on distance from a
    /// geographic location.
    /// <see href="https://msdn.microsoft.com/library/azure/dn798928.aspx" />
    /// </summary>
    [JsonObject("distance")]
    public partial class DistanceScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction(string fieldName, double boost, DistanceScoringParameters parameters, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : base(fieldName, boost, interpolation)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Gets or sets parameter values for the distance scoring function.
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public DistanceScoringParameters Parameters { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (Parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Parameters");
            }
            if (this.Parameters != null)
            {
                this.Parameters.Validate();
            }
        }
    }
}
