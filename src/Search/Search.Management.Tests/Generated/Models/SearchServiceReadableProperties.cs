// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Search.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines all the properties of an Azure Search service.
    /// </summary>
    public partial class SearchServiceReadableProperties
    {
        /// <summary>
        /// Initializes a new instance of the SearchServiceReadableProperties
        /// class.
        /// </summary>
        public SearchServiceReadableProperties() { }

        /// <summary>
        /// Initializes a new instance of the SearchServiceReadableProperties
        /// class.
        /// </summary>
        public SearchServiceReadableProperties(SearchServiceStatus? status = default(SearchServiceStatus?), string statusDetails = default(string), ProvisioningState? provisioningState = default(ProvisioningState?), Sku sku = default(Sku), int? replicaCount = default(int?), int? partitionCount = default(int?))
        {
            Status = status;
            StatusDetails = statusDetails;
            ProvisioningState = provisioningState;
            Sku = sku;
            ReplicaCount = replicaCount;
            PartitionCount = partitionCount;
        }

        /// <summary>
        /// Gets the status of the Search service. Possible values for this
        /// property include: 'running', 'provisioning', 'deleting',
        /// 'degraded', 'disabled', 'error'.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public SearchServiceStatus? Status { get; set; }

        /// <summary>
        /// Gets the details of the Search service status.
        /// </summary>
        [JsonProperty(PropertyName = "statusDetails")]
        public string StatusDetails { get; set; }

        /// <summary>
        /// Gets the state of the last provisioning operation performed on the
        /// Search service. Possible values for this property include:
        /// 'succeeded', 'provisioning', 'failed'.
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public ProvisioningState? ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the SKU of the Search Service, which determines price
        /// tier and capacity limits.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the number of replicas in the Search service. If
        /// specified, it must be a value between 1 and 6 inclusive.
        /// </summary>
        [JsonProperty(PropertyName = "replicaCount")]
        public int? ReplicaCount { get; set; }

        /// <summary>
        /// Gets or sets the number of partitions in the Search service; if
        /// specified, it can be 1, 2, 3, 4, 6, or 12.
        /// </summary>
        [JsonProperty(PropertyName = "partitionCount")]
        public int? PartitionCount { get; set; }

    }
}
