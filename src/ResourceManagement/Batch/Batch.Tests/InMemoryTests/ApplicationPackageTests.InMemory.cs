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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Batch.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;

=======
using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
using Xunit;

namespace Batch.Tests.InMemoryTests
{
    public class ApplicationPackageTests
    {
<<<<<<< HEAD
        public BatchManagementClient GetBatchManagementClient(RecordedDelegatingHandler handler)
        {
            var certCreds = new CertificateCloudCredentials(Guid.NewGuid().ToString(), new System.Security.Cryptography.X509Certificates.X509Certificate2());
            handler.IsPassThrough = false;
            return new BatchManagementClient(certCreds).WithHandler(handler);
        }

=======
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        [Fact]
        public void IfAnAccountIsCreatedWithAutoStorage_ThenTheAutoStorageAccountIdMustNotBeNull()
        {
            var handler = new RecordedDelegatingHandler();

<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            // If storageId is not set this will throw an ArgumentNullException
            var ex = Assert.Throws<ArgumentNullException>(() => client.Accounts.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                Properties = new AccountBaseProperties
                {
                    AutoStorage = new AutoStorageBaseProperties()
                }
            }));

            Assert.Equal("parameters.Properties.AutoStorage.StorageAccountId", ex.ParamName);
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            // If storageId is not set this will throw an ValidationException
            var ex = Assert.Throws<ValidationException>(() => client.BatchAccount.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                AutoStorage = new AutoStorageBaseProperties()
            }));

            Assert.Equal("StorageAccountId", ex.Target.ToString());
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void AddApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                    'version' : 'beta',
                    'storageUrlExpiry' : '" + utcNow.ToString("o") + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AddApplicationPackageResponse result = client.Applications.AddApplicationPackage("resourceGroupName", "acctName", "appId", "beta");
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.CreateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "beta")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            Assert.Equal(utcNow, result.StorageUrlExpiry);
            Assert.Equal("foo", result.Id);
            Assert.Equal("beta", result.Version);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.StorageUrl);
=======
            Assert.Equal(utcNow, result.Body.StorageUrlExpiry);
            Assert.Equal("foo", result.Body.Id);
            Assert.Equal("beta", result.Body.Version);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Body.StorageUrl);
            Assert.Equal(HttpStatusCode.Created, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void AddApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;
<<<<<<< HEAD

=======
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'displayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'fooVersion', 'state':'pending', 'format': 'betaFormat', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.AddApplication(
                "resourceGroupName",
                "acctName",
                "appId",
                new AddApplicationParameters { AllowUpdates = true, DisplayName = "display-name" });
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.CreateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new AddApplicationParameters
                {
                    AllowUpdates = true,
                    DisplayName = "display-name"
                })).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
=======
            Assert.Equal(HttpStatusCode.Created, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void ActivateApplicationPackageValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.ActivateApplicationPackage(
                "resourceGroupName",
                "acctName",
                "appId", "version",
                new ActivateApplicationPackageParameters("zip"));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.ActivateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "version",
                "zip")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
=======
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void DeleteApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplication(
                "resourceGroupName",
                "acctName",
                "appId");

=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.DeleteWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
=======
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void DeleteApplicationPackageValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplicationPackage(
                "resourceGroupName",
                "acctName",
                "appId",
                "version");

=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.DeleteWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "version")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
=======
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void GetApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'displayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'fooVersion', 'state':'pending', 'format': 'betaFormat', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            GetApplicationResponse result = client.Applications.GetApplication("applicationId", "acctName", "id");
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.GetWithHttpMessagesAsync(
                "applicationId",
                "acctName",
                "id")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);


            Assert.Equal("foo", result.Application.Id);
            Assert.Equal(true, result.Application.AllowUpdates);
            Assert.Equal("beta", result.Application.DefaultVersion);
            Assert.Equal("displayName", result.Application.DisplayName);
            Assert.Equal(1, result.Application.ApplicationPackages.Count);
            Assert.Equal("betaFormat", result.Application.ApplicationPackages.First().Format);
            Assert.Equal(PackageState.Pending, result.Application.ApplicationPackages.First().State);
            Assert.Equal("fooVersion", result.Application.ApplicationPackages.First().Version);
            Assert.Equal(utcNow, result.Application.ApplicationPackages.First().LastActivationTime);
=======
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Assert.Equal("foo", result.Body.Id);
            Assert.Equal(true, result.Body.AllowUpdates);
            Assert.Equal("beta", result.Body.DefaultVersion);
            Assert.Equal("displayName", result.Body.DisplayName);
            Assert.Equal(1, result.Body.Packages.Count);
            Assert.Equal("betaFormat", result.Body.Packages.First().Format);
            Assert.Equal(PackageState.Pending, result.Body.Packages.First().State);
            Assert.Equal("fooVersion", result.Body.Packages.First().Version);
            Assert.Equal(utcNow, result.Body.Packages.First().LastActivationTime);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void GetApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '//storageUrl',
                    'state' : 'Pending',
                    'version' : 'beta',
                    'format':'zip',
                    'storageUrlExpiry':'" + utcNow.ToString("o") + @"',
                    'lastActivationTime':'" + utcNow.ToString("o") + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            GetApplicationPackageResponse result = client.Applications.GetApplicationPackage("resourceGroupName", "acctName", "id", "VER");
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.GetWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "id",
                "VER")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

<<<<<<< HEAD
            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal("foo", result.Id);
            Assert.Equal("//storageUrl", result.StorageUrl);
            Assert.Equal(PackageState.Pending, result.State);
            Assert.Equal("beta", result.Version);
            Assert.Equal("zip", result.Format);
            Assert.Equal(utcNow, result.LastActivationTime);
            Assert.Equal(utcNow, result.StorageUrlExpiry);
=======
            //Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Assert.Equal("foo", result.Body.Id);
            Assert.Equal("//storageUrl", result.Body.StorageUrl);
            Assert.Equal(PackageState.Pending, result.Body.State);
            Assert.Equal("beta", result.Body.Version);
            Assert.Equal("zip", result.Body.Format);
            Assert.Equal(utcNow, result.Body.LastActivationTime);
            Assert.Equal(utcNow, result.Body.StorageUrlExpiry);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void ApplicationListNextThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.ListNext(null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);
            Assert.Throws<ValidationException>(() => client.Application.ListNext(null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void ListApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ 'value':[{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'DisplayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'version1', 'state':'pending', 'format': 'beta', 'lastActivationTime': '" + utcNow.ToString("o") + @"'},
                        {'version':'version2', 'state':'pending', 'format': 'alpha', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }]}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            ListApplicationsResponse result = client.Applications.List("resourceGroupName", "acctName", new ListApplicationsParameters());
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() => client.Application.ListWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName")).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Application application = result.Applications.First();
=======
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Application application = result.Body.First();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            Assert.Equal("foo", application.Id);
            Assert.Equal(true, application.AllowUpdates);
            Assert.Equal("beta", application.DefaultVersion);
            Assert.Equal("DisplayName", application.DisplayName);
<<<<<<< HEAD
            Assert.Equal(application.ApplicationPackages.Count, 2);
            Assert.Equal("beta", application.ApplicationPackages.First().Format);
            Assert.Equal(PackageState.Pending, application.ApplicationPackages.First().State);
            Assert.Equal("version1", application.ApplicationPackages.First().Version);
            Assert.Equal(utcNow, application.ApplicationPackages.First().LastActivationTime);
=======
            Assert.Equal(2, application.Packages.Count);
            Assert.Equal("beta", application.Packages.First().Format);
            Assert.Equal(PackageState.Pending, application.Packages.First().State);
            Assert.Equal("version1", application.Packages.First().Version);
            Assert.Equal(utcNow, application.Packages.First().LastActivationTime);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void UpdateApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.UpdateApplication(
                "resourceGroupName",
                "acctName",
                "appId", new UpdateApplicationParameters() { AllowUpdates = true, DisplayName = "display-name", DefaultVersion = "blah" }
                );
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.UpdateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new UpdateApplicationParameters()
                {
                    AllowUpdates = true,
                    DisplayName = "display-name",
                    DefaultVersion = "blah"
                }
                )).Unwrap().GetAwaiter().GetResult();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal("PATCH", handler.Method.ToString());
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
=======
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToActivateApplicationPackage()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage(null, "foo", "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", null, "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", null, "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", "foo", null, new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", "foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate(null, "foo", "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", null, "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", "foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", "foo", "foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToAddApplication()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication(null, "foo", "foo", new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", null, "foo", new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", "foo", null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", "foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.Create(null, "foo", "foo", new AddApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", null, "foo", new AddApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", "foo", null, new AddApplicationParameters()));
            Assert.Throws<NullReferenceException>(() => client.Application.Create("foo", "foo", "foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplication()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication(null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.Delete(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Delete("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Delete("foo", "foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplicationPackage()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage(null, "foo", "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", "bar", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete(null, "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", "foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", "foo", "bar", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToGetApplication()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication(null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);
            Assert.Throws<ValidationException>(() => client.Application.Get(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Get("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Get("foo", "foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToListApplications()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.List(null, "foo", new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List("foo", null, new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List("foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.List(null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.List("foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        [Fact]
        public void CannotPassNullArgumentsToUpdateApplication()
        {
            var handler = new RecordedDelegatingHandler();
<<<<<<< HEAD
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication(null, "foo", "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", null, "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", "foo", null, new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", "foo", "foo", null));
=======
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.Update(null, "foo", "foo", new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", null, "foo", new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", null, new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", "foo", null));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }
    }
}
