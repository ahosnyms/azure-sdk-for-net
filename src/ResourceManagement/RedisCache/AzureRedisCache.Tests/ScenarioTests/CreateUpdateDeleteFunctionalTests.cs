// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class CreateUpdateDeleteFunctionalTests : TestBase, IClassFixture<TestsFixture>
    {
        private TestsFixture fixture;

        public CreateUpdateDeleteFunctionalTests(TestsFixture data)
        {
            fixture = data;
        }

        [Fact]
        public void CreateUpdateDeleteTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            { 
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                var responseCreate = _client.Redis.Create(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
<<<<<<< HEAD
=======
                                            Location = fixture.Location,
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 1
                                            }
                                        });

<<<<<<< HEAD
            Assert.True("creating".Equals(responseCreate.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
            Assert.Equal(SkuName.Basic, responseCreate.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, responseCreate.Resource.Properties.Sku.Family);
            Assert.Equal(1, responseCreate.Resource.Properties.Sku.Capacity);
            
            Assert.Contains(fixture.RedisCacheName, responseCreate.Resource.Properties.HostName);
            Assert.Equal(6379, responseCreate.Resource.Properties.Port);
            Assert.Equal(6380, responseCreate.Resource.Properties.SslPort);
            Assert.False(responseCreate.Resource.Properties.EnableNonSslPort.Value);
            
            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                RedisGetResponse responseGet = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                if ("succeeded".Equals(responseGet.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
            }
=======
                Assert.Contains(fixture.RedisCacheName, responseCreate.Id);
                Assert.Equal(fixture.Location, responseCreate.Location);
                Assert.Equal(fixture.RedisCacheName, responseCreate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseCreate.Type);

                Assert.True("succeeded".Equals(responseCreate.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Basic, responseCreate.Sku.Name);
                Assert.Equal(SkuFamily.C, responseCreate.Sku.Family);
                Assert.Equal(0, responseCreate.Sku.Capacity);
                
                Assert.Contains(fixture.RedisCacheName, responseCreate.HostName);
                Assert.Equal(6379, responseCreate.Port);
                Assert.Equal(6380, responseCreate.SslPort);
                Assert.False(responseCreate.EnableNonSslPort);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var responseUpdate = _client.Redis.Update(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisUpdateParameters
                                        {
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 1
                                            },
                                            RedisConfiguration = new Dictionary<string, string>() {
                                                    {"maxmemory-policy","allkeys-lru"}
                                            },
                                            EnableNonSslPort = true
                                        });

                Assert.Contains(fixture.RedisCacheName, responseUpdate.Id);
                Assert.Equal(fixture.Location, responseUpdate.Location);
                Assert.Equal(fixture.RedisCacheName, responseUpdate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseUpdate.Type);

<<<<<<< HEAD
            Assert.Equal(SkuName.Basic, responseUpdate.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, responseUpdate.Resource.Properties.Sku.Family);
            Assert.Equal(1, responseUpdate.Resource.Properties.Sku.Capacity);
            Assert.Equal("allkeys-lru", responseUpdate.Resource.Properties.RedisConfiguration["maxmemory-policy"]);
=======
                Assert.Equal(SkuName.Basic, responseUpdate.Sku.Name);
                Assert.Equal(SkuFamily.C, responseUpdate.Sku.Family);
                Assert.Equal(0, responseUpdate.Sku.Capacity);
                Assert.Equal("allkeys-lru", responseUpdate.RedisConfiguration["maxmemory-policy"]);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.Contains(fixture.RedisCacheName, responseUpdate.HostName);
                Assert.Equal(6379, responseUpdate.Port);
                Assert.Equal(6380, responseUpdate.SslPort);
                Assert.True(responseUpdate.EnableNonSslPort);

                _client.Redis.Delete(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            }
        }

        [Fact]
        public void CreateUpdateDeleteClusterCacheTest()
        {
            TestUtilities.StartTest();

            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);

            RedisCreateOrUpdateResponse responseCreate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisClusterCacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = fixture.ClusterCacheLocation,
                                        Properties = new RedisProperties
                                        {
                                            RedisVersion = "3.0",
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            },
                                            ShardCount = 2,
                                            TenantSettings = new Dictionary<string, string>() { {"some-key","some-value"} }
                                        }
                                    });

            Assert.Contains(fixture.RedisClusterCacheName, responseCreate.Resource.Id);
            Assert.Equal(fixture.ClusterCacheLocation, responseCreate.Resource.Location);
            Assert.Equal(fixture.RedisClusterCacheName, responseCreate.Resource.Name);
            Assert.True("creating".Equals(responseCreate.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
            Assert.Equal(SkuName.Premium, responseCreate.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.P, responseCreate.Resource.Properties.Sku.Family);
            Assert.Equal(1, responseCreate.Resource.Properties.Sku.Capacity);
            Assert.Contains(fixture.RedisClusterCacheName, responseCreate.Resource.Properties.HostName);
            Assert.Equal(6379, responseCreate.Resource.Properties.Port);
            Assert.Equal(6380, responseCreate.Resource.Properties.SslPort);
            Assert.False(responseCreate.Resource.Properties.EnableNonSslPort.Value);
            Assert.Equal(2, responseCreate.Resource.Properties.ShardCount.Value);
            Assert.Equal("some-value", responseCreate.Resource.Properties.TenantSettings["some-key"]);

            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                RedisGetResponse responseGet = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisClusterCacheName);
                if ("succeeded".Equals(responseGet.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
            }

            RedisCreateOrUpdateResponse responseUpdate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisClusterCacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = fixture.ClusterCacheLocation,
                                        Properties = new RedisProperties
                                        {
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            },
                                            TenantSettings = new Dictionary<string, string>() { { "some-key-1", "some-value-1" } }
                                        }
                                    });

            Assert.Equal("some-value-1", responseUpdate.Resource.Properties.TenantSettings["some-key-1"]);
            
            AzureOperationResponse responseDelete = _client.Redis.Delete(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisClusterCacheName);

            List<HttpStatusCode> acceptedStatusCodes = new List<HttpStatusCode>();
            acceptedStatusCodes.Add(HttpStatusCode.OK);
            acceptedStatusCodes.Add(HttpStatusCode.Accepted);
            acceptedStatusCodes.Add(HttpStatusCode.NotFound);

            Assert.Contains<HttpStatusCode>(responseDelete.StatusCode, acceptedStatusCodes);
            Assert.NotNull(responseDelete.RequestId);

            TestUtilities.EndTest();
        }
    }
}
