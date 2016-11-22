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
using Microsoft.Azure.Test;
<<<<<<< HEAD
=======
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
using System;

namespace DataLakeAnalytics.Tests
{
    public class CommonTestFixture : TestBase
    {
<<<<<<< HEAD
        public string ResourceGroupName { set; get; }
=======
        internal const string SchemaName = "dbo";

        public string ResourceGroupName { set; get; }
        public string SecondDataLakeAnalyticsAccountName { get; set; }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        public string DataLakeAnalyticsAccountName { get; set; }
        public string SecondDataLakeStoreAccountName { get; set; }
        public string StorageAccountAccessKey { get; set; }
        public string StorageAccountSuffix { get; set; }
        public string StorageAccountName { get; set; }
        public string SecondDataLakeStoreAccountSuffix { get; set; }
        public string DataLakeStoreAccountName { get; set; }
        public string DataLakeStoreAccountSuffix { get; set; }
<<<<<<< HEAD
        public string Location = "East US 2";

        public CommonTestFixture()
        {
            var bigAnalyticsManagementHelper = new DataLakeAnalyticsManagementHelper(this);
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource();
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.DataLake");
            ResourceGroupName = TestUtilities.GenerateName("rgaba1");
            DataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba1");
            SecondDataLakeStoreAccountName = TestUtilities.GenerateName("teststorage1");
            DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
            SecondDataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake2");
            StorageAccountName = TestUtilities.GenerateName("testazureblob1");
            bigAnalyticsManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
            
            string storageSuffix;
            this.StorageAccountAccessKey = bigAnalyticsManagementHelper.TryCreateStorageAccount(this.ResourceGroupName, this.StorageAccountName, "DataLakeAnalyticsTestStorage", "DataLakeAnalyticsTestStorageDescription", this.Location, out storageSuffix);
            this.StorageAccountSuffix = storageSuffix;

            this.DataLakeStoreAccountSuffix = bigAnalyticsManagementHelper.TryCreateDataLakeAccount(this.ResourceGroupName, this.DataLakeStoreAccountName, this.Location);
            this.SecondDataLakeStoreAccountSuffix = bigAnalyticsManagementHelper.TryCreateDataLakeAccount(this.ResourceGroupName, this.SecondDataLakeStoreAccountName, this.Location);
=======
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string TvfName { get; set; }
        public string ViewName { get; set; }
        public string ProcName { get; set; }
        public string SecretName { get; set; }
        public string SecretPwd { get; set; }
        public string CredentialName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "East US 2";
        public DataLakeAnalyticsManagementHelper DataLakeAnalyticsManagementHelper { get; set; }
        private MockContext context;
        public CommonTestFixture(MockContext contextToUse, bool createWasbAccount = false, bool isDogfood = false)
        {
            if(isDogfood)
            {
                Location = "Brazil South";
            }

            try 
            {
                context = contextToUse;
                DataLakeAnalyticsManagementHelper = new DataLakeAnalyticsManagementHelper(this, context);
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource();
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.DataLakeStore");
                ResourceGroupName = TestUtilities.GenerateName("rgaba1");
                DataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba1");
                SecondDataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba2");
                SecondDataLakeStoreAccountName = TestUtilities.GenerateName("teststorage1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
                SecondDataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake2");
                StorageAccountName = TestUtilities.GenerateName("testazureblob1");
                DatabaseName = TestUtilities.GenerateName("testdb1");
                TableName = TestUtilities.GenerateName("testtbl1");
                TvfName = TestUtilities.GenerateName("testtvf1");
                ProcName = TestUtilities.GenerateName("testproc1");
                ViewName = TestUtilities.GenerateName("testview1");
                CredentialName = TestUtilities.GenerateName("testcred1");
                SecretName = TestUtilities.GenerateName("testsecret1");
                SecretPwd = TestUtilities.GenerateName("testsecretpwd1");
                DataLakeAnalyticsManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
                if (createWasbAccount)
                {
                    string storageSuffix;
                    this.StorageAccountAccessKey = DataLakeAnalyticsManagementHelper.TryCreateStorageAccount(this.ResourceGroupName, this.StorageAccountName, "DataLakeAnalyticsTestStorage", "DataLakeAnalyticsTestStorageDescription", this.Location, out storageSuffix);
                    this.StorageAccountSuffix = storageSuffix;
                }

                this.DataLakeStoreAccountSuffix = DataLakeAnalyticsManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName, this.Location, this.DataLakeStoreAccountName);
                this.SecondDataLakeStoreAccountSuffix = DataLakeAnalyticsManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName, this.Location, this.SecondDataLakeStoreAccountName);
            }
            catch
            {
                Cleanup();
                throw;
            }
        }

        private void Cleanup()
        {
            if (context != null)
            {
                context.Dispose();
            }
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }
    }
}
