// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Storage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for UsageUnit.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UsageUnit
    {
        [EnumMember(Value = "Count")]
        Count,
        [EnumMember(Value = "Bytes")]
        Bytes,
        [EnumMember(Value = "Seconds")]
        Seconds,
        [EnumMember(Value = "Percent")]
        Percent,
        [EnumMember(Value = "CountsPerSecond")]
        CountsPerSecond,
        [EnumMember(Value = "BytesPerSecond")]
        BytesPerSecond
    }
}
