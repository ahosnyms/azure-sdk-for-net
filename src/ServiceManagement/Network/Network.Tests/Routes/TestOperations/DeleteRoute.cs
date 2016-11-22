﻿// Copyright (c) Microsoft.  All rights reserved.
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

using Microsoft.Azure;

namespace Network.Tests.Routes.TestOperations
{
    using System;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class DeleteRoute : TestOperation
    {
        private readonly IRouteOperations routeOperations;
        private readonly string routeTableName;
        private readonly string routeName;

        private readonly RouteTable oldRouteTable;

        public AzureOperationResponse InvokeResponse;

        public DeleteRoute(IRouteOperations routeOperations, string routeTableName, string routeName)
        {
            this.routeOperations = routeOperations;
            this.routeTableName = routeTableName;
            this.routeName = routeName;

            oldRouteTable = RouteTestClient.GetRouteTableSafe(routeOperations, routeTableName);
        }
        public void Invoke()
        {
            InvokeResponse = routeOperations.DeleteRoute(routeTableName, routeName);
        }

        public void Undo()
        {
            if (oldRouteTable != null)
            {
                Route oldRoute = null;
                if (oldRouteTable.RouteList != null)
                {
                    foreach (Route route in oldRouteTable.RouteList)
                    {
                        if (string.Equals(route.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            oldRoute = route;
                            break;
                        }
                    }
                }

                if (oldRoute != null)
                {
                    SetRouteParameters undoParameters = new SetRouteParameters()
                    {
                        Name = oldRoute.Name,
                        AddressPrefix = oldRoute.AddressPrefix,
                        NextHop = oldRoute.NextHop,
                    };
                    routeOperations.SetRoute(routeTableName, routeName, undoParameters);
                }
            }
        }
    }
}
