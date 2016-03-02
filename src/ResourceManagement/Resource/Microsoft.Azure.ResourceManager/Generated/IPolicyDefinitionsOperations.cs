// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// PolicyDefinitionsOperations operations.
    /// </summary>
    public partial interface IPolicyDefinitionsOperations
    {
        /// <summary>
        /// Create or update policy definition.
        /// </summary>
        /// <param name='policyDefinitionName'>
        /// The policy definition name.
        /// </param>
        /// <param name='parameters'>
        /// The policy definition properties
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<PolicyDefinition>> CreateOrUpdateWithHttpMessagesAsync(string policyDefinitionName, PolicyDefinition parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets policy definition.
        /// </summary>
        /// <param name='policyDefinitionName'>
        /// The policy definition name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<PolicyDefinition>> GetWithHttpMessagesAsync(string policyDefinitionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes policy definition.
        /// </summary>
        /// <param name='policyDefinitionName'>
        /// The policy definition name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string policyDefinitionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
