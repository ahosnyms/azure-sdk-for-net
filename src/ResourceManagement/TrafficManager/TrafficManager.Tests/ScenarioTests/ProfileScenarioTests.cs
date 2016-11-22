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

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ProfileScenarioTests : TestBase
    {
        [Fact]
        public void CrudProfileFullCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string profileName = TestUtilities.GenerateName("atmprofile");
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name, 
                    profileName,
                    TrafficManagerHelper.GenerateDefaultProfile(profileName));

                // Get the profile
                trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
        
        [Fact]
        public void CrudProfileWithoutEndpoints_ThenUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string profileName = TestUtilities.GenerateName("atmprofile");
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                Profile profile = TrafficManagerHelper.GenerateDefaultProfile(profileName);
                profile.Endpoints = null;

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);

                profile.Endpoints = new[]
                {
                    new Endpoint
                    {
                        Id = null,
                        Name = "My external endpoint",
                        Type = "Microsoft.network/TrafficManagerProfiles/ExternalEndpoints",
                        TargetResourceId = null,
                        Target = "foobar.contoso.com",
                        EndpointLocation = "North Europe",
                        EndpointStatus = "Enabled"
                    } 
                };

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
        
        [Fact]
        public void ListProfilesByResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                for (int i = 0; i < 5; ++i)
                {
                    string profileName = TestUtilities.GenerateName("atmprofile");

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup.Name,
                        profileName,
                        TrafficManagerHelper.GenerateDefaultProfile(profileName));
                }

                List<Profile> listResponse = trafficManagerClient.Profiles.ListAllInResourceGroup(resourceGroup.Name).ToList();

                Assert.Equal(5, listResponse.Count);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void ListAllProfiles()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

<<<<<<< HEAD
                // This tests the list operation at subscription level therefore 
                // we can't use any granularity (e.g. resource groups) to isolate test runs
                int numberOfProfilesBeforeTest = trafficManagerClient.Profiles.ListAll().Profiles.Count;
=======
                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                ResourceGroupExtended resourceGroup1 = TrafficManagerHelper.CreateResourceGroup();
                ResourceGroupExtended resourceGroup2 = TrafficManagerHelper.CreateResourceGroup();

                // Create 2 resource groups with two profiles each
                for (int i = 0; i < 2; ++i)
                {
                    string profileName = TestUtilities.GenerateName("atmprofile");

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup1.Name,
                        profileName,
<<<<<<< HEAD
                        new ProfileCreateOrUpdateParameters
                        {
                            Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName)
                        });

                    trafficManagerClient.Profiles.CreateOrUpdate(
                       resourceGroup2.Name,
                       profileName,
                       new ProfileCreateOrUpdateParameters
                       {
                           Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName)
                       });
                }

                ProfileListResponse listResponse = trafficManagerClient.Profiles.ListAll();

                // At the end of the test we should have 4 profiles more than when we started
                Assert.Equal(numberOfProfilesBeforeTest + 4, listResponse.Profiles.Count);
            }
        }

        [Fact]
        public void NameAvailabilityTest_NameAvailable()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                string relativeName = TestUtilities.GenerateName("hydratestrelativename");

                var parameters = new CheckTrafficManagerRelativeDnsNameAvailabilityParameters
                {
                    Name = relativeName,
                    Type = "microsoft.network/trafficmanagerprofiles"
                };

                CheckTrafficManagerRelativeDnsNameAvailabilityResponse response = trafficManagerClient.Profiles.CheckTrafficManagerRelativeDnsNameAvailability(parameters);

                Assert.True(response.NameAvailable);
            }
        }

        [Fact]
        public void NameAvailabilityTest_NameNotAvailable()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                string relativeName = TestUtilities.GenerateName("hydratestrelativename");
                string profileName = TestUtilities.GenerateName("hydratestwatmv2profile");
                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    new ProfileCreateOrUpdateParameters
                    {
                        Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName, relativeName)
                    });

                var parameters = new CheckTrafficManagerRelativeDnsNameAvailabilityParameters
                {
                    Name = relativeName,
                    Type = "microsoft.network/trafficmanagerprofiles"
                };
=======
                        TrafficManagerHelper.GenerateDefaultProfile(profileName));
                }

                IEnumerable<Profile> listResponse = trafficManagerClient.Profiles.ListAll();
>>>>>>> 4593b3cdf19e4591008914b508b6243b342da301

                // Just in case the subscription had some other profiles
                Assert.True(5 <= listResponse.Count());

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
    }
}
