﻿// 
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
>>>>>>> origin/AutoRest
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
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                Assert.Equal(createRequest.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(createRequest.AccountType, AccountType.StandardGRS);
                Assert.Equal(createRequest.Tags.Count, 2);

                // Make sure a second create returns immediately
                var createTask = storageMgmtClient.StorageAccounts.CreateWithHttpMessagesAsync(rgname, accountName, parameters);
                createTask.Wait();
                Assert.Equal(createTask.Result.Response.StatusCode, HttpStatusCode.OK);

                // Create storage account with only required params
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    AccountType = AccountType.StandardGRS,
                    Location = StorageManagementTestUtilities.DefaultLocation
                };
                createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                Assert.Equal(createRequest.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(createRequest.AccountType, AccountType.StandardGRS);
                Assert.Null(createRequest.Tags);
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
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

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
        public void StorageAccountGetTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                //Create and get a LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);

                // Create and get a GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, true);

                // Create and get a RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardRAGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);
               
                // Create and get a ZRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardZRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);

                // Create and get a Premium LRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);
            }
        }

        [Fact]
        public void StorageAccountListByResourceGroupTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var listAccountsRequest = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Empty(listAccountsRequest);

                // Create storage accounts
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                listAccountsRequest = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(2, listAccountsRequest.Count());

                StorageManagementTestUtilities.VerifyAccountProperties(listAccountsRequest.First(), true);
                StorageManagementTestUtilities.VerifyAccountProperties(listAccountsRequest.ToArray()[1], true);
            }
        }

        [Fact]
        public void StorageAccountListBySubscriptionTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group and storage account
                var rgname1 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname1);

                // Create different resource group and storage account
                var rgname2 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname2);

                var listAccountsRequest = storageMgmtClient.StorageAccounts.List();

                StorageAccount account1 = listAccountsRequest.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                StorageManagementTestUtilities.VerifyAccountProperties(account1, true);

                StorageAccount account2 = listAccountsRequest.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                StorageManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void StorageAccountListKeysTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(listKeysRequest.Key1);
                Assert.NotNull(listKeysRequest.Key2);

                // Regenerate keys
<<<<<<< HEAD
                var regenRequest1 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1");
                var regenRequest2 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");
=======
                var regenRequest1 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1" );
                var regenRequest2 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2" );
>>>>>>> origin/AutoRest

                // Verify listed keys are the same as keys returned by the regenerate request
                listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest1.Key1, listKeysRequest.Key1);
                Assert.Equal(regenRequest2.Key2, listKeysRequest.Key2);
            }
        }

        [Fact]
        public void StorageAccountRegenerateKeyTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Regenerate keys
<<<<<<< HEAD
                var regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1");
                Assert.NotNull(regenRequest.StorageAccountKeys.Key1);
                Assert.NotNull(regenRequest.StorageAccountKeys.Key2);
=======
                var regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key1" );
                Assert.NotNull(regenRequest.Key1);
                Assert.NotNull(regenRequest.Key2);
>>>>>>> origin/AutoRest

                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest.Key1, listKeysRequest.Key1);
                Assert.Equal(regenRequest.Key2, listKeysRequest.Key2);

                // Regenerate keys and verify that keys change
<<<<<<< HEAD
                regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");
                Assert.Equal(regenRequest.StorageAccountKeys.Key1, listKeysRequest.StorageAccountKeys.Key1);
                Assert.NotEqual(regenRequest.StorageAccountKeys.Key2, listKeysRequest.StorageAccountKeys.Key2);
=======
                regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2" );
                Assert.Equal(regenRequest.Key1, listKeysRequest.Key1);
                Assert.NotEqual(regenRequest.Key2, listKeysRequest.Key2);
>>>>>>> origin/AutoRest
            }
        }

        [Fact]
        public void StorageAccountCheckNameTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

<<<<<<< HEAD
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

=======
                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                
>>>>>>> origin/AutoRest
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
        public void StorageAccountUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    AccountType = AccountType.StandardLRS
                };
<<<<<<< HEAD
                
=======

>>>>>>> origin/AutoRest
                var updateAccountTypeRequest = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(updateAccountTypeRequest.AccountType, AccountType.StandardLRS);

                var getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
<<<<<<< HEAD
                Assert.Equal(getRequest.StorageAccount.AccountType, AccountType.StandardLRS);
                
=======
                Assert.Equal(getRequest.AccountType, AccountType.StandardLRS);

>>>>>>> origin/AutoRest
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

                var updateTagsRequest = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(updateTagsRequest.Tags.Count, parameters.Tags.Count);
                Assert.Equal(updateTagsRequest.Tags.ElementAt(0), parameters.Tags.ElementAt(0));

                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(getRequest.Tags.Count, parameters.Tags.Count);

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
>>>>>>> origin/AutoRest
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }

        [Fact]
        public void StorageAccountUsageTest()
        {
<<<<<<< HEAD
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);
=======
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler1);
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler2);
>>>>>>> origin/AutoRest

                // Query usage
                var usages = storageMgmtClient.Usage.List();
                Assert.Equal(1, usages.Count());
                Assert.Equal(UsageUnit.Count, usages.First().Unit);
                Assert.NotNull(usages.First().CurrentValue);
                Assert.Equal(100, usages.First().Limit);
                Assert.NotNull(usages.First().Name);
                Assert.Equal("StorageAccounts", usages.First().Name.Value);
                Assert.Equal("Storage Accounts", usages.First().Name.LocalizedValue);
            }
        }

<<<<<<< HEAD
        [Fact]
=======
        // [Fact]
>>>>>>> origin/AutoRest
        public void StorageAccountGetOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

<<<<<<< HEAD
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var ops = resourcesClient.ProviderOperationsMetadata.Get("Microsoft.Storage", "2015-06-15");

                Assert.Equal(ops.Operations.Count, 7);
>>>>>>> origin/AutoRest
            }
        }
    }
}