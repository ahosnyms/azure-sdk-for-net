//  
//  
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
    using Hyak.Common;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
=======
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System;
    using Xunit;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Rest.Azure;
    using System.Linq;

    public partial class ScenarioTests 
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    {
        [Fact]
        public void NotificationHubCreateGetUpdateDelete()
        {
<<<<<<< HEAD
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "NotificationHubCreateGetUpdateDelete");
=======
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);

                var createNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
<<<<<<< HEAD
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.NotNull(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Properties.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));
=======
                        Location = location
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                ActivateNamespace(resourceGroup, namespaceName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
<<<<<<< HEAD
                Assert.NotNull(getNamespaceResponse.Value);
                if (string.Compare(getNamespaceResponse.Value.Properties.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
=======

                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Create a notificationHub
                var notificationHubList = CreateNotificationHubs(location, resourceGroup, namespaceName, 1);
                var notificationHubName = notificationHubList.FirstOrDefault();

                //Get the created notificationHub
                var getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubResponse);
<<<<<<< HEAD
                Assert.NotNull(getNotificationHubResponse.Value);
                Assert.Equal(getNotificationHubResponse.Value.Name, notificationHubName);
=======
                Assert.Equal(getNotificationHubResponse.Name, notificationHubName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Get all namespaces created within a namespace
                var getAllNotificationHubsResponse = NotificationHubsManagementClient.NotificationHubs.List(resourceGroup, namespaceName);
                Assert.NotNull(getAllNotificationHubsResponse);
<<<<<<< HEAD
                Assert.NotNull(getAllNotificationHubsResponse.Value);
                Assert.True(getAllNotificationHubsResponse.Value.Count >= 1);
                Assert.True(getAllNotificationHubsResponse.Value.Any(nh => string.Compare(nh.Name, notificationHubName, true) == 0));
                Assert.True(getAllNotificationHubsResponse.Value.All(nh => nh.Id.Contains(resourceGroup)));

                //Update notificationHub tags and add PNS credentials
                var updateNotificationHubParameter = new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NotificationHubProperties()
                        {
                            WnsCredential = new WnsCredential()
                            {
                                Properties = new WnsCredentialProperties()
                                {
                                    PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                                    SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                                    WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                                }
                            }
                        }
                    };
                updateNotificationHubParameter.Tags.Add(new KeyValuePair<string,string>("tag1", "value1"));
                updateNotificationHubParameter.Tags.Add(new KeyValuePair<string,string>("tag2", "value2"));
                updateNotificationHubParameter.Tags.Add(new KeyValuePair<string,string>("tag3", "value3"));
                
                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(updateNotificationHubParameter);

                var updateNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Update(resourceGroup, namespaceName,
                                                                    notificationHubName, updateNotificationHubParameter);

                Assert.NotNull(updateNotificationHubResponse);
                Assert.NotNull(updateNotificationHubResponse.Value);
=======
                Assert.True(getAllNotificationHubsResponse.Count() >= 1);
                Assert.True(getAllNotificationHubsResponse.Any(nh => string.Compare(nh.Name, notificationHubName, true) == 0));
                Assert.True(getAllNotificationHubsResponse.All(nh => nh.Id.Contains(resourceGroup)));

                //Update notificationHub tags and add PNS credentials
                var updateNotificationHubParameter = new NotificationHubCreateOrUpdateParameters()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                        },

                    WnsCredential = new WnsCredential()
                    {
                        PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                        SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                        WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                    }
                };

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(updateNotificationHubParameter);

                var updateNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                                                                    notificationHubName, updateNotificationHubParameter);

                Assert.NotNull(updateNotificationHubResponse);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the updated notificationHub
                getNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubResponse);
<<<<<<< HEAD
                Assert.NotNull(getNotificationHubResponse.Value);
                Assert.Equal(getNotificationHubResponse.Value.Tags.Count, 3);
                foreach (var tag in updateNotificationHubParameter.Tags)
                {
                    Assert.True(getNotificationHubResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNotificationHubResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
=======
                Assert.Equal(getNotificationHubResponse.Tags.Count, 3);
                foreach (var tag in updateNotificationHubParameter.Tags)
                {
                    Assert.True(getNotificationHubResponse.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNotificationHubResponse.Tags.Any(t => t.Value.Equals(tag.Value)));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                //Get the updated notificationHub PNSCredentials
                var getNotificationHubPnsCredentialsResponse = NotificationHubsManagementClient.NotificationHubs.GetPnsCredentials(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse);
<<<<<<< HEAD
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.Value);
                Assert.Equal(notificationHubName, getNotificationHubPnsCredentialsResponse.Value.Name);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.Value.Properties);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.Value.Properties.WnsCredential);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.Value.Properties.WnsCredential.Properties.PackageSid, updateNotificationHubParameter.Properties.WnsCredential.Properties.PackageSid);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.Value.Properties.WnsCredential.Properties.SecretKey, updateNotificationHubParameter.Properties.WnsCredential.Properties.SecretKey);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.Value.Properties.WnsCredential.Properties.WindowsLiveEndpoint, updateNotificationHubParameter.Properties.WnsCredential.Properties.WindowsLiveEndpoint);
               

                //Delete notificationHub
                var deleteResponse = NotificationHubsManagementClient.NotificationHubs.Delete(resourceGroup, namespaceName, notificationHubName);
                Assert.NotNull(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);
=======
                Assert.Equal(notificationHubName, getNotificationHubPnsCredentialsResponse.Name);
                Assert.NotNull(getNotificationHubPnsCredentialsResponse.WnsCredential);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.PackageSid, updateNotificationHubParameter.WnsCredential.PackageSid);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.SecretKey, updateNotificationHubParameter.WnsCredential.SecretKey);
                Assert.Equal(getNotificationHubPnsCredentialsResponse.WnsCredential.WindowsLiveEndpoint, updateNotificationHubParameter.WnsCredential.WindowsLiveEndpoint);


                //Delete notificationHub
                NotificationHubsManagementClient.NotificationHubs.Delete(resourceGroup, namespaceName, notificationHubName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                try
                {
                    NotificationHubsManagementClient.NotificationHubs.Get(resourceGroup, namespaceName, notificationHubName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

<<<<<<< HEAD
                //Delete namespace
                var deleteNSResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                Assert.NotNull(deleteNSResponse);
                Assert.True(HttpStatusCode.NotFound == deleteNSResponse.StatusCode || HttpStatusCode.OK == deleteNSResponse.StatusCode);
=======
                try
                {
                    //Delete namespace
                    NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        private List<string> CreateNotificationHubs(string location, string resourceGroup, string namespaceName, int count)
        {
            List<string> notificationHubNameList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix) + TestUtilities.GenerateName();
                notificationHubNameList.Add(notificationHubName);
                Console.WriteLine(notificationHubName);


                var parameter = new NotificationHubCreateOrUpdateParameters()
<<<<<<< HEAD
                    {
                        Location = location,
                        Properties = new NotificationHubProperties()
                    };

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(parameter);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Create(resourceGroup, namespaceName,
                    notificationHubName, parameter);
                Assert.NotNull(createNotificationHubResponse);
                Assert.NotNull(createNotificationHubResponse.Value);
=======
                {
                    Location = location,
                    WnsCredential = new WnsCredential()
                    {
                        PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699",
                        SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp",
                        WindowsLiveEndpoint = @"http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
                    }
                };

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(parameter);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName, parameter);
                Assert.NotNull(createNotificationHubResponse);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }

            return notificationHubNameList;
        }
    }
}
