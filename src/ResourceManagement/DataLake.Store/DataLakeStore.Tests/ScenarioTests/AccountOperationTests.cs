//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using Microsoft.Azure;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Azure.Test;
<<<<<<< HEAD
=======
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
namespace DataLakeStore.Tests
{
<<<<<<< HEAD
    public class AccountOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {   
        private CommonTestFixture commonData;
        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;
        }
=======
    public class AccountOperationTests : TestBase
    {   
        private CommonTestFixture commonData;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
<<<<<<< HEAD
            TestUtilities.StartTest();
            var clientToUse = this.GetDataLakeStoreManagementClient();

            // Create a test account
            var responseCreate =
                clientToUse.DataLakeStoreAccount.Create(resourceGroupName: commonData.ResourceGroupName,
                    parameters: new DataLakeStoreAccountCreateOrUpdateParameters
                    {
                        DataLakeStoreAccount = new DataLakeStoreAccount
                        {
                            Name = commonData.DataLakeStoreAccountName,
                            Location = commonData.Location,
                            Tags = new Dictionary<string, string>
                            {
                                { "testkey","testvalue" }
                            }
                        }
                    });

            Assert.Equal(HttpStatusCode.OK, responseCreate.StatusCode);
            Assert.Equal(OperationStatus.Succeeded, responseCreate.Status);
            
            // get the account and ensure that all the values are properly set.
            var responseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

            // validate the account creation process
            Assert.True(responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Creating || responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);
            Assert.NotNull(responseCreate.RequestId);
            Assert.NotNull(responseGet.RequestId);
            Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Id);
            Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Properties.Endpoint);
            Assert.Equal(commonData.Location, responseGet.DataLakeStoreAccount.Location);
            Assert.Equal(commonData.DataLakeStoreAccountName, responseGet.DataLakeStoreAccount.Name);
            Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.DataLakeStoreAccount.Type);

            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (responseGet.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Succeeded && responseGet.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                responseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
            }

            // Confirm that the account creation did succeed
            Assert.True(responseGet.DataLakeStoreAccount.Properties.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);

            // Update the account and confirm the updates make it in.
            var newAccount = responseGet.DataLakeStoreAccount;
            newAccount.Tags = new Dictionary<string, string>
=======
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                var clientToUse = this.GetDataLakeStoreAccountManagementClient(context);

                // Create a test account
                var responseCreate =
                    clientToUse.Account.Create(resourceGroupName: commonData.ResourceGroupName, name: commonData.DataLakeStoreAccountName,
                        parameters: new DataLakeStoreAccount
                        {
                            Location = commonData.Location,
                            Tags = new Dictionary<string, string>
                            {
                            { "testkey","testvalue" }
                            },
                            Identity = new EncryptionIdentity(),
                            EncryptionConfig = new EncryptionConfig
                            {
                                Type = EncryptionConfigType.ServiceManaged
                            },
                            EncryptionState = EncryptionState.Enabled
                        });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseCreate.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                // validate the account creation process
                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseGet.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.Id);
                Assert.Contains(commonData.DataLakeStoreAccountName, responseGet.Endpoint);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(commonData.DataLakeStoreAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.Type);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (responseGet.ProvisioningState != DataLakeStoreAccountStatus.Succeeded && responseGet.ProvisioningState != DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
                }

                // Confirm that the account creation did succeed
                Assert.True(responseGet.ProvisioningState == DataLakeStoreAccountStatus.Succeeded);

                // Validate the encryption state is set
                Assert.Equal(EncryptionState.Enabled, responseGet.EncryptionState.GetValueOrDefault());
                Assert.True(responseGet.Identity.PrincipalId.HasValue);
                Assert.True(responseGet.Identity.TenantId.HasValue);
                Assert.Equal(EncryptionConfigType.ServiceManaged, responseGet.EncryptionConfig.Type);

                // Update the account and confirm the updates make it in.
                var newAccount = responseGet;
                newAccount.Tags = new Dictionary<string, string>
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            {
                {"updatedKey", "updatedValue"}
            };

<<<<<<< HEAD
            var updateResponse = clientToUse.DataLakeStoreAccount.Update(commonData.ResourceGroupName, new DataLakeStoreAccountCreateOrUpdateParameters
                {
                    DataLakeStoreAccount = new DataLakeStoreAccount
                    {
                        Name = newAccount.Name,
                        Tags = new Dictionary<string, string>
                        {
                            {"updatedKey", "updatedValue"}
                        }
                    }
                });

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
            Assert.Equal(OperationStatus.Succeeded, updateResponse.Status);

            var updateResponseGet = clientToUse.DataLakeStoreAccount.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

            Assert.NotNull(updateResponse.RequestId);
            Assert.Contains(responseGet.DataLakeStoreAccount.Id, updateResponseGet.DataLakeStoreAccount.Id);
            Assert.Equal(responseGet.DataLakeStoreAccount.Location, updateResponseGet.DataLakeStoreAccount.Location);
            Assert.Equal(newAccount.Name, updateResponseGet.DataLakeStoreAccount.Name);
            Assert.Equal(responseGet.DataLakeStoreAccount.Type, updateResponseGet.DataLakeStoreAccount.Type);

            // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
            Assert.True(updateResponseGet.DataLakeStoreAccount.Tags.SequenceEqual(newAccount.Tags));

            // Create another account and ensure that list account returns both
            var accountToChange = updateResponseGet.DataLakeStoreAccount;
            accountToChange.Name = accountToChange.Name + "acct2";
            var parameters = new DataLakeStoreAccountCreateOrUpdateParameters
            {
                DataLakeStoreAccount = accountToChange
            };

            clientToUse.DataLakeStoreAccount.Create(commonData.ResourceGroupName, parameters);

            DataLakeStoreAccountListResponse listResponse = clientToUse.DataLakeStoreAccount.List(commonData.ResourceGroupName, null);

            // Assert that there are at least two accounts in the list
            Assert.True(listResponse.Value.Count > 1);

            // Delete the account and confirm that it is deleted.
            AzureOperationResponse deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, newAccount.Name);

            // define the list of accepted status codes when deleting an account.
            List<HttpStatusCode> acceptedStatusCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Accepted,
                HttpStatusCode.NotFound,
                HttpStatusCode.NoContent
            };

            Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);
            Assert.NotNull(deleteResponse.RequestId);

            // delete the account again and make sure it continues to result in a succesful code.
            deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, newAccount.Name);
            Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

            // delete the account with its old name, which should also succeed.
            deleteResponse = clientToUse.DataLakeStoreAccount.Delete(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);
            Assert.Contains<HttpStatusCode>(deleteResponse.StatusCode, acceptedStatusCodes);

            TestUtilities.EndTest();
=======
                var updateResponse = clientToUse.Account.Update(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName,
                new DataLakeStoreAccountUpdateParameters
                {
                    Tags = new Dictionary<string, string>
                    {
                        {"updatedKey", "updatedValue"}
                    }
                });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, updateResponse.ProvisioningState);

                var updateResponseGet = clientToUse.Account.Get(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                Assert.NotNull(updateResponse.Id);
                Assert.Contains(responseGet.Id, updateResponseGet.Id);
                Assert.Equal(responseGet.Location, updateResponseGet.Location);
                Assert.Equal(newAccount.Name, updateResponseGet.Name);
                Assert.Equal(responseGet.Type, updateResponseGet.Type);

                // verify the new tags. NOTE: sequence equal is not ideal if we have more than 1 tag, since the ordering can change.
                Assert.True(updateResponseGet.Tags.SequenceEqual(newAccount.Tags));

                // Create another account and ensure that list account returns both
                var accountToChange = updateResponseGet;
                var newAcctName = accountToChange.Name + "acct2";

                clientToUse.Account.Create(commonData.ResourceGroupName, newAcctName, accountToChange);

                var listResponse = clientToUse.Account.List();

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // now list by resource group:
                listResponse = clientToUse.Account.ListByResourceGroup(commonData.ResourceGroupName);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 1);

                // test that the account exists
                Assert.True(clientToUse.Account.Exists(commonData.ResourceGroupName, newAccount.Name));

                // Delete the account and confirm that it is deleted.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account again and make sure it continues to result in a succesful code.
                clientToUse.Account.Delete(commonData.ResourceGroupName, newAccount.Name);

                // delete the account with its old name, which should also succeed.
                clientToUse.Account.Delete(commonData.ResourceGroupName, commonData.DataLakeStoreAccountName);

                // test that the account is gone
                Assert.False(clientToUse.Account.Exists(commonData.ResourceGroupName, newAccount.Name));
            }
        }
        [Fact]
        public void FirewallAndTrustedProviderTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                var clientToUse = this.GetDataLakeStoreAccountManagementClient(context);

                // Create a an account with trusted ID provider and firewall rules.
                var firewallStart = "127.0.0.1";
                var firewallEnd = "127.0.0.2";
                var firewallRuleName1 = TestUtilities.GenerateName("firerule1");

                var trustedId = TestUtilities.GenerateGuid();
                var trustedUrl = string.Format("https://sts.windows.net/{0}", trustedId.ToString());
                var trustedIdName = TestUtilities.GenerateName("trustedrule1");

                var adlsAccountName = TestUtilities.GenerateName("adlsacct");
                
                var responseCreate =
                    clientToUse.Account.Create(resourceGroupName: commonData.ResourceGroupName, name: adlsAccountName,
                        parameters: new DataLakeStoreAccount
                        {
                            Location = commonData.Location,
                            FirewallRules = new List<FirewallRule>
                            {
                                new FirewallRule(firewallStart, firewallEnd, name: firewallRuleName1)
                            },
                            TrustedIdProviders = new List<TrustedIdProvider>
                            {
                                new TrustedIdProvider(trustedUrl, name: trustedIdName)
                            },    
                            FirewallState = FirewallState.Enabled,
                            TrustedIdProviderState = TrustedIdProviderState.Enabled,
                            
                        });

                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseCreate.ProvisioningState);

                // get the account and ensure that all the values are properly set.
                var responseGet = clientToUse.Account.Get(commonData.ResourceGroupName, adlsAccountName);

                // validate the account creation process
                Assert.Equal(DataLakeStoreAccountStatus.Succeeded, responseGet.ProvisioningState);
                Assert.NotNull(responseCreate.Id);
                Assert.NotNull(responseGet.Id);
                Assert.Contains(adlsAccountName, responseGet.Id);
                Assert.Contains(adlsAccountName, responseGet.Endpoint);
                Assert.Equal(commonData.Location, responseGet.Location);
                Assert.Equal(adlsAccountName, responseGet.Name);
                Assert.Equal("Microsoft.DataLakeStore/accounts", responseGet.Type);

                // validate firewall state
                Assert.Equal(FirewallState.Enabled, responseGet.FirewallState);
                Assert.Equal(1, responseGet.FirewallRules.Count());
                Assert.Equal(firewallStart, responseGet.FirewallRules[0].StartIpAddress);
                Assert.Equal(firewallEnd, responseGet.FirewallRules[0].EndIpAddress);
                Assert.Equal(firewallRuleName1, responseGet.FirewallRules[0].Name);

                // validate trusted identity provider state
                Assert.Equal(TrustedIdProviderState.Enabled, responseGet.TrustedIdProviderState);
                Assert.Equal(1, responseGet.TrustedIdProviders.Count());
                Assert.Equal(trustedUrl, responseGet.TrustedIdProviders[0].IdProvider);
                Assert.Equal(trustedIdName, responseGet.TrustedIdProviders[0].Name);

                // Test getting the specific firewall rules
                var firewallRule = clientToUse.FirewallRules.Get(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);
                Assert.Equal(firewallStart, firewallRule.StartIpAddress);
                Assert.Equal(firewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);


                var updatedFirewallStart = "192.168.0.0";
                var updatedFirewallEnd = "192.168.0.1";
                firewallRule.StartIpAddress = updatedFirewallStart;
                firewallRule.EndIpAddress = updatedFirewallEnd;

                // Update the firewall rule to change the start/end ip addresses
                firewallRule = clientToUse.FirewallRules.CreateOrUpdate(commonData.ResourceGroupName, adlsAccountName,firewallRuleName1, firewallRule);
                Assert.Equal(updatedFirewallStart, firewallRule.StartIpAddress);
                Assert.Equal(updatedFirewallEnd, firewallRule.EndIpAddress);
                Assert.Equal(firewallRuleName1, firewallRule.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.FirewallRules.Delete(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);

                try
                {
                    firewallRule = clientToUse.FirewallRules.Get(commonData.ResourceGroupName, adlsAccountName, firewallRuleName1);
                    Assert.True(false, "Attempting to retrieve a deleted firewall rule did not throw.");
                }
                catch (CloudException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }

                // Test getting the specific trusted identity provider
                var trustedIdProvider = clientToUse.TrustedIdProviders.Get(commonData.ResourceGroupName, adlsAccountName, trustedIdName);
                Assert.Equal(trustedUrl, trustedIdProvider.IdProvider);
                Assert.Equal(trustedIdName, trustedIdProvider.Name);


                var updatedIdUrl = string.Format("https://sts.windows.net/{0}", TestUtilities.GenerateGuid().ToString());
                trustedIdProvider.IdProvider = updatedIdUrl;

                // Update the firewall rule to change the start/end ip addresses
                trustedIdProvider = clientToUse.TrustedIdProviders.CreateOrUpdate(commonData.ResourceGroupName, adlsAccountName, trustedIdName, trustedIdProvider);
                Assert.Equal(updatedIdUrl, trustedIdProvider.IdProvider);
                Assert.Equal(trustedIdName, trustedIdProvider.Name);

                // Remove the firewall rule and verify it is gone.
                clientToUse.TrustedIdProviders.Delete(commonData.ResourceGroupName, adlsAccountName, trustedIdName);

                try
                {
                    trustedIdProvider = clientToUse.TrustedIdProviders.Get(commonData.ResourceGroupName, adlsAccountName, trustedIdName);
                    Assert.True(false, "Attempting to retrieve a deleted trusted identity provider did not throw.");
                }
                catch (CloudException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }
    }
}
