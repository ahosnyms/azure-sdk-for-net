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
    /// Describes a Encryption Settings for a Disk
    /// </summary>
    public partial class DiskEncryptionSettings
    {
        /// <summary>
        /// Initializes a new instance of the DiskEncryptionSettings class.
        /// </summary>
        public DiskEncryptionSettings() { }

        /// <summary>
        /// Initializes a new instance of the DiskEncryptionSettings class.
        /// </summary>
        public DiskEncryptionSettings(KeyVaultSecretReference diskEncryptionKey, KeyVaultKeyReference keyEncryptionKey = default(KeyVaultKeyReference))
        {
            DiskEncryptionKey = diskEncryptionKey;
            KeyEncryptionKey = keyEncryptionKey;
        }

        /// <summary>
        /// Gets or sets the disk encryption key which is a KeyVault Secret.
        /// </summary>
        [JsonProperty(PropertyName = "diskEncryptionKey")]
        public KeyVaultSecretReference DiskEncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets the key encryption key which is KeyVault Key.
        /// </summary>
        [JsonProperty(PropertyName = "keyEncryptionKey")]
        public KeyVaultKeyReference KeyEncryptionKey { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (DiskEncryptionKey == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DiskEncryptionKey");
            }
            if (this.DiskEncryptionKey != null)
            {
                this.DiskEncryptionKey.Validate();
            }
            if (this.KeyEncryptionKey != null)
            {
                this.KeyEncryptionKey.Validate();
            }
        }
    }
}
