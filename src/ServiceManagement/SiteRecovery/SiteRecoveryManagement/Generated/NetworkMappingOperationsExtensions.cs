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
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.WindowsAzure.Management.SiteRecovery
{
    public static partial class NetworkMappingOperationsExtensions
    {
        /// <summary>
        /// Create network mapping.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Create network mapping input.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Job details object.
        /// </returns>
        public static JobResponse Create(this INetworkMappingOperations operations, NetworkMappingInput parameters, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((INetworkMappingOperations)s).CreateAsync(parameters, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create network mapping.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Create network mapping input.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Job details object.
        /// </returns>
        public static Task<JobResponse> CreateAsync(this INetworkMappingOperations operations, NetworkMappingInput parameters, CustomRequestHeaders customRequestHeaders)
        {
            return operations.CreateAsync(parameters, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// Delete network mapping.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Delete network mapping input.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Job details object.
        /// </returns>
        public static JobResponse Delete(this INetworkMappingOperations operations, NetworkUnMappingInput parameters, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((INetworkMappingOperations)s).DeleteAsync(parameters, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Delete network mapping.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Delete network mapping input.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Job details object.
        /// </returns>
        public static Task<JobResponse> DeleteAsync(this INetworkMappingOperations operations, NetworkUnMappingInput parameters, CustomRequestHeaders customRequestHeaders)
        {
            return operations.DeleteAsync(parameters, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// Get the list of all network mappings under the vault.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='primaryServerId'>
        /// Required. Primary server Id.
        /// </param>
        /// <param name='recoveryServerId'>
        /// Required. Recovery server Id.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list of network mappings operation.
        /// </returns>
        public static NetworkMappingListResponse List(this INetworkMappingOperations operations, string primaryServerId, string recoveryServerId, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((INetworkMappingOperations)s).ListAsync(primaryServerId, recoveryServerId, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get the list of all network mappings under the vault.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.INetworkMappingOperations.
        /// </param>
        /// <param name='primaryServerId'>
        /// Required. Primary server Id.
        /// </param>
        /// <param name='recoveryServerId'>
        /// Required. Recovery server Id.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list of network mappings operation.
        /// </returns>
        public static Task<NetworkMappingListResponse> ListAsync(this INetworkMappingOperations operations, string primaryServerId, string recoveryServerId, CustomRequestHeaders customRequestHeaders)
        {
            return operations.ListAsync(primaryServerId, recoveryServerId, customRequestHeaders, CancellationToken.None);
        }
    }
}
