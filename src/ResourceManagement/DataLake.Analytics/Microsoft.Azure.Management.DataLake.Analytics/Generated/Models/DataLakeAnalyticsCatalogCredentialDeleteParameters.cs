// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Data Lake Analytics catalog credential deletion parameters.
    /// </summary>
    public partial class DataLakeAnalyticsCatalogCredentialDeleteParameters
    {
        /// <summary>
        /// Initializes a new instance of the
        /// DataLakeAnalyticsCatalogCredentialDeleteParameters class.
        /// </summary>
        public DataLakeAnalyticsCatalogCredentialDeleteParameters() { }

        /// <summary>
        /// Initializes a new instance of the
        /// DataLakeAnalyticsCatalogCredentialDeleteParameters class.
        /// </summary>
        /// <param name="password">the current password for the credential and
        /// user with access to the data source. This is required if the
        /// requester is not the account owner.</param>
        public DataLakeAnalyticsCatalogCredentialDeleteParameters(string password = default(string))
        {
            Password = password;
        }

        /// <summary>
        /// Gets or sets the current password for the credential and user with
        /// access to the data source. This is required if the requester is
        /// not the account owner.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}
