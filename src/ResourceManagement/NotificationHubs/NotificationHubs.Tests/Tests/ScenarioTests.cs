<<<<<<< HEAD
﻿//  
=======
﻿﻿//  
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace NotificationHubs.Tests.ScenarioTests
{
<<<<<<< HEAD
    using global::NotificationHubs.Tests;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        private ManagementClient _managmentClient;
=======
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System.Net;
    using System;

    public partial class ScenarioTests 
    {
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        private ResourceManagementClient _resourceManagementClient;
        private NotificationHubsManagementClient _notificationHubsManagementClient;
        private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

<<<<<<< HEAD
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string NamespaceName { get; set; }

        public ManagementClient ManagmentClient
        {
            get
            {
                if (_managmentClient == null)
                {
                    _managmentClient = NotificationHubsManagementHelper.GetManagementClient(handler);
                }
                return _managmentClient;
=======
        protected bool m_initialized = false;
        protected object m_lock = new object();
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string NamespaceName { get; set; }
               

        protected void InitializeClients(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        _resourceManagementClient = NotificationHubsManagementHelper.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        _notificationHubsManagementClient = NotificationHubsManagementHelper.GetNotificationHubsManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    }
                }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
<<<<<<< HEAD
            {
                if (_resourceManagementClient == null)
                {
                    _resourceManagementClient = NotificationHubsManagementHelper.GetResourceManagementClient(handler);
                }
=======
            {                
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                return _resourceManagementClient;
            }
        }

        public NotificationHubsManagementClient NotificationHubsManagementClient
        {
            get
<<<<<<< HEAD
            {
                if (_notificationHubsManagementClient == null)
                {
                    _notificationHubsManagementClient = NotificationHubsManagementHelper.GetNotificationHubsManagementClient(handler);
                }
=======
            {               
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                return _notificationHubsManagementClient;
            }
        }

        protected void TryCreateNamespace()
        {
            this.ResourceGroupName = this.ResourceManagementClient.TryGetResourceGroup(Location);
            this.Location = NotificationHubsManagementHelper.DefaultLocation;

            if (string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                ResourceGroupName = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                this.ResourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
            }

            NamespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
            this.NotificationHubsManagementClient.TryCreateNamespace(ResourceGroupName, NamespaceName, Location);
<<<<<<< HEAD
        }        
=======
        }

        public bool ActivateNamespace(string resourceGroup, string namespaceName)
        {
            while (true)
            {
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);

                if (getNamespaceResponse.ProvisioningState.Equals("Succeeded", StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
        }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    }
}
