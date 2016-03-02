// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Intune.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Device entity for Intune.
    /// </summary>
    public partial class Device : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        public Device() { }

        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        public Device(string userId, string friendlyName, string platform, string platformVersion, string deviceType)
        {
            UserId = userId;
            FriendlyName = friendlyName;
            Platform = platform;
            PlatformVersion = platformVersion;
            DeviceType = deviceType;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.userId")]
        public string UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.platform")]
        public string Platform { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.platformVersion")]
        public string PlatformVersion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceType")]
        public string DeviceType { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (UserId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "UserId");
            }
            if (FriendlyName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FriendlyName");
            }
            if (Platform == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Platform");
            }
            if (PlatformVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PlatformVersion");
            }
            if (DeviceType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DeviceType");
            }
        }
    }
}
