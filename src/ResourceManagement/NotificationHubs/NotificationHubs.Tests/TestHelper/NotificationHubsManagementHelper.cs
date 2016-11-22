﻿//  
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

namespace NotificationHubs.Tests.TestHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
<<<<<<< HEAD
    using System.Net;
    using Microsoft.Azure;
=======
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
<<<<<<< HEAD
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.WindowsAzure.Management;
    using System.Security.Cryptography;
    using Newtonsoft.Json;
=======
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Converters;

    public static class NotificationHubsManagementHelper
    {
        internal const string DefaultLocation = "South Central US";
<<<<<<< HEAD
        internal const string ResourceGroupPrefix = "NotificationHub-RG";
=======
        internal const string ResourceGroupPrefix = "TestRg-NH";
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        internal const string NamespacePrefix = "HydraNH-Namespace";
        internal const string NotificationHubPrefix = "HydraNH-NotificationHub";
        internal const string AuthorizationRulesPrefix = "HydraNH-Authrules";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
<<<<<<< HEAD
        
        public static NotificationHubsManagementClient GetNotificationHubsManagementClient(RecordedDelegatingHandler handler)
        {
            return TestBase.GetServiceClient<NotificationHubsManagementClient>(new CSMTestEnvironmentFactory());//.WithHandler(handler);
        }

        public static ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        public static ManagementClient GetManagementClient(RecordedDelegatingHandler handler)
        {
            return TestBase.GetServiceClient<ManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        public static void RefreshAccessToken(this NotificationHubsManagementClient notificationHubsManagementClient)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                // if it's playback then do nothing
                return;
            }

            var testEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();
            var context = new AuthenticationContext(new Uri(testEnvironment.Endpoints.AADAuthUri, testEnvironment.Tenant).AbsoluteUri);

            var result = context.AcquireToken("https://management.core.windows.net/", testEnvironment.ClientId, new Uri("urn:ietf:wg:oauth:2.0:oob"), PromptBehavior.Auto);
            var newToken = context.AcquireTokenByRefreshToken(result.RefreshToken, testEnvironment.ClientId, "https://management.core.windows.net/");

            ((TokenCloudCredentials)notificationHubsManagementClient.Credentials).Token = newToken.AccessToken;
=======

        public static NotificationHubsManagementClient GetNotificationHubsManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                NotificationHubsManagementClient nhManagementClient = context.GetServiceClient<NotificationHubsManagementClient>(handlers: handler);
                return nhManagementClient;
            }

            return null;
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                ResourceManagementClient rManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return rManagementClient;
            }

            return null;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        private static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

<<<<<<< HEAD
        public static void TryRegisterSubscriptionForResource(this ResourceManagementClient resourceManagementClient, string providerName = "Microsoft.NotificationHubs")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "_client.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("_client.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                        ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

=======
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            var resourceGroup =
                resourceManagementClient.ResourceGroups
<<<<<<< HEAD
                    .List(new ResourceGroupListParameters()).ResourceGroups
                    .Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
=======
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
                    .FirstOrDefault(group => group.Name.Contains(ResourceGroupPrefix));

            return resourceGroup != null

                ? resourceGroup.Name
                : string.Empty;
        }
<<<<<<< HEAD

        public static IEnumerable<ResourceGroupExtended> GetResourceGroups(this ResourceManagementClient resourceManagementClient)
        {
            return resourceManagementClient.ResourceGroups.List(new ResourceGroupListParameters()).ResourceGroups;
        }

=======
        
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

<<<<<<< HEAD
        public static string TryGetLocation(this ManagementClient managementClient, string preferedLocationName = null)
        {
            var loc = managementClient.Locations;
            var locList = loc.List();
            var locc = locList.Locations;

            var locations = managementClient.Locations.List().Locations;
            if (!locations.Any())
            {
                return string.Empty;
            }

            var foundLocation = locations.First();
            if (preferedLocationName == null)
            {
                return foundLocation.Name;
            }

            var preferedLocation = locations.FirstOrDefault(location => location.Name.Contains(preferedLocationName));
            if (preferedLocation != null)
            {
                return preferedLocation.Name;
            }

            return foundLocation.Name;
        }

        public static IEnumerable<string> GetLocations(this ManagementClient managementClient)
        {
            return managementClient.Locations.List().Locations.Select(location => location.Name);
=======
        public static void TryDeleteResourceGroup(this ResourceManagementClient resourceManagementClient, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.Delete(resourceGroupName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        public static void TryCreateNamespace(
            this NotificationHubsManagementClient client,
            string resourceGroupName,
            string namespaceName,
            string location,
            string scaleUnit = null)
        {
            var namespaceParameter = new NamespaceCreateOrUpdateParameters()
<<<<<<< HEAD
                {
                    Location = location,
                    Properties = new NamespaceProperties
                    {
                        NamespaceType = NamespaceType.NotificationHub
                    }
                };

            if (!string.IsNullOrEmpty(scaleUnit))
            {
                namespaceParameter.Properties.ScaleUnit = scaleUnit;
=======
            {
                Location = location,
                NamespaceType = NamespaceType.NotificationHub
            };

            if (!string.IsNullOrEmpty(scaleUnit))
            {
                namespaceParameter.ScaleUnit = scaleUnit;
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            }

            client.Namespaces.CreateOrUpdate(
                resourceGroupName,
                namespaceName, namespaceParameter
               );

            var response = client.Namespaces.Get(resourceGroupName, namespaceName);
<<<<<<< HEAD
            ThrowIfTrue(!response.Value.Name.Equals(namespaceName), string.Format("Namespace name is not equal to {0}", namespaceName));
=======
            ThrowIfTrue(!response.Name.Equals(namespaceName), string.Format("Namespace name is not equal to {0}", namespaceName));
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
        }

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
<<<<<<< HEAD
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
=======
            using (var rngCryptoServiceProvider = RandomNumberGenerator.Create())
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

        public static string ConvertObjectToJSon<T>(T obj)
        {
            return ConvertObjectToJSonAsync(obj);
        }

        public static string ConvertObjectToJSonAsync(object obj)
        {
            if (obj != null)
            {
                return (Task.Factory.StartNew(() => JsonConvert.SerializeObject(obj, SerializeMediaTypeFormatterSettings))).Result;
            }
            return String.Empty;
        }

        private static readonly JsonSerializerSettings SerializeMediaTypeFormatterSettings = new JsonSerializerSettings
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter { CamelCaseText = false },
            },
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };
<<<<<<< HEAD

=======
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301
    }
}