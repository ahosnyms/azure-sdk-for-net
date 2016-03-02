// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
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
    /// Collection of stamp capacities
    /// </summary>
    public partial class StampCapacityCollection
    {
        /// <summary>
        /// Initializes a new instance of the StampCapacityCollection class.
        /// </summary>
        public StampCapacityCollection() { }

        /// <summary>
        /// Initializes a new instance of the StampCapacityCollection class.
        /// </summary>
        public StampCapacityCollection(IList<StampCapacity> value = default(IList<StampCapacity>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Collection of resources
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<StampCapacity> Value { get; set; }

        /// <summary>
        /// Link to next page of resources
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
