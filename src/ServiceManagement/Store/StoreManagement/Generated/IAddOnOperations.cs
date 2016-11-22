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
using Microsoft.WindowsAzure.Management.Store.Models;

namespace Microsoft.WindowsAzure.Management.Store
{
    /// <summary>
    /// Provides REST operations for working with Store add-ins from the
    /// Windows Azure store service.
    /// </summary>
    public partial interface IAddOnOperations
    {
        /// <summary>
        /// The Create Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// The name of the cloud service to which this store item will be
        /// assigned.
        /// </param>
        /// <param name='resourceName'>
        /// The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// The add on name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters used to specify how the Create procedure will function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        Task<OperationStatusResponse> BeginCreatingAsync(string cloudServiceName, string resourceName, string addOnName, AddOnCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Delete Store Item operation deletes Windows Azure Store entries
        /// that re provisioned for a subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// The name of the cloud service to which this store item will be
        /// assigned.
        /// </param>
        /// <param name='resourceProviderNamespace'>
        /// The namespace in which this store item resides.
        /// </param>
        /// <param name='resourceProviderType'>
        /// The type of store item to be deleted.
        /// </param>
        /// <param name='resourceProviderName'>
        /// The name of this resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        Task<OperationStatusResponse> BeginDeletingAsync(string cloudServiceName, string resourceProviderNamespace, string resourceProviderType, string resourceProviderName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Create Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// The name of the cloud service to which this store item will be
        /// assigned.
        /// </param>
        /// <param name='resourceName'>
        /// The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// The add on name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters used to specify how the Create procedure will function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        Task<OperationStatusResponse> CreateAsync(string cloudServiceName, string resourceName, string addOnName, AddOnCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Delete Store Item operation deletes Windows Azure Storeentries
        /// that are provisioned for a subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// The name of the cloud service to which this store item will be
        /// assigned.
        /// </param>
        /// <param name='resourceProviderNamespace'>
        /// The namespace in which this store item resides.
        /// </param>
        /// <param name='resourceProviderType'>
        /// The type of store item to be deleted.
        /// </param>
        /// <param name='resourceProviderName'>
        /// The name of this resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        Task<OperationStatusResponse> DeleteAsync(string cloudServiceName, string resourceProviderNamespace, string resourceProviderType, string resourceProviderName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Update Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// The name of the cloud service to which this store item will be
        /// assigned.
        /// </param>
        /// <param name='resourceName'>
        /// The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// The addon name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters used to specify how the Create procedure will function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        Task<OperationStatusResponse> UpdateAsync(string cloudServiceName, string resourceName, string addOnName, AddOnUpdateParameters parameters, CancellationToken cancellationToken);
    }
}
