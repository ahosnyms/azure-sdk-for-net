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
    using Microsoft.Azure.Test.HttpRecorder;
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
    using Microsoft.Azure.Test.HttpRecorder;
    using TestHelper;
    using System;
    using Xunit;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using System.Net;
    using System.Linq;

    public partial class ScenarioTests 
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    {
        [Fact]
        public void NotificationHubCreateGetUpdateDeleteAuthorizationRules()
        {
<<<<<<< HEAD
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "NotificationHubCreateGetUpdateDeleteAuthorizationRules");
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

                //Create a namespace
                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
                var createNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
<<<<<<< HEAD
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.NotNull(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Properties.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the created namespace
                 var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.Value.Properties.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.NotNull(getNamespaceResponse.Value);
                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);
=======
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                ActivateNamespace(resourceGroup, namespaceName);

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Create a notificationHub
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix);

<<<<<<< HEAD
                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.Create(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NotificationHubProperties() 
                    });

                Assert.NotNull(createNotificationHubResponse);
                Assert.NotNull(createNotificationHubResponse.Value);
=======
                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location
                    });

                Assert.NotNull(createNotificationHubResponse);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                //Create a notificationHub AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
<<<<<<< HEAD
                    Name = authorizationRuleName,
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        KeyName = authorizationRuleName,
                        Rights = new List<AccessRights>() { AccessRights.Listen, AccessRights.Send },
                        PrimaryKey = createPrimaryKey,
                        SecondaryKey = NotificationHubsManagementHelper.GenerateRandomKey(),
                        ClaimType = "SharedAccessKey",
                        ClaimValue = "None"
                    }
                };

                var createNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup, 
                    namespaceName, notificationHubName, authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNotificationHubAuthorizationRuleResponse);
                Assert.NotNull(createNotificationHubAuthorizationRuleResponse.Value);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(createNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r == right));
=======
                    Location = location,
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send },
                    }
                };

                var createNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNotificationHubAuthorizationRuleResponse);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Name, authorizationRuleName);
                Assert.True(createNotificationHubAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNotificationHubAuthorizationRuleResponse.Rights.Any(r => r == right));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                //Get created notificationHub AuthorizationRules
                var getNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRulesResponse);
<<<<<<< HEAD
                Assert.NotNull(getNotificationHubAuthorizationRulesResponse.Value);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNotificationHubAuthorizationRulesResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == right));
=======
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Name, authorizationRuleName);
                Assert.True(getNotificationHubAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRulesResponse.Rights.Any(r => r == right));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                //Get all notificationHub AuthorizationRules 
                var getAllNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.ListAuthorizationRules(resourceGroup, namespaceName,
                    notificationHubName);
                Assert.NotNull(getAllNotificationHubAuthorizationRulesResponse);
<<<<<<< HEAD
                Assert.NotNull(getAllNotificationHubAuthorizationRulesResponse.Value);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Value.Count > 1);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Value.Any(ns => ns.Name == authorizationRuleName));

                //Update notificationHub authorizationRule 
                var updateNotificationHubAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters(getNotificationHubAuthorizationRulesResponse.Value.Properties);
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                updateNotificationHubAuthorizationRuleParameter.Properties.Rights = new List<AccessRights>() { AccessRights.Listen };
                updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey = updatePrimaryKey;
=======
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));

                //Update notificationHub authorizationRule 
                var updateNotificationHubAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Location = location,
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen },
                    }
                };
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var updateNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, updateNotificationHubAuthorizationRuleParameter);

                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse);
<<<<<<< HEAD
                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, updateNotificationHubAuthorizationRuleResponse.Value.Name);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Value.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(updateNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
=======
                Assert.Equal(authorizationRuleName, updateNotificationHubAuthorizationRuleResponse.Name);
                Assert.True(updateNotificationHubAuthorizationRuleResponse.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNotificationHubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the updated notificationHub AuthorizationRule
                var getNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRuleResponse);
<<<<<<< HEAD
                Assert.NotNull(getNotificationHubAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, getNotificationHubAuthorizationRuleResponse.Value.Name);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Value.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
=======
                Assert.Equal(authorizationRuleName, getNotificationHubAuthorizationRuleResponse.Name);
                Assert.True(getNotificationHubAuthorizationRuleResponse.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                }

                //Get the connectionString to the namespace for a Authorization rule created at notificationHub level
                var listKeysResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
<<<<<<< HEAD
                Assert.NotNull(listKeysResponse.PrimaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey));
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Value.Properties.SecondaryKey));

                //Delete notificationHub authorizationRule
                var deleteResponse = NotificationHubsManagementClient.NotificationHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);
=======
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.True(listKeysResponse.PrimaryConnectionString.Contains(listKeysResponse.PrimaryKey));
                Assert.True(listKeysResponse.SecondaryConnectionString.Contains(listKeysResponse.SecondaryKey));

                var policyKey = new PolicykeyResource()
                {
                    PolicyKey = "primary KEY"
                };

                var regenerateKeys = NotificationHubsManagementClient.NotificationHubs.RegenerateKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName, policyKey);
                Assert.NotNull(regenerateKeys);
                Assert.Equal(regenerateKeys.KeyName, authorizationRuleName);
                Assert.NotNull(regenerateKeys.PrimaryConnectionString);
                Assert.NotNull(regenerateKeys.SecondaryConnectionString);
                Assert.True(regenerateKeys.PrimaryConnectionString.Contains(regenerateKeys.PrimaryKey));
                Assert.True(regenerateKeys.SecondaryConnectionString.Contains(regenerateKeys.SecondaryKey));
                //Bug : uncomment after the fix
                //Assert.Equal(regenerateKeys.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);
                Assert.NotEqual(regenerateKeys.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                Assert.Equal(regenerateKeys.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.NotEqual(regenerateKeys.PrimaryKey, listKeysResponse.PrimaryKey);

                //Get the connectionString to the notificationHub for a Authorization rule after regenerating the primary key 
                var listKeysAfterRegenerateResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(listKeysAfterRegenerateResponse);
                Assert.Equal(listKeysAfterRegenerateResponse.KeyName, authorizationRuleName);
                Assert.NotNull(listKeysAfterRegenerateResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysAfterRegenerateResponse.SecondaryConnectionString);
                Assert.True(listKeysAfterRegenerateResponse.PrimaryConnectionString.Contains(listKeysAfterRegenerateResponse.PrimaryKey));
                Assert.True(listKeysAfterRegenerateResponse.SecondaryConnectionString.Contains(listKeysAfterRegenerateResponse.SecondaryKey));
                Assert.Equal(listKeysAfterRegenerateResponse.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);
                Assert.NotEqual(listKeysAfterRegenerateResponse.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                Assert.Equal(listKeysAfterRegenerateResponse.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.NotEqual(listKeysAfterRegenerateResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(listKeysAfterRegenerateResponse.PrimaryKey, regenerateKeys.PrimaryKey);
                //Bug : uncomment after the fix
                //Assert.Equal(listKeysAfterRegenerateResponse.PrimaryConnectionString, regenerateKeys.PrimaryConnectionString);

                //Delete notificationHub authorizationRule
                NotificationHubsManagementClient.NotificationHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
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
    }
}
