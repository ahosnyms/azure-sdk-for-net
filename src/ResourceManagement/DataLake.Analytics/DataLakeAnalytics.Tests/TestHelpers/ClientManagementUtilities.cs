using Microsoft.Azure.Management.DataLake;
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
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Store;
<<<<<<< HEAD
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
=======
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

namespace DataLakeAnalytics.Tests
{
    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A bigAnalytics management client, created from the current context (environment variables)</returns>
<<<<<<< HEAD
        public static IDataLakeAnalyticsManagementClient GetDataLakeAnalyticsManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<DataLakeAnalyticsManagementClient>(new CSMTestEnvironmentFactory());
=======
        public static DataLakeAnalyticsAccountManagementClient GetDataLakeAnalyticsAccountManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<DataLakeAnalyticsAccountManagementClient>();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
<<<<<<< HEAD
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
=======
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A storage management client, created from the current context (environment variables)</returns>
<<<<<<< HEAD
        public static StorageManagementClient GetStorageManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<StorageManagementClient>(new CSMTestEnvironmentFactory());
=======
        public static StorageManagementClient GetStorageManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A dataLake management client, created from the current context (environment variables)</returns>
<<<<<<< HEAD
        public static DataLakeStoreManagementClient GetDataLakeStoreManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<DataLakeStoreManagementClient>(new CSMTestEnvironmentFactory());
=======
        public static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>();
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Data Lake analytics catalog management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<DataLakeAnalyticsCatalogManagementClient>(true);
            
            // reset back to the default to ensure the logic works as expected.
            client.AdlaCatalogDnsSuffix = TestEnvironmentFactory.GetTestEnvironment().Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A bigAnalytics management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<DataLakeAnalyticsJobManagementClient>(true);

            // reset back to the default to ensure the logic works as expected.
            client.AdlaJobDnsSuffix = TestEnvironmentFactory.GetTestEnvironment().Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return client;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }
    }
}
