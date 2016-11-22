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
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.ApiApps;
using Microsoft.Azure.Management.ApiApps.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.ApiApps
{
    /// <summary>
    /// Operations for generating deployment templates
    /// </summary>
    internal partial class TemplateOperations : IServiceOperations<ApiAppManagementClient>, ITemplateOperations
    {
        /// <summary>
        /// Initializes a new instance of the TemplateOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal TemplateOperations(ApiAppManagementClient client)
        {
            this._client = client;
        }
        
        private ApiAppManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.ApiApps.ApiAppManagementClient.
        /// </summary>
        public ApiAppManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get metadata for deploying a package to the given resource group
        /// </summary>
        /// <param name='parameters'>
        /// Required. Parameters for operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<GetDeploymentTemplateMetadataResponse> GetMetadataAsync(GetDeploymentMetadataRequest parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "GetMetadataAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/providers/Microsoft.AppService/deploymenttemplates/";
            if (parameters.MicroserviceId != null)
            {
                url = url + Uri.EscapeDataString(parameters.MicroserviceId);
            }
            url = url + "/listmetadata";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-03-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    GetDeploymentTemplateMetadataResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new GetDeploymentTemplateMetadataResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            DeploymentTemplateMetadata metadataInstance = new DeploymentTemplateMetadata();
                            result.Metadata = metadataInstance;
                            
                            JToken valueValue = responseDoc["value"];
                            if (valueValue != null && valueValue.Type != JTokenType.Null)
                            {
                                JToken microserviceIdValue = valueValue["microserviceId"];
                                if (microserviceIdValue != null && microserviceIdValue.Type != JTokenType.Null)
                                {
                                    string microserviceIdInstance = ((string)microserviceIdValue);
                                    metadataInstance.MicroserviceId = microserviceIdInstance;
                                }
                                
                                JToken displayNameValue = valueValue["displayName"];
                                if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                {
                                    string displayNameInstance = ((string)displayNameValue);
                                    metadataInstance.DisplayName = displayNameInstance;
                                }
                                
                                JToken appSettingsArray = valueValue["appSettings"];
                                if (appSettingsArray != null && appSettingsArray.Type != JTokenType.Null)
                                {
                                    foreach (JToken appSettingsValue in ((JArray)appSettingsArray))
                                    {
                                        ParameterMetadata parameterMetadataInstance = new ParameterMetadata();
                                        metadataInstance.Parameters.Add(parameterMetadataInstance);
                                        
                                        JToken nameValue = appSettingsValue["name"];
                                        if (nameValue != null && nameValue.Type != JTokenType.Null)
                                        {
                                            string nameInstance = ((string)nameValue);
                                            parameterMetadataInstance.Name = nameInstance;
                                        }
                                        
                                        JToken typeValue = appSettingsValue["type"];
                                        if (typeValue != null && typeValue.Type != JTokenType.Null)
                                        {
                                            string typeInstance = ((string)typeValue);
                                            parameterMetadataInstance.Type = typeInstance;
                                        }
                                        
                                        JToken displayNameValue2 = appSettingsValue["displayName"];
                                        if (displayNameValue2 != null && displayNameValue2.Type != JTokenType.Null)
                                        {
                                            string displayNameInstance2 = ((string)displayNameValue2);
                                            parameterMetadataInstance.DisplayName = displayNameInstance2;
                                        }
                                        
                                        JToken descriptionValue = appSettingsValue["description"];
                                        if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                        {
                                            string descriptionInstance = ((string)descriptionValue);
                                            parameterMetadataInstance.Description = descriptionInstance;
                                        }
                                        
                                        JToken tooltipValue = appSettingsValue["tooltip"];
                                        if (tooltipValue != null && tooltipValue.Type != JTokenType.Null)
                                        {
                                            string tooltipInstance = ((string)tooltipValue);
                                            parameterMetadataInstance.Tooltip = tooltipInstance;
                                        }
                                        
                                        JToken uiHintValue = appSettingsValue["uiHint"];
                                        if (uiHintValue != null && uiHintValue.Type != JTokenType.Null)
                                        {
                                            string uiHintInstance = ((string)uiHintValue);
                                            parameterMetadataInstance.UIHint = uiHintInstance;
                                        }
                                        
                                        JToken defaultValueValue = appSettingsValue["defaultValue"];
                                        if (defaultValueValue != null && defaultValueValue.Type != JTokenType.Null)
                                        {
                                            string defaultValueInstance = ((string)defaultValueValue);
                                            parameterMetadataInstance.DefaultValue = defaultValueInstance;
                                        }
                                        
                                        JToken constraintsValue = appSettingsValue["constraints"];
                                        if (constraintsValue != null && constraintsValue.Type != JTokenType.Null)
                                        {
                                            ParameterConstraints constraintsInstance = new ParameterConstraints();
                                            parameterMetadataInstance.Constraints = constraintsInstance;
                                            
                                            JToken requiredValue = constraintsValue["required"];
                                            if (requiredValue != null && requiredValue.Type != JTokenType.Null)
                                            {
                                                bool requiredInstance = ((bool)requiredValue);
                                                constraintsInstance.Required = requiredInstance;
                                            }
                                            
                                            JToken hiddenValue = constraintsValue["hidden"];
                                            if (hiddenValue != null && hiddenValue.Type != JTokenType.Null)
                                            {
                                                bool hiddenInstance = ((bool)hiddenValue);
                                                constraintsInstance.Hidden = hiddenInstance;
                                            }
                                            
                                            JToken allowedValuesArray = constraintsValue["allowedValues"];
                                            if (allowedValuesArray != null && allowedValuesArray.Type != JTokenType.Null)
                                            {
                                                foreach (JToken allowedValuesValue in ((JArray)allowedValuesArray))
                                                {
                                                    constraintsInstance.AllowedValues.Add(((string)allowedValuesValue));
                                                }
                                            }
                                            
                                            JToken rangeValue = constraintsValue["range"];
                                            if (rangeValue != null && rangeValue.Type != JTokenType.Null)
                                            {
                                                RangeConstraint rangeInstance = new RangeConstraint();
                                                constraintsInstance.Range = rangeInstance;
                                                
                                                JToken lowerBoundValue = rangeValue["lowerBound"];
                                                if (lowerBoundValue != null && lowerBoundValue.Type != JTokenType.Null)
                                                {
                                                    int lowerBoundInstance = ((int)lowerBoundValue);
                                                    rangeInstance.LowerBound = lowerBoundInstance;
                                                }
                                                
                                                JToken upperBoundValue = rangeValue["upperBound"];
                                                if (upperBoundValue != null && upperBoundValue.Type != JTokenType.Null)
                                                {
                                                    int upperBoundInstance = ((int)upperBoundValue);
                                                    rangeInstance.UpperBound = upperBoundInstance;
                                                }
                                            }
                                            
                                            JToken lengthValue = constraintsValue["length"];
                                            if (lengthValue != null && lengthValue.Type != JTokenType.Null)
                                            {
                                                LengthConstraint lengthInstance = new LengthConstraint();
                                                constraintsInstance.Length = lengthInstance;
                                                
                                                JToken minValue = lengthValue["min"];
                                                if (minValue != null && minValue.Type != JTokenType.Null)
                                                {
                                                    int minInstance = ((int)minValue);
                                                    lengthInstance.Min = minInstance;
                                                }
                                                
                                                JToken maxValue = lengthValue["max"];
                                                if (maxValue != null && maxValue.Type != JTokenType.Null)
                                                {
                                                    int maxInstance = ((int)maxValue);
                                                    lengthInstance.Max = maxInstance;
                                                }
                                            }
                                            
                                            JToken containsCharactersValue = constraintsValue["containsCharacters"];
                                            if (containsCharactersValue != null && containsCharactersValue.Type != JTokenType.Null)
                                            {
                                                string containsCharactersInstance = ((string)containsCharactersValue);
                                                constraintsInstance.ContainsCharacters = containsCharactersInstance;
                                            }
                                            
                                            JToken notContainsCharactersValue = constraintsValue["notContainsCharacters"];
                                            if (notContainsCharactersValue != null && notContainsCharactersValue.Type != JTokenType.Null)
                                            {
                                                string notContainsCharactersInstance = ((string)notContainsCharactersValue);
                                                constraintsInstance.NotContainsCharacters = notContainsCharactersInstance;
                                            }
                                            
                                            JToken hasDigitValue = constraintsValue["hasDigit"];
                                            if (hasDigitValue != null && hasDigitValue.Type != JTokenType.Null)
                                            {
                                                bool hasDigitInstance = ((bool)hasDigitValue);
                                                constraintsInstance.HasDigit = hasDigitInstance;
                                            }
                                            
                                            JToken hasLetterValue = constraintsValue["hasLetter"];
                                            if (hasLetterValue != null && hasLetterValue.Type != JTokenType.Null)
                                            {
                                                bool hasLetterInstance = ((bool)hasLetterValue);
                                                constraintsInstance.HasLetter = hasLetterInstance;
                                            }
                                            
                                            JToken hasPunctuationValue = constraintsValue["hasPunctuation"];
                                            if (hasPunctuationValue != null && hasPunctuationValue.Type != JTokenType.Null)
                                            {
                                                bool hasPunctuationInstance = ((bool)hasPunctuationValue);
                                                constraintsInstance.HasPunctuation = hasPunctuationInstance;
                                            }
                                            
                                            JToken numericValue = constraintsValue["numeric"];
                                            if (numericValue != null && numericValue.Type != JTokenType.Null)
                                            {
                                                bool numericInstance = ((bool)numericValue);
                                                constraintsInstance.Numeric = numericInstance;
                                            }
                                        }
                                    }
                                }
                                
                                JToken dependsOnArray = valueValue["dependsOn"];
                                if (dependsOnArray != null && dependsOnArray.Type != JTokenType.Null)
                                {
                                    foreach (JToken dependsOnValue in ((JArray)dependsOnArray))
                                    {
                                        MicroserviceMetadata microserviceMetadataInstance = new MicroserviceMetadata();
                                        metadataInstance.DependsOn.Add(microserviceMetadataInstance);
                                        
                                        JToken microserviceIdValue2 = dependsOnValue["microserviceId"];
                                        if (microserviceIdValue2 != null && microserviceIdValue2.Type != JTokenType.Null)
                                        {
                                            string microserviceIdInstance2 = ((string)microserviceIdValue2);
                                            microserviceMetadataInstance.MicroserviceId = microserviceIdInstance2;
                                        }
                                        
                                        JToken displayNameValue3 = dependsOnValue["displayName"];
                                        if (displayNameValue3 != null && displayNameValue3.Type != JTokenType.Null)
                                        {
                                            string displayNameInstance3 = ((string)displayNameValue3);
                                            microserviceMetadataInstance.DisplayName = displayNameInstance3;
                                        }
                                        
                                        JToken appSettingsArray2 = dependsOnValue["appSettings"];
                                        if (appSettingsArray2 != null && appSettingsArray2.Type != JTokenType.Null)
                                        {
                                            foreach (JToken appSettingsValue2 in ((JArray)appSettingsArray2))
                                            {
                                                ParameterMetadata parameterMetadataInstance2 = new ParameterMetadata();
                                                microserviceMetadataInstance.Parameters.Add(parameterMetadataInstance2);
                                                
                                                JToken nameValue2 = appSettingsValue2["name"];
                                                if (nameValue2 != null && nameValue2.Type != JTokenType.Null)
                                                {
                                                    string nameInstance2 = ((string)nameValue2);
                                                    parameterMetadataInstance2.Name = nameInstance2;
                                                }
                                                
                                                JToken typeValue2 = appSettingsValue2["type"];
                                                if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                                {
                                                    string typeInstance2 = ((string)typeValue2);
                                                    parameterMetadataInstance2.Type = typeInstance2;
                                                }
                                                
                                                JToken displayNameValue4 = appSettingsValue2["displayName"];
                                                if (displayNameValue4 != null && displayNameValue4.Type != JTokenType.Null)
                                                {
                                                    string displayNameInstance4 = ((string)displayNameValue4);
                                                    parameterMetadataInstance2.DisplayName = displayNameInstance4;
                                                }
                                                
                                                JToken descriptionValue2 = appSettingsValue2["description"];
                                                if (descriptionValue2 != null && descriptionValue2.Type != JTokenType.Null)
                                                {
                                                    string descriptionInstance2 = ((string)descriptionValue2);
                                                    parameterMetadataInstance2.Description = descriptionInstance2;
                                                }
                                                
                                                JToken tooltipValue2 = appSettingsValue2["tooltip"];
                                                if (tooltipValue2 != null && tooltipValue2.Type != JTokenType.Null)
                                                {
                                                    string tooltipInstance2 = ((string)tooltipValue2);
                                                    parameterMetadataInstance2.Tooltip = tooltipInstance2;
                                                }
                                                
                                                JToken uiHintValue2 = appSettingsValue2["uiHint"];
                                                if (uiHintValue2 != null && uiHintValue2.Type != JTokenType.Null)
                                                {
                                                    string uiHintInstance2 = ((string)uiHintValue2);
                                                    parameterMetadataInstance2.UIHint = uiHintInstance2;
                                                }
                                                
                                                JToken defaultValueValue2 = appSettingsValue2["defaultValue"];
                                                if (defaultValueValue2 != null && defaultValueValue2.Type != JTokenType.Null)
                                                {
                                                    string defaultValueInstance2 = ((string)defaultValueValue2);
                                                    parameterMetadataInstance2.DefaultValue = defaultValueInstance2;
                                                }
                                                
                                                JToken constraintsValue2 = appSettingsValue2["constraints"];
                                                if (constraintsValue2 != null && constraintsValue2.Type != JTokenType.Null)
                                                {
                                                    ParameterConstraints constraintsInstance2 = new ParameterConstraints();
                                                    parameterMetadataInstance2.Constraints = constraintsInstance2;
                                                    
                                                    JToken requiredValue2 = constraintsValue2["required"];
                                                    if (requiredValue2 != null && requiredValue2.Type != JTokenType.Null)
                                                    {
                                                        bool requiredInstance2 = ((bool)requiredValue2);
                                                        constraintsInstance2.Required = requiredInstance2;
                                                    }
                                                    
                                                    JToken hiddenValue2 = constraintsValue2["hidden"];
                                                    if (hiddenValue2 != null && hiddenValue2.Type != JTokenType.Null)
                                                    {
                                                        bool hiddenInstance2 = ((bool)hiddenValue2);
                                                        constraintsInstance2.Hidden = hiddenInstance2;
                                                    }
                                                    
                                                    JToken allowedValuesArray2 = constraintsValue2["allowedValues"];
                                                    if (allowedValuesArray2 != null && allowedValuesArray2.Type != JTokenType.Null)
                                                    {
                                                        foreach (JToken allowedValuesValue2 in ((JArray)allowedValuesArray2))
                                                        {
                                                            constraintsInstance2.AllowedValues.Add(((string)allowedValuesValue2));
                                                        }
                                                    }
                                                    
                                                    JToken rangeValue2 = constraintsValue2["range"];
                                                    if (rangeValue2 != null && rangeValue2.Type != JTokenType.Null)
                                                    {
                                                        RangeConstraint rangeInstance2 = new RangeConstraint();
                                                        constraintsInstance2.Range = rangeInstance2;
                                                        
                                                        JToken lowerBoundValue2 = rangeValue2["lowerBound"];
                                                        if (lowerBoundValue2 != null && lowerBoundValue2.Type != JTokenType.Null)
                                                        {
                                                            int lowerBoundInstance2 = ((int)lowerBoundValue2);
                                                            rangeInstance2.LowerBound = lowerBoundInstance2;
                                                        }
                                                        
                                                        JToken upperBoundValue2 = rangeValue2["upperBound"];
                                                        if (upperBoundValue2 != null && upperBoundValue2.Type != JTokenType.Null)
                                                        {
                                                            int upperBoundInstance2 = ((int)upperBoundValue2);
                                                            rangeInstance2.UpperBound = upperBoundInstance2;
                                                        }
                                                    }
                                                    
                                                    JToken lengthValue2 = constraintsValue2["length"];
                                                    if (lengthValue2 != null && lengthValue2.Type != JTokenType.Null)
                                                    {
                                                        LengthConstraint lengthInstance2 = new LengthConstraint();
                                                        constraintsInstance2.Length = lengthInstance2;
                                                        
                                                        JToken minValue2 = lengthValue2["min"];
                                                        if (minValue2 != null && minValue2.Type != JTokenType.Null)
                                                        {
                                                            int minInstance2 = ((int)minValue2);
                                                            lengthInstance2.Min = minInstance2;
                                                        }
                                                        
                                                        JToken maxValue2 = lengthValue2["max"];
                                                        if (maxValue2 != null && maxValue2.Type != JTokenType.Null)
                                                        {
                                                            int maxInstance2 = ((int)maxValue2);
                                                            lengthInstance2.Max = maxInstance2;
                                                        }
                                                    }
                                                    
                                                    JToken containsCharactersValue2 = constraintsValue2["containsCharacters"];
                                                    if (containsCharactersValue2 != null && containsCharactersValue2.Type != JTokenType.Null)
                                                    {
                                                        string containsCharactersInstance2 = ((string)containsCharactersValue2);
                                                        constraintsInstance2.ContainsCharacters = containsCharactersInstance2;
                                                    }
                                                    
                                                    JToken notContainsCharactersValue2 = constraintsValue2["notContainsCharacters"];
                                                    if (notContainsCharactersValue2 != null && notContainsCharactersValue2.Type != JTokenType.Null)
                                                    {
                                                        string notContainsCharactersInstance2 = ((string)notContainsCharactersValue2);
                                                        constraintsInstance2.NotContainsCharacters = notContainsCharactersInstance2;
                                                    }
                                                    
                                                    JToken hasDigitValue2 = constraintsValue2["hasDigit"];
                                                    if (hasDigitValue2 != null && hasDigitValue2.Type != JTokenType.Null)
                                                    {
                                                        bool hasDigitInstance2 = ((bool)hasDigitValue2);
                                                        constraintsInstance2.HasDigit = hasDigitInstance2;
                                                    }
                                                    
                                                    JToken hasLetterValue2 = constraintsValue2["hasLetter"];
                                                    if (hasLetterValue2 != null && hasLetterValue2.Type != JTokenType.Null)
                                                    {
                                                        bool hasLetterInstance2 = ((bool)hasLetterValue2);
                                                        constraintsInstance2.HasLetter = hasLetterInstance2;
                                                    }
                                                    
                                                    JToken hasPunctuationValue2 = constraintsValue2["hasPunctuation"];
                                                    if (hasPunctuationValue2 != null && hasPunctuationValue2.Type != JTokenType.Null)
                                                    {
                                                        bool hasPunctuationInstance2 = ((bool)hasPunctuationValue2);
                                                        constraintsInstance2.HasPunctuation = hasPunctuationInstance2;
                                                    }
                                                    
                                                    JToken numericValue2 = constraintsValue2["numeric"];
                                                    if (numericValue2 != null && numericValue2.Type != JTokenType.Null)
                                                    {
                                                        bool numericInstance2 = ((bool)numericValue2);
                                                        constraintsInstance2.Numeric = numericInstance2;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
