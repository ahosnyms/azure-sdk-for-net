// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Logic.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class EdifactFramingSettings
    {
        /// <summary>
        /// Initializes a new instance of the EdifactFramingSettings class.
        /// </summary>
        public EdifactFramingSettings() { }

        /// <summary>
        /// Initializes a new instance of the EdifactFramingSettings class.
        /// </summary>
        public EdifactFramingSettings(string serviceCodeListDirectoryVersion = default(string), string characterEncoding = default(string), int? protocolVersion = default(int?), int? dataElementSeparator = default(int?), int? componentSeparator = default(int?), int? segmentTerminator = default(int?), int? releaseIndicator = default(int?), int? repetitionSeparator = default(int?), EdifactCharacterSet? characterSet = default(EdifactCharacterSet?), EdifactDecimalIndicator? decimalPointIndicator = default(EdifactDecimalIndicator?), SegmentTerminatorSuffix? segmentTerminatorSuffix = default(SegmentTerminatorSuffix?))
        {
            ServiceCodeListDirectoryVersion = serviceCodeListDirectoryVersion;
            CharacterEncoding = characterEncoding;
            ProtocolVersion = protocolVersion;
            DataElementSeparator = dataElementSeparator;
            ComponentSeparator = componentSeparator;
            SegmentTerminator = segmentTerminator;
            ReleaseIndicator = releaseIndicator;
            RepetitionSeparator = repetitionSeparator;
            CharacterSet = characterSet;
            DecimalPointIndicator = decimalPointIndicator;
            SegmentTerminatorSuffix = segmentTerminatorSuffix;
        }

        /// <summary>
        /// Gets or sets the service code list directory version.
        /// </summary>
        [JsonProperty(PropertyName = "serviceCodeListDirectoryVersion")]
        public string ServiceCodeListDirectoryVersion { get; set; }

        /// <summary>
        /// Gets or sets the character encoding.
        /// </summary>
        [JsonProperty(PropertyName = "characterEncoding")]
        public string CharacterEncoding { get; set; }

        /// <summary>
        /// Gets or sets the protocol version.
        /// </summary>
        [JsonProperty(PropertyName = "protocolVersion")]
        public int? ProtocolVersion { get; set; }

        /// <summary>
        /// Gets or sets the data element separator.
        /// </summary>
        [JsonProperty(PropertyName = "dataElementSeparator")]
        public int? DataElementSeparator { get; set; }

        /// <summary>
        /// Gets or sets the component separator.
        /// </summary>
        [JsonProperty(PropertyName = "componentSeparator")]
        public int? ComponentSeparator { get; set; }

        /// <summary>
        /// Gets or sets the segment terminator.
        /// </summary>
        [JsonProperty(PropertyName = "segmentTerminator")]
        public int? SegmentTerminator { get; set; }

        /// <summary>
        /// Gets or sets the release indicator.
        /// </summary>
        [JsonProperty(PropertyName = "releaseIndicator")]
        public int? ReleaseIndicator { get; set; }

        /// <summary>
        /// Gets or sets the repetition separator.
        /// </summary>
        [JsonProperty(PropertyName = "repetitionSeparator")]
        public int? RepetitionSeparator { get; set; }

        /// <summary>
        /// Gets or sets the EDIFACT frame setting characterSet. Possible
        /// values include: 'NotSpecified', 'UNOB', 'UNOA', 'UNOC', 'UNOD',
        /// 'UNOE', 'UNOF', 'UNOG', 'UNOH', 'UNOI', 'UNOJ', 'UNOK', 'UNOX',
        /// 'UNOY', 'KECA'
        /// </summary>
        [JsonProperty(PropertyName = "characterSet")]
        public EdifactCharacterSet? CharacterSet { get; set; }

        /// <summary>
        /// Gets or sets the EDIFACT frame setting decimal indicator. Possible
        /// values include: 'NotSpecified', 'Comma', 'Decimal'
        /// </summary>
        [JsonProperty(PropertyName = "decimalPointIndicator")]
        public EdifactDecimalIndicator? DecimalPointIndicator { get; set; }

        /// <summary>
        /// Gets or sets the EDIFACT frame setting segment terminator suffix.
        /// Possible values include: 'NotSpecified', 'None', 'CR', 'LF',
        /// 'CRLF'
        /// </summary>
        [JsonProperty(PropertyName = "segmentTerminatorSuffix")]
        public SegmentTerminatorSuffix? SegmentTerminatorSuffix { get; set; }

    }
}
