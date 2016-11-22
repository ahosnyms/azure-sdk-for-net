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
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Management.Compute.Models
{
    /// <summary>
    /// Parameters returned from the Create Virtual Machine Image operation.
    /// </summary>
    public partial class VirtualMachineOSImageUpdateResponse : AzureOperationResponse
    {
        private string _category;
        
        /// <summary>
        /// Optional. The repository classification of the image. All user
        /// images have the category User.
        /// </summary>
        public string Category
        {
            get { return this._category; }
            set { this._category = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional. Specifies the description of the OS image.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private string _eula;
        
        /// <summary>
        /// Optional. Specifies the End User License Agreement that is
        /// associated with the image. The value for this element is a string,
        /// but it is recommended that the value be a URL that points to a
        /// EULA.
        /// </summary>
        public string Eula
        {
            get { return this._eula; }
            set { this._eula = value; }
        }
        
        private string _iconUri;
        
        /// <summary>
        /// Optional. Specifies the URI to the icon that is displayed for the
        /// image in the Management Portal.
        /// </summary>
        public string IconUri
        {
            get { return this._iconUri; }
            set { this._iconUri = value; }
        }
        
        private string _imageFamily;
        
        /// <summary>
        /// Optional. Specifies a value that can be used to group OS images.
        /// </summary>
        public string ImageFamily
        {
            get { return this._imageFamily; }
            set { this._imageFamily = value; }
        }
        
        private string _iOType;
        
        /// <summary>
        /// Optional. Gets or sets the IO type.
        /// </summary>
        public string IOType
        {
            get { return this._iOType; }
            set { this._iOType = value; }
        }
        
        private bool? _isPremium;
        
        /// <summary>
        /// Optional. Indicates if the image contains software or associated
        /// services that will incur charges above the core price for the
        /// virtual machine.
        /// </summary>
        public bool? IsPremium
        {
            get { return this._isPremium; }
            set { this._isPremium = value; }
        }
        
        private string _label;
        
        /// <summary>
        /// Optional. Specifies the friendly name of the image.
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        
        private string _language;
        
        /// <summary>
        /// Optional. Specifies the language of the image. The Language element
        /// is only available using version 2013-03-01 or higher.
        /// </summary>
        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }
        
        private string _location;
        
        /// <summary>
        /// Optional. The geo-location in which this media is located. The
        /// Location value is derived from storage account that contains the
        /// blob in which the media is located. If the storage account belongs
        /// to an affinity group the value is NULL. If the version is set to
        /// 2012-08-01 or later, the locations are returned for platform
        /// images; otherwise, this value is NULL for platform images.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }
        
        private double _logicalSizeInGB;
        
        /// <summary>
        /// Optional. The size, in GB, of the image.
        /// </summary>
        public double LogicalSizeInGB
        {
            get { return this._logicalSizeInGB; }
            set { this._logicalSizeInGB = value; }
        }
        
        private Uri _mediaLinkUri;
        
        /// <summary>
        /// Optional. Specifies the location of the blob in Azure storage. The
        /// blob location must belong to a storage account in the subscription
        /// specified by the SubscriptionId value in the operation call.
        /// Example: http://example.blob.core.windows.net/disks/mydisk.vhd.
        /// </summary>
        public Uri MediaLinkUri
        {
            get { return this._mediaLinkUri; }
            set { this._mediaLinkUri = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. Specifies a name that Azure uses to identify the image
        /// when creating one or more virtual machines.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private string _operatingSystemType;
        
        /// <summary>
        /// Optional. The operating system type of the OS image. Possible
        /// values are: Linux or Windows.
        /// </summary>
        public string OperatingSystemType
        {
            get { return this._operatingSystemType; }
            set { this._operatingSystemType = value; }
        }
        
        private Uri _privacyUri;
        
        /// <summary>
        /// Optional. Specifies the URI that points to a document that contains
        /// the privacy policy related to the OS image.
        /// </summary>
        public Uri PrivacyUri
        {
            get { return this._privacyUri; }
            set { this._privacyUri = value; }
        }
        
        private System.DateTime? _publishedDate;
        
        /// <summary>
        /// Optional. Specifies the date when the OS image was added to the
        /// image repository.
        /// </summary>
        public System.DateTime? PublishedDate
        {
            get { return this._publishedDate; }
            set { this._publishedDate = value; }
        }
        
        private string _publisherName;
        
        /// <summary>
        /// Optional. Specifies the name of the publisher of the image.
        /// </summary>
        public string PublisherName
        {
            get { return this._publisherName; }
            set { this._publisherName = value; }
        }
        
        private string _recommendedVMSize;
        
        /// <summary>
        /// Optional. Specifies the size to use for the virtual machine that is
        /// created from the OS image.
        /// </summary>
        public string RecommendedVMSize
        {
            get { return this._recommendedVMSize; }
            set { this._recommendedVMSize = value; }
        }
        
        private bool? _showInGui;
        
        /// <summary>
        /// Optional. Specifies whether the image should appear in the image
        /// gallery.
        /// </summary>
        public bool? ShowInGui
        {
            get { return this._showInGui; }
            set { this._showInGui = value; }
        }
        
        private string _smallIconUri;
        
        /// <summary>
        /// Optional. Specifies the URI to the small icon that is displayed
        /// when the image is presented in the Azure Management Portal. The
        /// SmallIconUri element is only available using version 2013-03-01 or
        /// higher.
        /// </summary>
        public string SmallIconUri
        {
            get { return this._smallIconUri; }
            set { this._smallIconUri = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineOSImageUpdateResponse class.
        /// </summary>
        public VirtualMachineOSImageUpdateResponse()
        {
        }
    }
}
