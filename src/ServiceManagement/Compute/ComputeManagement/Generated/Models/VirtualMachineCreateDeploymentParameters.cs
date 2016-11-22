// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute.Models
{
    /// <summary>
    /// Parameters supplied to the Create Virtual Machine Deployment operation.
    /// </summary>
    public partial class VirtualMachineCreateDeploymentParameters
    {
        private DeploymentSlot _deploymentSlot;
        
        /// <summary>
        /// Required. Specifies the environment in which to deploy the virtual
        /// machine. Possible values are: Staging or Production.
        /// </summary>
        public DeploymentSlot DeploymentSlot
        {
            get { return this._deploymentSlot; }
            set { this._deploymentSlot = value; }
        }
        
        private DnsSettings _dnsSettings;
        
        /// <summary>
        /// Optional. Contains a list of DNS servers to associate with the
        /// machine.
        /// </summary>
        public DnsSettings DnsSettings
        {
            get { return this._dnsSettings; }
            set { this._dnsSettings = value; }
        }
        
        private string _label;
        
        /// <summary>
        /// Required. A name for the hosted service. The name can be up to 100
        /// characters in length. It is recommended that the label be unique
        /// within the subscription. The name can be used identify the hosted
        /// service for tracking purposes.
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        
        private IList<LoadBalancer> _loadBalancers;
        
        /// <summary>
        /// Optional. A list of internal load balancers that each provide load
        /// balancing on a private VIP.
        /// </summary>
        public IList<LoadBalancer> LoadBalancers
        {
            get { return this._loadBalancers; }
            set { this._loadBalancers = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Required. A name for the deployment. The deployment name must be
        /// unique among other deployments for the hosted service.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private string _reservedIPName;
        
        /// <summary>
        /// Optional. Optional. Specifies the name of an existing reserved IP
        /// to which the deployment will belong. Reserved IPs are created by
        /// calling the Create Reserved IP operation.
        /// </summary>
        public string ReservedIPName
        {
            get { return this._reservedIPName; }
            set { this._reservedIPName = value; }
        }
        
        private IList<Role> _roles;
        
        /// <summary>
        /// Required. Contains the provisioning details for the new virtual
        /// machine deployment.
        /// </summary>
        public IList<Role> Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }
        
        private string _virtualNetworkName;
        
        /// <summary>
        /// Optional. Specifies the name of an existing virtual network to
        /// which the deployment will belong. Virtual networks are created by
        /// calling the Set Network Configuration operation.
        /// </summary>
        public string VirtualNetworkName
        {
            get { return this._virtualNetworkName; }
            set { this._virtualNetworkName = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineCreateDeploymentParameters class.
        /// </summary>
        public VirtualMachineCreateDeploymentParameters()
        {
            this.LoadBalancers = new LazyList<LoadBalancer>();
            this.Roles = new LazyList<Role>();
        }
    }
}
