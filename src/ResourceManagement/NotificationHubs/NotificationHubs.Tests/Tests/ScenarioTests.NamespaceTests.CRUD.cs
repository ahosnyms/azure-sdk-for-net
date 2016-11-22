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
    using System.Linq;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
=======
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Linq;
    using TestHelper;
    using Xunit;
    using System.Collections.Generic;
    public partial class ScenarioTests
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    {
        [Fact]
        public void NamespaceCreateGetUpdateDelete()
        {
<<<<<<< HEAD
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "NamespaceCreateGetUpdateDelete");
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

<<<<<<< HEAD
                var createNamespaceResponse = this.NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, 
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.NotNull(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Properties.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.Value.Properties.ProvisioningState, "Succeeded", true) != 0)
=======
                var createNamespaceResponse = this.NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        NamespaceType = NamespaceType.NotificationHub,
                        Sku = new Sku { Name = SkuName.Standard }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
<<<<<<< HEAD
                Assert.NotNull(getNamespaceResponse.Value);
                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);
=======
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Standard", getNamespaceResponse.Sku.Name, StringComparer.CurrentCultureIgnoreCase);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.List(resourceGroup);
                Assert.NotNull(getAllNamespacesResponse);
<<<<<<< HEAD
                Assert.NotNull(getAllNamespacesResponse.Value);
                Assert.True(getAllNamespacesResponse.Value.Count >= 1);
                Assert.True(getAllNamespacesResponse.Value.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.Value.All(ns => ns.Id.Contains(resourceGroup)));
=======
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.ListAll();
                Assert.NotNull(getAllNamespacesResponse);
<<<<<<< HEAD
                Assert.NotNull(getAllNamespacesResponse.Value);
                Assert.True(getAllNamespacesResponse.Value.Count >= 1);
                Assert.True(getAllNamespacesResponse.Value.Any(ns => ns.Name == namespaceName));

                //Update namespace tags and make the namespace critical
                var updateNamespaceParameter = new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Tags = 
=======
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));

                //Update namespace tags and make the namespace critical
                var updateNamespaceParameter = new NamespaceCreateOrUpdateParameters()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                            {"tag4", "value4"}
<<<<<<< HEAD
                        },

                        Properties = new NamespaceProperties()
                    };
=======
                        }
                };
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var updateNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceParameter);

                Assert.NotNull(updateNamespaceResponse);
<<<<<<< HEAD
                Assert.NotNull(updateNamespaceResponse.Value);
                Assert.Equal("Active", updateNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, updateNamespaceResponse.Value.Properties.Name);
                //Assert.True(updateNamespaceResponse.Value.Properties.Critical);
                Assert.Equal(updateNamespaceResponse.Value.Tags.Count, 4);
                foreach(var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(updateNamespaceResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(updateNamespaceResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
=======
                Assert.True(updateNamespaceResponse.ProvisioningState.Equals("Active", StringComparison.CurrentCultureIgnoreCase) ||
                    updateNamespaceResponse.ProvisioningState.Equals("Succeeded", StringComparison.CurrentCultureIgnoreCase));
                Assert.Equal(namespaceName, updateNamespaceResponse.Name);
                //Regression in the service . uncomment after the fix goes out 
                Assert.Equal(updateNamespaceResponse.Tags.Count, 4);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(updateNamespaceResponse.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(updateNamespaceResponse.Tags.Any(t => t.Value.Equals(tag.Value)));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the updated namespace
                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
<<<<<<< HEAD
                Assert.NotNull(getNamespaceResponse.Value);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, getNamespaceResponse.Value.Name);
                //Assert.True(getNamespaceResponse.Value.Properties.Critical);
                Assert.Equal(getNamespaceResponse.Value.Tags.Count, 4);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(getNamespaceResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNamespaceResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
                }


                //create Namespace 2
                var namespaceName2 = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);

                var createNamespaceResponse2 = this.NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName2,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse2);
                Assert.NotNull(createNamespaceResponse2.Value);
                Assert.Equal(createNamespaceResponse2.Value.Properties.Name, namespaceName2);

                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                //Delete namespace
                var deleteNSResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName2);
                Assert.NotNull(deleteNSResponse);
                Assert.True(HttpStatusCode.NotFound == deleteNSResponse.StatusCode || HttpStatusCode.OK == deleteNSResponse.StatusCode);

                deleteNSResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                Assert.NotNull(deleteNSResponse);
                Assert.True(HttpStatusCode.NotFound == deleteNSResponse.StatusCode || HttpStatusCode.OK == deleteNSResponse.StatusCode);
=======
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, getNamespaceResponse.Name);
                Assert.Equal(getNamespaceResponse.Tags.Count, 4);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(getNamespaceResponse.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNamespaceResponse.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                var updateNamespacePatchParameter = new NamespacePatchParameters()
                {
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag5", "value5"},
                            {"tag6", "value6"},
                        },
                    Sku = new Sku { Name = SkuName.Basic}
                };

                var updateNamespacePatchResponse = NotificationHubsManagementClient.Namespaces.Patch(resourceGroup, namespaceName, updateNamespacePatchParameter);

                Assert.NotNull(updateNamespacePatchResponse);
                Assert.Equal(updateNamespacePatchResponse.Tags.Count, 2);
                foreach (var tag in updateNamespacePatchParameter.Tags)
                {
                    Assert.True(updateNamespacePatchParameter.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(updateNamespacePatchParameter.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.Equal("Basic", getNamespaceResponse.Sku.Name, StringComparer.CurrentCultureIgnoreCase);

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
    }
}
