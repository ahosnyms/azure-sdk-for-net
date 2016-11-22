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
using System.Linq;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Management.Network.Models
{
    /// <summary>
    /// Rules of the load balancer
    /// </summary>
    public partial class LoadBalancingRule : ChildResource
    {
        private ResourceId _backendAddressPool;
        
        /// <summary>
        /// Required. Gets or sets  a reference to a pool of DIPs. Inbound
        /// traffic is randomly load balanced across IPs in the backend IPs
        /// </summary>
        public ResourceId BackendAddressPool
        {
            get { return this._backendAddressPool; }
            set { this._backendAddressPool = value; }
        }
        
        private int _backendPort;
        
        /// <summary>
        /// Optional. Gets or sets a port used for internal connections on the
        /// endpoint. The localPort attribute maps the eternal port of the
        /// endpoint to an internal port on a role. This is useful in
        /// scenarios where a role must communicate to an internal compotnent
        /// on a port that is different from the one that is exposed
        /// externally. If not specified, the value of localPort is the same
        /// as the port attribute. Set the value of localPort to '*' to
        /// automatically assign an unallocated port that is discoverable
        /// using the runtime API
        /// </summary>
        public int BackendPort
        {
            get { return this._backendPort; }
            set { this._backendPort = value; }
        }
        
        private bool _enableFloatingIP;
        
        /// <summary>
        /// Required. Configures a virtual machine's endpoint for the floating
        /// IP capability required to configure a SQL AlwaysOn availability
        /// Group. This setting is required when using the SQL Always ON
        /// availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint
        /// </summary>
        public bool EnableFloatingIP
        {
            get { return this._enableFloatingIP; }
            set { this._enableFloatingIP = value; }
        }
        
        private ResourceId _frontendIPConfiguration;
        
        /// <summary>
        /// Optional. Gets or sets a reference to frontend IP Addresses
        /// </summary>
        public ResourceId FrontendIPConfiguration
        {
            get { return this._frontendIPConfiguration; }
            set { this._frontendIPConfiguration = value; }
        }
        
        private int _frontendPort;
        
        /// <summary>
        /// Required. Gets or sets the port for the external endpoint. You can
        /// specify any port number you choose, but the port numbers specified
        /// for each role in the service must be unique. Possible values range
        /// between 1 and 65535, inclusive
        /// </summary>
        public int FrontendPort
        {
            get { return this._frontendPort; }
            set { this._frontendPort = value; }
        }
        
        private int? _idleTimeoutInMinutes;
        
        /// <summary>
        /// Optional. Gets or sets the timeout for the Tcp idle connection. The
        /// value can be set between 4 and 30 minutes. The default value is 4
        /// minutes. This emlement is only used when the protocol is set to Tcp
        /// </summary>
        public int? IdleTimeoutInMinutes
        {
            get { return this._idleTimeoutInMinutes; }
            set { this._idleTimeoutInMinutes = value; }
        }
        
        private string _loadDistribution;
        
        /// <summary>
        /// Optional. Gets or sets the load distribution policy for this rule
        /// </summary>
        public string LoadDistribution
        {
            get { return this._loadDistribution; }
            set { this._loadDistribution = value; }
        }
        
        private ResourceId _probe;
        
        /// <summary>
        /// Optional. Gets or sets the reference of the load balancer probe
        /// used by the Load Balancing rule.
        /// </summary>
        public ResourceId Probe
        {
            get { return this._probe; }
            set { this._probe = value; }
        }
        
        private string _protocol;
        
        /// <summary>
        /// Required. Gets or sets the transport protocol for the external
        /// endpoint. Possible values are Udp or Tcp
        /// </summary>
        public string Protocol
        {
            get { return this._protocol; }
            set { this._protocol = value; }
        }
        
        private string _provisioningState;
        
        /// <summary>
        /// Optional. Gets or sets Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the LoadBalancingRule class.
        /// </summary>
        public LoadBalancingRule()
        {
        }
    }
}
