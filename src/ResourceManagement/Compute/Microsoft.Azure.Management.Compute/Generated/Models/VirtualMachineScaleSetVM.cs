// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes a virtual machine scale set virtual machine.
    /// </summary>
    public partial class VirtualMachineScaleSetVM : Resource
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSetVM class.
        /// </summary>
        public VirtualMachineScaleSetVM() { }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSetVM class.
        /// </summary>
        public VirtualMachineScaleSetVM(string instanceId = default(string), Sku sku = default(Sku), Plan plan = default(Plan), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), bool? latestModelApplied = default(bool?), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), string provisioningState = default(string))
        {
            InstanceId = instanceId;
            Sku = sku;
            Plan = plan;
            Resources = resources;
            LatestModelApplied = latestModelApplied;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
        }

        /// <summary>
        /// Gets the virtual machine instance id.
        /// </summary>
        [JsonProperty(PropertyName = "instanceId")]
        public string InstanceId { get; private set; }

        /// <summary>
        /// Gets the virtual machine sku.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; private set; }

        /// <summary>
        /// Gets or sets the purchase plan when deploying virtual machine from
        /// VM Marketplace images.
        /// </summary>
        [JsonProperty(PropertyName = "plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// Gets the virtual machine child extension resources.
        /// </summary>
        [JsonProperty(PropertyName = "resources")]
        public IList<VirtualMachineExtension> Resources { get; private set; }

        /// <summary>
        /// Specifies whether the latest model has been applied to the virtual
        /// machine.
        /// </summary>
        [JsonProperty(PropertyName = "properties.latestModelApplied")]
        public bool? LatestModelApplied { get; private set; }

        /// <summary>
        /// Gets the virtual machine instance view.
        /// </summary>
        [JsonProperty(PropertyName = "properties.instanceView")]
        public VirtualMachineInstanceView InstanceView { get; private set; }

        /// <summary>
        /// Gets or sets the hardware profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.hardwareProfile")]
        public HardwareProfile HardwareProfile { get; set; }

        /// <summary>
        /// Gets or sets the storage profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageProfile")]
        public StorageProfile StorageProfile { get; set; }

        /// <summary>
        /// Gets or sets the OS profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.osProfile")]
        public OSProfile OsProfile { get; set; }

        /// <summary>
        /// Gets or sets the network profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkProfile")]
        public NetworkProfile NetworkProfile { get; set; }

        /// <summary>
        /// Gets or sets the diagnostics profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.diagnosticsProfile")]
        public DiagnosticsProfile DiagnosticsProfile { get; set; }

        /// <summary>
        /// Gets or sets the reference Id of the availailbity set to which
        /// this virtual machine belongs.
        /// </summary>
        [JsonProperty(PropertyName = "properties.availabilitySet")]
        public SubResource AvailabilitySet { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state, which only appears in the
        /// response.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Resources != null)
            {
                foreach (var element in this.Resources)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.StorageProfile != null)
            {
                this.StorageProfile.Validate();
            }
        }
    }
}
