// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The plan object in an ARM, represents a marketplace plan
    /// </summary>
    public partial class ArmPlan
    {
        /// <summary>
        /// Initializes a new instance of the ArmPlan class.
        /// </summary>
        public ArmPlan() { }

        /// <summary>
        /// Initializes a new instance of the ArmPlan class.
        /// </summary>
        public ArmPlan(string name = default(string), string publisher = default(string), string product = default(string), string promotionCode = default(string), string version = default(string))
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            PromotionCode = promotionCode;
            Version = version;
        }

        /// <summary>
        /// The name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The publisher
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// The product
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public string Product { get; set; }

        /// <summary>
        /// The promotion code
        /// </summary>
        [JsonProperty(PropertyName = "promotionCode")]
        public string PromotionCode { get; set; }

        /// <summary>
        /// Version of product
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

    }
}
