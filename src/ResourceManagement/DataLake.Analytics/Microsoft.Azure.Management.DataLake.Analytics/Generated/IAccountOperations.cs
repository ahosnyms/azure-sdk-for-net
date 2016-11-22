// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Analytics
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// AccountOperations operations.
    /// </summary>
    public partial interface IAccountOperations
    {
        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any,
        /// within a specific resource group. This includes a link to the
        /// next page, if any.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='odataQuery'>
        /// OData parameters to apply to the operation.
        /// </param>
        /// <param name='select'>
        /// OData Select statement. Limits the properties on each entry to
        /// just those requested, e.g.
        /// Categories?$select=CategoryName,Description. Optional.
        /// </param>
        /// <param name='count'>
        /// The Boolean value of true or false to request a count of the
        /// matching resources included with the resources in the response,
        /// e.g. Categories?$count=true. Optional.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DataLakeAnalyticsAccount>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, ODataQuery<DataLakeAnalyticsAccount> odataQuery = default(ODataQuery<DataLakeAnalyticsAccount>), string select = default(string), bool? count = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any,
        /// within the current subscription. This includes a link to the next
        /// page, if any.
        /// </summary>
        /// <param name='odataQuery'>
        /// OData parameters to apply to the operation.
        /// </param>
        /// <param name='select'>
        /// OData Select statement. Limits the properties on each entry to
        /// just those requested, e.g.
        /// Categories?$select=CategoryName,Description. Optional.
        /// </param>
        /// <param name='count'>
        /// The Boolean value of true or false to request a count of the
        /// matching resources included with the resources in the response,
        /// e.g. Categories?$count=true. Optional.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DataLakeAnalyticsAccount>>> ListWithHttpMessagesAsync(ODataQuery<DataLakeAnalyticsAccount> odataQuery = default(ODataQuery<DataLakeAnalyticsAccount>), string select = default(string), bool? count = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets details of the specified Data Lake Analytics account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Data Lake Analytics account to retrieve.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DataLakeAnalyticsAccount>> GetWithHttpMessagesAsync(string resourceGroupName, string accountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Begins the delete delete process for the Data Lake Analytics
        /// account object specified by the account name.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Data Lake Analytics account to delete
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string accountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Begins the delete delete process for the Data Lake Analytics
        /// account object specified by the account name.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Data Lake Analytics account to delete
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string accountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates the specified Data Lake Analytics account. This supplies
        /// the user with computation services for Data Lake Analytics
        /// workloads
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.the account will be associated with.
        /// </param>
        /// <param name='name'>
        /// The name of the Data Lake Analytics account to create.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create Data Lake Analytics account
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DataLakeAnalyticsAccount>> CreateWithHttpMessagesAsync(string resourceGroupName, string name, DataLakeAnalyticsAccount parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates the specified Data Lake Analytics account. This supplies
        /// the user with computation services for Data Lake Analytics
        /// workloads
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.the account will be associated with.
        /// </param>
        /// <param name='name'>
        /// The name of the Data Lake Analytics account to create.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create Data Lake Analytics account
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DataLakeAnalyticsAccount>> BeginCreateWithHttpMessagesAsync(string resourceGroupName, string name, DataLakeAnalyticsAccount parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the Data Lake Analytics account object specified by the
        /// accountName with the contents of the account object.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='name'>
        /// The name of the Data Lake Analytics account to update.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the update Data Lake Analytics account
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DataLakeAnalyticsAccount>> UpdateWithHttpMessagesAsync(string resourceGroupName, string name, DataLakeAnalyticsAccountUpdateParameters parameters = default(DataLakeAnalyticsAccountUpdateParameters), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the Data Lake Analytics account object specified by the
        /// accountName with the contents of the account object.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the Azure resource group that contains the Data Lake
        /// Analytics account.
        /// </param>
        /// <param name='name'>
        /// The name of the Data Lake Analytics account to update.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the update Data Lake Analytics account
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DataLakeAnalyticsAccount>> BeginUpdateWithHttpMessagesAsync(string resourceGroupName, string name, DataLakeAnalyticsAccountUpdateParameters parameters = default(DataLakeAnalyticsAccountUpdateParameters), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any,
        /// within a specific resource group. This includes a link to the
        /// next page, if any.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DataLakeAnalyticsAccount>>> ListByResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any,
        /// within the current subscription. This includes a link to the next
        /// page, if any.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DataLakeAnalyticsAccount>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
