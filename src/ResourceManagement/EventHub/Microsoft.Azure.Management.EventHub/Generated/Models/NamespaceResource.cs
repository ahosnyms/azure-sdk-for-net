// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.EventHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Description of a Namespace resource.
    /// </summary>
    [JsonTransformation]
    public partial class NamespaceResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the NamespaceResource class.
        /// </summary>
        public NamespaceResource() { }

        /// <summary>
        /// Initializes a new instance of the NamespaceResource class.
        /// </summary>
        public NamespaceResource(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Sku sku = default(Sku), string provisioningState = default(string), NamespaceState? status = default(NamespaceState?), DateTime? createdAt = default(DateTime?), DateTime? updatedAt = default(DateTime?), string serviceBusEndpoint = default(string), bool? createACSNamespace = default(bool?), bool? enabled = default(bool?))
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            ProvisioningState = provisioningState;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ServiceBusEndpoint = serviceBusEndpoint;
            CreateACSNamespace = createACSNamespace;
            Enabled = enabled;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Provisioning state of the Namespace.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// State of the namespace. Possible values include: 'Unknown',
        /// 'Creating', 'Created', 'Activating', 'Enabling', 'Active',
        /// 'Disabling', 'Disabled', 'SoftDeleting', 'SoftDeleted',
        /// 'Removing', 'Removed', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public NamespaceState? Status { get; set; }

        /// <summary>
        /// The time the namespace was created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The time the namespace was updated.
        /// </summary>
        [JsonProperty(PropertyName = "properties.updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Endpoint you can use to perform ServiceBus operations.
        /// </summary>
        [JsonProperty(PropertyName = "properties.serviceBusEndpoint")]
        public string ServiceBusEndpoint { get; set; }

        /// <summary>
        /// Indicates whether to create ACS namespace.
        /// </summary>
        [JsonProperty(PropertyName = "properties.createACSNamespace")]
        public bool? CreateACSNamespace { get; set; }

        /// <summary>
        /// Specifies whether this instance is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Sku != null)
            {
                this.Sku.Validate();
            }
        }
    }
}
