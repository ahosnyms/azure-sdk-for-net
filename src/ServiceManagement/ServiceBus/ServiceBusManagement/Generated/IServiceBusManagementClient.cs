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
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Management.ServiceBus
{
    /// <summary>
    /// The Service Bus Management API is a REST API for managing Service Bus
    /// queues, topics, rules and subscriptions.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780776.aspx for
    /// more information)
    /// </summary>
    public partial interface IServiceBusManagementClient : IDisposable
    {
        /// <summary>
        /// Gets the API version.
        /// </summary>
        string ApiVersion
        {
            get; 
        }
        
        /// <summary>
        /// Gets the URI used as the base for all cloud service requests.
        /// </summary>
        Uri BaseUri
        {
            get; 
        }
        
        /// <summary>
        /// Gets subscription credentials which uniquely identify Microsoft
        /// Azure subscription. The subscription ID forms part of the URI for
        /// every service call.
        /// </summary>
        SubscriptionCloudCredentials Credentials
        {
            get; 
        }
        
        /// <summary>
        /// Gets or sets the initial timeout for Long Running Operations.
        /// </summary>
        int LongRunningOperationInitialTimeout
        {
            get; set; 
        }
        
        /// <summary>
        /// Gets or sets the retry timeout for Long Running Operations.
        /// </summary>
        int LongRunningOperationRetryTimeout
        {
            get; set; 
        }
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus namespaces.
        /// </summary>
        INamespaceOperations Namespaces
        {
            get; 
        }
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus notification hubs.
        /// </summary>
        INotificationHubOperations NotificationHubs
        {
            get; 
        }
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus queues.
        /// </summary>
        IQueueOperations Queues
        {
            get; 
        }
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus relays.
        /// </summary>
        IRelayOperations Relays
        {
            get; 
        }
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus topics for a namespace.
        /// </summary>
        ITopicOperations Topics
        {
            get; 
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of
        /// thespecified operation. After calling an asynchronous operation,
        /// you can call Get Operation Status to determine whether the
        /// operation has succeeded, failed, or is still in progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='requestId'>
        /// The request ID for the request you wish to track. The request ID is
        /// returned in the x-ms-request-id response header for every request.
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
        Task<OperationStatusResponse> GetOperationStatusAsync(string requestId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Retrieves the list of regions that support the creation and
        /// management of Service Bus service namespaces.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj860465.aspx
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a list of regions.
        /// </returns>
        Task<ServiceBusRegionsResponse> GetServiceBusRegionsAsync(CancellationToken cancellationToken);
    }
}
