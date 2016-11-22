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

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Dns;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    using Rest.Azure;
    using Rest.ClientRuntime.Azure.TestFramework;

    public class RecordSetScenarioTests
    {
        public class SingleRecordSetTestContext
        {
            public string ZoneName { get; set; }

            public string RecordSetName { get; set; }

            public string Location { get; set; }

            public ResourceGroup ResourceGroup { get; set; }

            public DnsManagementClient DnsClient { get; set; }

            public RecordedDelegatingHandler DnsHandler { get; set; }

            public RecordedDelegatingHandler ResourcesHandler { get; set; }

            public RecordSet TestRecordSkeleton
                => this.GetNewTestRecordSkeleton(this.RecordSetName);

            public RecordSet GetNewTestRecordSkeleton(
                string recordSetName,
                uint ttl = 42)
            {
                return new RecordSet
                {
                    Name = recordSetName,
                    Etag = null,
                    TTL = ttl,
                };
            }
        }

        private static SingleRecordSetTestContext SetupSingleRecordSetTest(
            MockContext context)
        {
            var testContext = new SingleRecordSetTestContext();
<<<<<<< HEAD
            testContext.ZoneName = TestUtilities.GenerateName("hydratestdnszone.com");
            testContext.RecordSetName = TestUtilities.GenerateName("hydratestdnsrec");
            testContext.Location = ResourceGroupHelper.GetResourceLocation(ResourceGroupHelper.GetResourcesClient(), "microsoft.network/dnszones");
            testContext.ResourceGroup = ResourceGroupHelper.CreateResourceGroup();
            testContext.DnsClient = ResourceGroupHelper.GetDnsClient();
            ResourceGroupHelper.CreateZone(testContext.DnsClient, testContext.ZoneName, testContext.Location, testContext.ResourceGroup);
=======
            testContext.ResourcesHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };
            testContext.DnsHandler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };
            testContext.DnsClient = ResourceGroupHelper.GetDnsClient(
                context,
                testContext.DnsHandler);
            var resourceManagementClient =
                ResourceGroupHelper.GetResourcesClient(
                    context,
                    testContext.ResourcesHandler);
            testContext.ZoneName =
                TestUtilities.GenerateName("hydratest.dnszone.com");
            testContext.RecordSetName =
                TestUtilities.GenerateName("hydratestdnsrec");
            testContext.Location =
                ResourceGroupHelper.GetResourceLocation(
                    resourceManagementClient,
                    "microsoft.network/dnszones");
            testContext.ResourceGroup =
                ResourceGroupHelper.CreateResourceGroup(
                    resourceManagementClient);
            ResourceGroupHelper.CreateZone(
                testContext.DnsClient,
                testContext.ZoneName,
                testContext.Location,
                testContext.ResourceGroup);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            return testContext;
        }

        [Fact]
        public void CrudRecordSetFullCycle()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                SingleRecordSetTestContext testContext =
                    SetupSingleRecordSetTest(context);
                var recordSetToBeCreated = testContext.TestRecordSkeleton;
                recordSetToBeCreated.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "123.32.1.0"}
                };
                recordSetToBeCreated.TTL = 60;

                // Create the records clean, verify response
<<<<<<< HEAD
                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);
=======
                var createResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: recordSetToBeCreated);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.True(
                    TestHelpers.AreEqual(
                        recordSetToBeCreated,
                        createResponse,
                        ignoreEtag: true),
                    "Response body of Create does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(createResponse.Etag));

                // Retrieve the zone after create, verify response
                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.A);

                Assert.True(
                    TestHelpers.AreEqual(
                        createResponse,
                        getresponse,
                        ignoreEtag: false),
                    "Response body of Get does not match expectations");

                // Call Update on the object returned by Create (important distinction from Get below)
<<<<<<< HEAD
                Models.RecordSet createdRecordSet = createResponse.RecordSet;

                createdRecordSet.Properties.Ttl = 120;
                createdRecordSet.Properties.Metadata = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } };
                createdRecordSet.Properties.ARecords = new List<ARecord> 
                { 
                    new ARecord { Ipv4Address = "123.32.1.0" }, 
                    new ARecord { Ipv4Address = "101.10.0.1" } 
                };

                RecordSetCreateOrUpdateResponse updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new RecordSetCreateOrUpdateParameters { RecordSet = createdRecordSet });
=======
                Models.RecordSet createdRecordSet = createResponse;

                createdRecordSet.TTL = 120;
                createdRecordSet.Metadata = new Dictionary<string, string>
                {
                    {"tag1", "value1"},
                    {"tag2", "value2"}
                };
                createdRecordSet.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "123.32.1.0"},
                    new ARecord {Ipv4Address = "101.10.0.1"}
                };

                var updateResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: createdRecordSet);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.True(
                    TestHelpers.AreEqual(
                        createdRecordSet,
                        updateResponse,
                        ignoreEtag: true),
                    "Response body of Update does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(updateResponse.Etag));

                // Retrieve the records after create, verify response
                getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.A);

                Assert.True(
                    TestHelpers.AreEqual(updateResponse, getresponse),
                    "Response body of Get does not match expectations");

                // Call Update on the object returned by Get (important distinction from Create above)
<<<<<<< HEAD
                Models.RecordSet retrievedRecordSet = getresponse.RecordSet;
                retrievedRecordSet.Properties.Ttl = 180;
                retrievedRecordSet.Properties.ARecords = new List<ARecord> 
                { 
                    new ARecord { Ipv4Address = "123.32.1.0" }, 
                    new ARecord { Ipv4Address = "101.10.0.1" },
                    new ARecord { Ipv4Address = "22.33.44.55" },
                };

                updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: new RecordSetCreateOrUpdateParameters { RecordSet = retrievedRecordSet });
=======
                Models.RecordSet retrievedRecordSet = getresponse;
                retrievedRecordSet.TTL = 180;
                retrievedRecordSet.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "123.32.1.0"},
                    new ARecord {Ipv4Address = "101.10.0.1"},
                    new ARecord {Ipv4Address = "22.33.44.55"},
                };

                updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate
                    (
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.A,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: retrievedRecordSet);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.True(
                    TestHelpers.AreEqual(
                        retrievedRecordSet,
                        updateResponse,
                        ignoreEtag: true),
                    "Response body of Update does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(updateResponse.Etag));

                // Delete the record set
<<<<<<< HEAD
                AzureOperationResponse deleteResponse = testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName, 
                    testContext.RecordSetName, 
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Delete the zone
                deleteResponse = testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name, 
                    testContext.ZoneName,
                    ifMatch: null, 
=======
                testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.A,
                    ifMatch: null,
                    ifNoneMatch: null);

                // Delete the zone
                var deleteResponse = testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    ifMatch: null,
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                    ifNoneMatch: null);
            }
        }

        [Fact]
        public void CreateGetA()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.ARecords = new List<ARecord>
                {
                    new ARecord {Ipv4Address = "120.63.230.220"},
                    new ARecord {Ipv4Address = "4.3.2.1"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.A, setTestRecords);
        }

        [Fact]
        public void CreateGetAaaa()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.AaaaRecords = new List<AaaaRecord>
                {
                    new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:783f:e6dc"},
                    new AaaaRecord {Ipv6Address = "0:0:0:0:0:ffff:403:201"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.AAAA, setTestRecords);
        }

        [Fact]
        public void CreateGetMx()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.MxRecords = new List<MxRecord>
                {
                    new MxRecord {Exchange = "mail1.scsfsm.com", Preference = 1},
                    new MxRecord {Exchange = "mail2.scsfsm.com", Preference = 2},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.MX, setTestRecords);
        }

        [Fact]
        public void CreateGetNs()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.NsRecords = new List<NsRecord>
                {
                    new NsRecord {Nsdname = "ns1.scsfsm.com"},
                    new NsRecord {Nsdname = "ns2.scsfsm.com"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.NS, setTestRecords);
        }

        [Fact]
        public void CreateGetPtr()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.PtrRecords = new List<PtrRecord>
                {
                    new PtrRecord {Ptrdname = "www1.scsfsm.com"},
                    new PtrRecord {Ptrdname = "www2.scsfsm.com"},
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.PTR, setTestRecords);
        }

        [Fact]
        public void CreateGetSrv()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.SrvRecords = new List<SrvRecord>
                {
                    new SrvRecord
                    {
                        Target = "bt2.scsfsm.com",
                        Priority = 0,
                        Weight = 2,
                        Port = 44
                    },
                    new SrvRecord
                    {
                        Target = "bt1.scsfsm.com",
                        Priority = 1,
                        Weight = 1,
                        Port = 45
                    },
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.SRV, setTestRecords);
        }

        [Fact]
        public void CreateGetTxt()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
<<<<<<< HEAD
                createParams.RecordSet.Properties.TxtRecords = new List<TxtRecord> 
                    {    
                        new TxtRecord { Value = new[] {"lorem"}.ToList() }, 
                        new TxtRecord { Value = new[] {"ipsum"}.ToList() }, 
=======
                createParams.TxtRecords = new List<TxtRecord>
                {
                    new TxtRecord {Value = new[] {"lorem"}.ToList()},
                    new TxtRecord {Value = new[] {"ipsum"}.ToList()},
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.TXT, setTestRecords);
        }

        [Fact]
        public void CreateGetCname()
        {
            Action<RecordSet> setTestRecords = createParams =>
            {
                createParams.CnameRecord = new CnameRecord
                {
                    Cname = "www.contoroso.com",
                };

                return;
            };

            this.RecordSetCreateGet(RecordType.CNAME, setTestRecords);
        }

        [Fact]
        public void UpdateSoa()
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                SingleRecordSetTestContext testContext =
                    SetupSingleRecordSetTest(context);

                // SOA for the zone should already exist
                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA);

                RecordSet soaResource = getresponse;
                Assert.NotNull(soaResource);
                Assert.NotNull(soaResource.SoaRecord);

                soaResource.SoaRecord.ExpireTime = 123;
                soaResource.SoaRecord.MinimumTtl = 1234;
                soaResource.SoaRecord.RefreshTime = 12345;
                soaResource.SoaRecord.RetryTime = 123456;

                var updateParameters = soaResource;

<<<<<<< HEAD
                RecordSetCreateOrUpdateResponse updateResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: updateParameters);
=======
                var updateResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        "@",
                        RecordType.SOA,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: updateParameters);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.True(
                    TestHelpers.AreEqual(
                        soaResource,
                        updateResponse,
                        ignoreEtag: true),
                    "Response body of Update does not match expectations");

                getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    "@",
                    RecordType.SOA);

                Assert.True(
                    TestHelpers.AreEqual(updateResponse, getresponse),
                    "Response body of Get does not match expectations");

                // SOA will get deleted with the zone
                testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
<<<<<<< HEAD
                    ifMatch: null, 
=======
                    ifMatch: null,
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                    ifNoneMatch: null);
            }
        }

        [Fact]
        public void ListRecordsInZoneOneType()
        {
            ListRecordsInZone(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypes()
        {
            ListRecordsInZone(isCrossType: true);
        }

        private void ListRecordsInZone(
            bool isCrossType,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                SingleRecordSetTestContext testContext =
                    SetupSingleRecordSetTest(context);

                var recordSetNames = new[]
                {
                    TestUtilities.GenerateName("hydratestrec"),
                    TestUtilities.GenerateName("hydratestrec"),
                    TestUtilities.GenerateName("hydratestrec")
                };

                RecordSetScenarioTests.CreateRecordSets(
                    testContext,
                    recordSetNames);

                if (isCrossType)
                {
                    var listresponse = testContext.DnsClient.RecordSets
                        .ListAllInResourceGroup(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName);

                    // not checking for the record count as this will return standard SOA and auth NS records as well
                    Assert.NotNull(listresponse);
                    Assert.True(
                        listresponse.Any(
                            recordSetReturned =>
                                string.Equals(
                                    recordSetNames[0],
                                    recordSetReturned.Name))
                        &&
                        listresponse.Any(
                            recordSetReturned =>
                                string.Equals(
                                    recordSetNames[1],
                                    recordSetReturned.Name))
                        &&
                        listresponse.Any(
                            recordSetReturned =>
                                string.Equals(
                                    recordSetNames[2],
                                    recordSetReturned.Name)),
                        "The returned records do not meet expectations");
                }
                else
                {
                    var listresponse = testContext.DnsClient.RecordSets
                        .ListByType(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            RecordType.TXT);

                    Assert.NotNull(listresponse);
                    Assert.Equal(2, listresponse.Count());
                    Assert.True(
                        listresponse.Any(
                            recordSetReturned =>
                                string.Equals(
                                    recordSetNames[0],
                                    recordSetReturned.Name))
                        &&
                        listresponse.Any(
                            recordSetReturned =>
                                string.Equals(
                                    recordSetNames[1],
                                    recordSetReturned.Name)),
                        "The returned records do not meet expectations");
                }

                RecordSetScenarioTests.DeleteRecordSetsAndZone(
                    testContext,
                    recordSetNames);
            }
        }

        [Fact]
        public void ListRecordsInZoneOneTypeWithTop()
        {
            this.ListRecordsInZoneWithTop(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypesWithTop()
        {
            this.ListRecordsInZoneWithTop(isCrossType: true);
        }

        private void ListRecordsInZoneWithTop(
            bool isCrossType,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                SingleRecordSetTestContext testContext =
                    RecordSetScenarioTests.SetupSingleRecordSetTest(context);

                var recordSetNames = new[]
                {
                    TestUtilities.GenerateName("hydratestrec") + ".com",
                    TestUtilities.GenerateName("hydratestrec") + ".com",
                    TestUtilities.GenerateName("hydratestrec") + ".com"
                };

                RecordSetScenarioTests.CreateRecordSets(
                    testContext,
                    recordSetNames);

                IPage<RecordSet> listResponse;

                if (isCrossType)
                {
                    // Using top = 3, it will pick up SOA, NS and the first TXT
                    listResponse = testContext.DnsClient.RecordSets
                        .ListAllInResourceGroup(
                            testContext.ResourceGroup.Name,
                            testContext.ZoneName,
                            "3");
                    // verify if TXT is in the list
                    Assert.True(
                        listResponse.Where(rs => rs.Type == "TXT")
                            .All(
                                listedRecordSet =>
                                    recordSetNames.Any(
                                        createdName =>
                                            createdName == listedRecordSet.Name)),
                        "The returned records do not meet expectations");
                }
                else
                {
                    // Using top = 3, it will pick up SOA, NS and the first TXT, process it and return just the TXT
                    listResponse = testContext.DnsClient.RecordSets.ListByType(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        "3");
                    Assert.True(
                        listResponse.All(
                            listedRecordSet =>
                                recordSetNames.Any(
                                    createdName =>
                                        createdName == listedRecordSet.Name)),
                        "The returned records do not meet expectations");
                }

                RecordSetScenarioTests.DeleteRecordSetsAndZone(
                    testContext,
                    recordSetNames);
            }
        }

<<<<<<< HEAD
        private void ListRecordsInZoneWithFilter(bool isCrossType)
=======
        [Fact]
        public void UpdateRecordSetPreconditionFailed()
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        {
            using (
                MockContext context = MockContext.Start(this.GetType().FullName)
                )
            {
                SingleRecordSetTestContext testContext =
                    SetupSingleRecordSetTest(context);
                var createParameters = testContext.TestRecordSkeleton;
                createParameters.CnameRecord = new CnameRecord
                {
<<<<<<< HEAD
                    listResponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters { Filter = string.Format("endswith(Name,'{0}')", recordSetNames[0]) });
                }

                // not checking for the record count as this will return standard SOA and auth NS records as well
                Assert.NotNull(listResponse);
                Assert.Equal(1, listResponse.RecordSets.Count);
                Assert.NotNull(listResponse.RecordSets.FirstOrDefault());
                Assert.Equal(recordSetNames[0], listResponse.RecordSets.FirstOrDefault().Name);

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
            }
        }

        [Fact]
        public void ListRecordsInZoneOneTypeWithNext()
        {
            this.ListRecordsInZoneWithNext(isCrossType: false);
        }

        [Fact]
        public void ListRecordsInZoneAcrossTypesWithNext()
        {
            this.ListRecordsInZoneWithNext(isCrossType: true);
        }

        private void ListRecordsInZoneWithNext(bool isCrossType)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(currentMethodStackDepth: 4);
                SingleRecordSetTestContext testContext = RecordSetScenarioTests.SetupSingleRecordSetTest();

                const string suffix = ".com";

                var recordSetNames = new[] { TestUtilities.GenerateName("hydratestrec") + suffix, TestUtilities.GenerateName("hydratestrec") + ".com", TestUtilities.GenerateName("hydratestrec") + ".com" };

                RecordSetScenarioTests.CreateRecordSets(testContext, recordSetNames);

                RecordSetListResponse listResponse;
=======
                    Cname = "www.contoso.example.com"
                };
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var createResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
<<<<<<< HEAD
                        new RecordSetListParameters { Top = "3" });
                }
                else
                {
                    listResponse = testContext.DnsClient.RecordSets.List(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        RecordType.TXT,
                        new RecordSetListParameters { Top = "1" });
                }

                listResponse = testContext.DnsClient.RecordSets.ListNext(listResponse.NextLink);

                Assert.NotNull(listResponse);
                Assert.True(
                    listResponse.RecordSets.Any(recordReturned => string.Equals(recordSetNames[1], recordReturned.Name)),
                    "The returned records do not meet expectations");

                RecordSetScenarioTests.DeleteRecordSetsAndZone(testContext, recordSetNames);
            }
        }

        [Fact]
        public void UpdateRecordSetPreconditionFailed()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                SingleRecordSetTestContext testContext = SetupSingleRecordSetTest();
                RecordSetCreateOrUpdateParameters createParameters = testContext.TestRecordSkeleton;
                createParameters.RecordSet.Properties.CnameRecord = new CnameRecord { Cname = "www.contoso.example.com" };

                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.CNAME,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);
=======
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: createParameters);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var updateParameters = createResponse;

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () => testContext.DnsClient.RecordSets.CreateOrUpdate(
<<<<<<< HEAD
                        testContext.ResourceGroup.Name, 
                        testContext.ZoneName, 
                        testContext.RecordSetName, 
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: updateParameters),
                    exceptionAsserts: ex => ex.Error.Code == "PreconditionFailed");
=======
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: "somegibberish",
                        ifNoneMatch: null,
                        parameters: updateParameters),
                    exceptionAsserts: ex => ex.Body.Code == "PreconditionFailed");
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                // expect Precondition Failed 412
                TestHelpers.AssertThrows<CloudException>(
                    () => testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
<<<<<<< HEAD
                        ifMatch: null,
                        ifNoneMatch: null),
                    exceptionAsserts: ex => ex.Error.Code == "PreconditionFailed");

                testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        RecordType.CNAME,
                        ifMatch: null,
                        ifNoneMatch: null);

                testContext.DnsClient.Zones.Delete(testContext.ResourceGroup.Name, testContext.ZoneName, ifMatch: null, ifNoneMatch: null);
=======
                        ifMatch: "somegibberish",
                        ifNoneMatch: null),
                    exceptionAsserts: ex => ex.Body.Code == "PreconditionFailed");

                testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    RecordType.CNAME,
                    ifMatch: null,
                    ifNoneMatch: null);

                testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    ifMatch: null,
                    ifNoneMatch: null);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }
        }

        private void RecordSetCreateGet(
            RecordType recordType,
            Action<RecordSet> setRecordsAction,
            [System.Runtime.CompilerServices.CallerMemberName] string methodName
                = "testframework_failed")
        {
            using (
                MockContext context = MockContext.Start(
                    this.GetType().FullName,
                    methodName))
            {
                SingleRecordSetTestContext testContext =
                    SetupSingleRecordSetTest(context);
                var createParameters = testContext.TestRecordSkeleton;
                setRecordsAction(createParameters);

<<<<<<< HEAD
                RecordSetCreateOrUpdateResponse createResponse = testContext.DnsClient.RecordSets.CreateOrUpdate(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType,
                    ifMatch: null,
                    ifNoneMatch: null,
                    parameters: createParameters);
=======
                var createResponse = testContext.DnsClient.RecordSets
                    .CreateOrUpdate(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        testContext.RecordSetName,
                        recordType,
                        ifMatch: null,
                        ifNoneMatch: null,
                        parameters: createParameters);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                Assert.True(
                    TestHelpers.AreEqual(
                        createParameters,
                        createResponse,
                        ignoreEtag: true),
                    "Response body of Create does not match expectations");
                Assert.False(string.IsNullOrWhiteSpace(createResponse.Etag));

                var getresponse = testContext.DnsClient.RecordSets.Get(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType);

                Assert.True(
                    TestHelpers.AreEqual(
                        createResponse,
                        getresponse,
                        ignoreEtag: false),
                    "Response body of Get does not match expectations");

                // BUG 2364951: should work without specifying ETag
                testContext.DnsClient.RecordSets.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
                    testContext.RecordSetName,
                    recordType,
                    ifMatch: null,
<<<<<<< HEAD
                    ifNoneMatch: null);  
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
=======
                    ifNoneMatch: null);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                var deleteResponse = testContext.DnsClient.Zones.Delete(
                    testContext.ResourceGroup.Name,
                    testContext.ZoneName,
<<<<<<< HEAD
                    ifMatch: null, 
=======
                    ifMatch: null,
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                    ifNoneMatch: null);
            }
        }

        #region Helper methods

        public static void CreateRecordSets(
            SingleRecordSetTestContext testContext,
            string[] recordSetNames)
        {
<<<<<<< HEAD
            RecordSetCreateOrUpdateParameters createParameters1 = testContext.GetNewTestRecordSkeleton(recordSetNames[0]);
            createParameters1.RecordSet.Properties.TxtRecords = new List<TxtRecord> { new TxtRecord { Value = new [] { "text1" }.ToList() } };
            RecordSetCreateOrUpdateParameters createParameters2 = testContext.GetNewTestRecordSkeleton(recordSetNames[1]);
            createParameters2.RecordSet.Properties.TxtRecords = new List<TxtRecord> { new TxtRecord { Value = new[] { "text1" }.ToList() } };
            RecordSetCreateOrUpdateParameters createParameters3 = testContext.GetNewTestRecordSkeleton(recordSetNames[2]);
            createParameters3.RecordSet.Properties.AaaaRecords = new List<AaaaRecord> { new AaaaRecord { Ipv6Address = "123::45" } };
=======
            var createParameters1 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[0]);
            createParameters1.TxtRecords = new List<TxtRecord>
            {
                new TxtRecord {Value = new[] {"text1"}.ToList()}
            };
            var createParameters2 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[1]);
            createParameters2.TxtRecords = new List<TxtRecord>
            {
                new TxtRecord {Value = new[] {"text1"}.ToList()}
            };
            var createParameters3 =
                testContext.GetNewTestRecordSkeleton(recordSetNames[2]);
            createParameters3.AaaaRecords = new List<AaaaRecord>
            {
                new AaaaRecord {Ipv6Address = "123::45"}
            };
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters1.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters1);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters2.Name,
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters2);

            testContext.DnsClient.RecordSets.CreateOrUpdate(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                createParameters3.Name,
                RecordType.AAAA,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: createParameters3);
        }

        public static void DeleteRecordSetsAndZone(
            SingleRecordSetTestContext testContext,
            string[] recordSetNames)
        {
            testContext.DnsClient.RecordSets.Delete(
<<<<<<< HEAD
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[0],
                        RecordType.TXT,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[1],
                        RecordType.TXT,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                        testContext.ResourceGroup.Name,
                        testContext.ZoneName,
                        recordSetNames[2],
                        RecordType.AAAA,
                        ifMatch: null,
                        ifNoneMatch: null);

            testContext.DnsClient.Zones.Delete(testContext.ResourceGroup.Name, testContext.ZoneName, ifMatch: null, ifNoneMatch: null);
=======
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[0],
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[1],
                RecordType.TXT,
                ifMatch: null,
                ifNoneMatch: null);

            testContext.DnsClient.RecordSets.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                recordSetNames[2],
                RecordType.AAAA,
                ifMatch: null,
                ifNoneMatch: null);

            testContext.DnsClient.Zones.Delete(
                testContext.ResourceGroup.Name,
                testContext.ZoneName,
                ifMatch: null,
                ifNoneMatch: null);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        #endregion
    }
}