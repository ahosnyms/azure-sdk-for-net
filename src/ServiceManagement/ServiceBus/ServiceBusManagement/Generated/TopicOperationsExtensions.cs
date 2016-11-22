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
    public static partial class TopicOperationsExtensions
    {
        /// <summary>
        /// Creates a new topic. Once created, this topic resource manifest is
        /// immutable. This operation is not idempotent. Repeating the create
        /// call, after a topic with same name has been created successfully,
        /// will result in a 409 Conflict error message.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780728.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topic'>
        /// Required. The Service Bus topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static ServiceBusTopicResponse Create(this ITopicOperations operations, string namespaceName, ServiceBusTopic topic)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).CreateAsync(namespaceName, topic);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Creates a new topic. Once created, this topic resource manifest is
        /// immutable. This operation is not idempotent. Repeating the create
        /// call, after a topic with same name has been created successfully,
        /// will result in a 409 Conflict error message.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780728.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topic'>
        /// Required. The Service Bus topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static Task<ServiceBusTopicResponse> CreateAsync(this ITopicOperations operations, string namespaceName, ServiceBusTopic topic)
        {
            return operations.CreateAsync(namespaceName, topic, CancellationToken.None);
        }
        
        /// <summary>
        /// Deletes an existing topic. This operation will also remove all
        /// associated state including associated subscriptions.  (see
        /// http://msdn.microsoft.com/en-us/library/hh780721.aspx for more
        /// information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Delete(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).DeleteAsync(namespaceName, topicName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Deletes an existing topic. This operation will also remove all
        /// associated state including associated subscriptions.  (see
        /// http://msdn.microsoft.com/en-us/library/hh780721.aspx for more
        /// information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> DeleteAsync(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return operations.DeleteAsync(namespaceName, topicName, CancellationToken.None);
        }
        
        /// <summary>
        /// The topic description is an XML AtomPub document that defines the
        /// desired semantics for a topic. The topic description contains the
        /// following properties. For more information, see the
        /// TopicDescription Properties topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780749.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static ServiceBusTopicResponse Get(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).GetAsync(namespaceName, topicName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// The topic description is an XML AtomPub document that defines the
        /// desired semantics for a topic. The topic description contains the
        /// following properties. For more information, see the
        /// TopicDescription Properties topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780749.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static Task<ServiceBusTopicResponse> GetAsync(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return operations.GetAsync(namespaceName, topicName, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets the set of connection strings for a topic.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static ServiceBusConnectionDetailsResponse GetConnectionDetails(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).GetConnectionDetailsAsync(namespaceName, topicName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets the set of connection strings for a topic.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topicName'>
        /// Required. The topic.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static Task<ServiceBusConnectionDetailsResponse> GetConnectionDetailsAsync(this ITopicOperations operations, string namespaceName, string topicName)
        {
            return operations.GetConnectionDetailsAsync(namespaceName, topicName, CancellationToken.None);
        }
        
        /// <summary>
        /// Enumerates the topics in the service namespace. An empty feed is
        /// returned if no topic exists in the service namespace.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780744.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <returns>
        /// A response to a request for a list of topics.
        /// </returns>
        public static ServiceBusTopicsResponse List(this ITopicOperations operations, string namespaceName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).ListAsync(namespaceName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Enumerates the topics in the service namespace. An empty feed is
        /// returned if no topic exists in the service namespace.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780744.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <returns>
        /// A response to a request for a list of topics.
        /// </returns>
        public static Task<ServiceBusTopicsResponse> ListAsync(this ITopicOperations operations, string namespaceName)
        {
            return operations.ListAsync(namespaceName, CancellationToken.None);
        }
        
        /// <summary>
        /// Updates a topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj839740.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topic'>
        /// Required. The Service Bus topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static ServiceBusTopicResponse Update(this ITopicOperations operations, string namespaceName, ServiceBusTopic topic)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITopicOperations)s).UpdateAsync(namespaceName, topic);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Updates a topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj839740.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.ITopicOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='topic'>
        /// Required. The Service Bus topic.
        /// </param>
        /// <returns>
        /// A response to a request for a particular topic.
        /// </returns>
        public static Task<ServiceBusTopicResponse> UpdateAsync(this ITopicOperations operations, string namespaceName, ServiceBusTopic topic)
        {
            return operations.UpdateAsync(namespaceName, topic, CancellationToken.None);
        }
    }
}
