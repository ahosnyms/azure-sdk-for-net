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

<<<<<<< HEAD
using Microsoft.Azure;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ResourceGroups.Tests;
using Storage.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace Storage.Tests
{
    public class StorageAccountTests
    {
        [Fact]
        public void StorageAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Make sure a second create returns immediately
                var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create storage account with only required params
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountCreateWithEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } },
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Verify encryption settings
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);
            }
        }

        [Fact]
        public void StorageAccountCreateWithAccessTierTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with hot
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.BlobStorage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    AccessTier = AccessTier.Hot
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.Equal(AccessTier.Hot, account.AccessTier);
                Assert.Equal(Kind.BlobStorage, account.Kind);

                // Create storage account with cool
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.BlobStorage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    AccessTier = AccessTier.Cool
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.Equal(AccessTier.Cool, account.AccessTier);
                Assert.Equal(Kind.BlobStorage, account.Kind);
            }
        }

        [Fact]
        public void StorageAccountBeginCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var response = storageMgmtClient.StorageAccounts.BeginCreate(rgname, accountName, parameters);
            }
        }

        [Fact]
        public void StorageAccountBeginCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                StorageAccountCreateResponse response = storageMgmtClient.StorageAccounts.BeginCreate(rgname, accountName, parameters);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

                // Poll for creation
                while (response.StatusCode == HttpStatusCode.Accepted)
                {
                    TestUtilities.Wait(response.RetryAfter * 1000);
                    response = storageMgmtClient.GetCreateOperationStatus(response.OperationStatusLink);
                }

                // Verify create succeeded
                StorageAccount result = response.StorageAccount;
                Assert.Equal(result.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(result.AccountType, AccountType.StandardGRS);
                Assert.Equal(result.Tags.Count, 2);

                // Make sure a second create returns immediately
                response = storageMgmtClient.StorageAccounts.BeginCreate(rgname, accountName, parameters);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Verify create succeeded
                Assert.Equal(result.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(result.AccountType, AccountType.StandardGRS);
                Assert.Equal(result.Tags.Count, 2);
            }
        }

        [Fact]
        public void StorageAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                storageMgmtClient.StorageAccounts.Delete(rgname, "missingaccount");

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Delete an account
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void StorageAccountGetStandardTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create and get a RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardRAGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a ZRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardZRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountGetBlobTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a blob LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardLRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardGRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardRAGRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountGetPremiumTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a Premium LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.PremiumLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create storage accounts
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                StorageManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                StorageManagementTestUtilities.VerifyAccountProperties(accounts.ToArray()[1], true);
            }
        }

        [Fact]
        public void StorageAccountListWithEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption()
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } },
                };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                // List account and verify
                var accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(1, accounts.Count());

                var account = accounts.ToArray()[0];
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);
            }
        }

        [Fact]
        public void StorageAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group and storage account
                var rgname1 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname1);

                // Create different resource group and storage account
                var rgname2 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname2);

                var accounts = storageMgmtClient.StorageAccounts.List();

                StorageAccount account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                StorageManagementTestUtilities.VerifyAccountProperties(account1, true);

                StorageAccount account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                StorageManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void StorageAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

<<<<<<< HEAD
                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(listKeysRequest.StorageAccountKeys.Key1);
                Assert.NotNull(listKeysRequest.StorageAccountKeys.Key2);

                // Regenerate keys
                var regenRequest1 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1");
                var regenRequest2 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");

                // Verify listed keys are the same as keys returned by the regenerate request
                listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest1.StorageAccountKeys.Key1, listKeysRequest.StorageAccountKeys.Key1);
                Assert.Equal(regenRequest2.StorageAccountKeys.Key2, listKeysRequest.StorageAccountKeys.Key2);
=======
                // List keys
                var keys = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                StorageAccountKey key1 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key1"));
                Assert.NotNull(key1);
                Assert.Equal(KeyPermission.FULL, key1.Permissions);
                Assert.NotNull(key1.Value);

                // Validate Key2
                StorageAccountKey key2 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);
                Assert.Equal(KeyPermission.FULL, key2.Permissions);
                Assert.NotNull(key2.Value);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        [Fact]
        public void StorageAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

<<<<<<< HEAD
                // Regenerate keys
                var regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1");
                Assert.NotNull(regenRequest.StorageAccountKeys.Key1);
                Assert.NotNull(regenRequest.StorageAccountKeys.Key2);

                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest.StorageAccountKeys.Key1, listKeysRequest.StorageAccountKeys.Key1);
                Assert.Equal(regenRequest.StorageAccountKeys.Key2, listKeysRequest.StorageAccountKeys.Key2);

                // Regenerate keys and verify that keys change
                regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");
                Assert.Equal(regenRequest.StorageAccountKeys.Key1, listKeysRequest.StorageAccountKeys.Key1);
                Assert.NotEqual(regenRequest.StorageAccountKeys.Key2, listKeysRequest.StorageAccountKeys.Key2);
=======
                // List keys
                var keys = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                StorageAccountKey key2 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");
                StorageAccountKey key2Regen = regenKeys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2.Value, key2Regen.Value);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        [Fact]
        public void StorageAccountCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

<<<<<<< HEAD
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

=======
                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                // Check valid name
                string accountName = TestUtilities.GenerateName("sto");
                var checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.Equal(true, checkNameRequest.NameAvailable);
                Assert.Null(checkNameRequest.Reason);
                Assert.Null(checkNameRequest.Message);

                // Check invalid name
                accountName = "CAPS";
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.Equal(false, checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AccountNameInvalid, checkNameRequest.Reason);
                Assert.Equal("CAPS is not a valid storage account name. Storage account name must be between 3 and 24 "
                    + "characters in length and use numbers and lower-case letters only.", checkNameRequest.Message);
                
                // Check name of account that already exists
                accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AlreadyExists, checkNameRequest.Reason);
                Assert.Equal("The storage account named " + accountName + " is already taken.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void StorageAccountUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

<<<<<<< HEAD
=======
                // Update storage account type
                var parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Kind = Kind.Storage,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Update storage tags
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } }
                    }
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                // Update storage custom domains
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    CustomDomain = new CustomDomain
                    {
                        Name = "foo.example.com",
                        UseSubDomain = true
                    }
                };

                try
                {
                    storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Body.Code);
                    Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }

        [Fact]
        public void StorageAccountUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
<<<<<<< HEAD
                
                var updateAccountTypeRequest = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(updateAccountTypeRequest.StorageAccount.AccountType, AccountType.StandardLRS);

                var getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(getRequest.StorageAccount.AccountType, AccountType.StandardLRS);
                
=======
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                // Update storage tags
                parameters = new StorageAccountUpdateParameters
                {
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } }
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                // Update storage custom domains
                parameters = new StorageAccountUpdateParameters
                {
                    CustomDomain = new CustomDomain
                    {
                        Name = "foo.example.com",
                        UseSubDomain = true
                    }
                };

                try
                {
                    storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
<<<<<<< HEAD
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Error.Code);
                    Assert.True(ex.Error.Message != null && ex.Error.Message.StartsWith("The custom domain " + 
=======
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Body.Code);
                    Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " +
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }

        [Fact]
<<<<<<< HEAD
        public void StorageAccountUsageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Query usage
                var usages = storageMgmtClient.Usage.List();
                Assert.Equal(1, usages.Count());
                Assert.Equal(UsageUnit.Count, usages.First().Unit);
                Assert.NotNull(usages.First().CurrentValue);
                Assert.Equal(100, usages.First().Limit);
                Assert.NotNull(usages.First().Name);
                Assert.Equal("StorageAccounts", usages.First().Name.Value);
                Assert.Equal("Storage Accounts", usages.First().Name.LocalizedValue);
=======
        public void StorageAccountUpdateMultipleTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardLRS },
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        [Fact]
<<<<<<< HEAD
        public void StorageAccountGetOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);

                var resource = new ResourceIdentity();
                resource.ResourceProviderNamespace = "Microsoft.Storage";
                resource.ResourceProviderApiVersion = "2015-06-15";
                resource.ResourceName = "";
                resource.ResourceType = "";
                var ops = resourcesClient.ResourceProviderOperationDetails.List(resource);

                Assert.Equal(ops.ResourceProviderOperationDetails.Count, 7);
=======
        public void StorageAccountUsageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Query usage
                var usages = storageMgmtClient.Usage.List();
                Assert.Equal(1, usages.Value.Count());
                Assert.Equal(UsageUnit.Count, usages.Value.First().Unit);
                Assert.NotNull(usages.Value.First().CurrentValue);
                Assert.Equal(100, usages.Value.First().Limit);
                Assert.NotNull(usages.Value.First().Name);
                Assert.Equal("StorageAccounts", usages.Value.First().Name.Value);
                Assert.Equal("Storage Accounts", usages.Value.First().Name.LocalizedValue);
            }
        }

        // [Fact]
        public void StorageAccountGetOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var ops = resourcesClient.ResourceProviderOperationDetails.List("Microsoft.Storage", "2015-06-15");

                Assert.Equal(ops.Count(), 7);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }
    }
}