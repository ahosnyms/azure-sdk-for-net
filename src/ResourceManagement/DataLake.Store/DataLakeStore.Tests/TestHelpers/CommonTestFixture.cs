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
using Microsoft.Azure.Test;
=======
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
using System;

namespace DataLakeStore.Tests
{
<<<<<<< HEAD
    public class CommonTestFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeStoreAccountName { get; set; }
        public string Location = "East US 2";
        
        public CommonTestFixture()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();

                var dataLakeStoreManagementHelper = new DataLakeStoreManagementHelper(this);
                dataLakeStoreManagementHelper.TryRegisterSubscriptionForResource();
                dataLakeStoreManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
                ResourceGroupName = TestUtilities.GenerateName("datalakerg1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
                dataLakeStoreManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
            }
            catch (Exception)
=======
    public class CommonTestFixture : TestBase
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeStoreAccountName { get; set; }
        public string NoPermissionDataLakeStoreAccountName { get; set; }
        public string DataLakeStoreFileSystemAccountName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "East US 2";
        public string AclUserId = "027c28d5-c91d-49f0-98c5-d10134b169b3";
        public DataLakeStoreFileSystemManagementClient DataLakeStoreFileSystemClient { get; set; }
        private MockContext context;
        public CommonTestFixture(MockContext contextToUse)
        {
            try
            {
                context = contextToUse;
                var dataLakeStoreAndFileSystemManagementHelper = new DataLakeStoreAndFileSystemManagementHelper(this, context);
                dataLakeStoreAndFileSystemManagementHelper.TryRegisterSubscriptionForResource();
                dataLakeStoreAndFileSystemManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
                ResourceGroupName = TestUtilities.GenerateName("datalakerg1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
                DataLakeStoreFileSystemAccountName = TestUtilities.GenerateName("testadlfs1");
                dataLakeStoreAndFileSystemManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);

                // create the DataLake account in the resource group and establish the host URL to use.
                this.HostUrl =
                    dataLakeStoreAndFileSystemManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName,
                        this.Location, this.DataLakeStoreFileSystemAccountName);
                if(this.HostUrl.ToUpperInvariant().Contains("CABOACCOUNTDOGFOOD.NET"))
                {
                    NoPermissionDataLakeStoreAccountName = "adlsaccesstest01";
                }
                else
                {
                    NoPermissionDataLakeStoreAccountName = "fluffykittens";
                }
            }
            catch
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            {
                Cleanup();
                throw;
            }
<<<<<<< HEAD
            finally
            {
                TestUtilities.EndTest();
            }
        }

        public void Dispose()
        {
            Cleanup();    
        }
        private void Cleanup()
        {
            UndoContext.Current.UndoAll();
=======
        }

        private void Cleanup()
        {
            if(context != null )
            {
                context.Dispose();
            }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }
    }
}
