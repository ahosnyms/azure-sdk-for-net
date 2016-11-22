// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace Microsoft.Azure.Management.ApiManagement
{
    /// <summary>
    /// Operations for managing Certificates.
    /// </summary>
    public partial interface ICertificatesOperations
    {
        /// <summary>
        /// Creates new or update existing certificate.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='serviceName'>
        /// The name of the Api Management service.
        /// </param>
        /// <param name='certificateId'>
        /// Identifier of the subscription.
        /// </param>
        /// <param name='parameters'>
        /// Create parameters.
        /// </param>
        /// <param name='etag'>
        /// ETag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> CreateOrUpdateAsync(string resourceGroupName, string serviceName, string certificateId, CertificateCreateOrUpdateParameters parameters, string etag, CancellationToken cancellationToken);
        
        /// <summary>
        /// Deletes specific certificate.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='serviceName'>
        /// The name of the Api Management service.
        /// </param>
        /// <param name='certificateId'>
        /// Identifier of the certificate.
        /// </param>
        /// <param name='etag'>
        /// ETag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> DeleteAsync(string resourceGroupName, string serviceName, string certificateId, string etag, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets specific certificate.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='serviceName'>
        /// The name of the Api Management service.
        /// </param>
        /// <param name='certificateId'>
        /// Identifier of the certificate.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Get Certificate operation response details.
        /// </returns>
        Task<CertificateGetResponse> GetAsync(string resourceGroupName, string serviceName, string certificateId, CancellationToken cancellationToken);
        
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='serviceName'>
        /// The name of the Api Management service.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List Certificates operation response details.
        /// </returns>
        Task<CertificateListResponse> ListAsync(string resourceGroupName, string serviceName, QueryParameters query, CancellationToken cancellationToken);
        
        /// <summary>
        /// List all certificates of the Api Management service instance.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List Certificates operation response details.
        /// </returns>
        Task<CertificateListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken);
    }
}
