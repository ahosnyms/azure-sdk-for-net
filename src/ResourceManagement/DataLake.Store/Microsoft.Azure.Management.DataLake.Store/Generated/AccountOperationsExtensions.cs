// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Store
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for AccountOperations.
    /// </summary>
    public static partial class AccountOperationsExtensions
    {
            /// <summary>
            /// Creates the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to create.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the Data Lake Store account.
            /// </param>
            public static DataLakeStoreAccount Create(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccount parameters)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).CreateAsync(resourceGroupName, name, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to create.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the Data Lake Store account.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataLakeStoreAccount> CreateAsync(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccount parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, name, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to create.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the Data Lake Store account.
            /// </param>
            public static DataLakeStoreAccount BeginCreate(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccount parameters)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).BeginCreateAsync(resourceGroupName, name, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to create.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the Data Lake Store account.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataLakeStoreAccount> BeginCreateAsync(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccount parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateWithHttpMessagesAsync(resourceGroupName, name, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the specified Data Lake Store account information.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to update.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the Data Lake Store account.
            /// </param>
            public static DataLakeStoreAccount Update(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccountUpdateParameters parameters)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).UpdateAsync(resourceGroupName, name, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the specified Data Lake Store account information.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to update.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the Data Lake Store account.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataLakeStoreAccount> UpdateAsync(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccountUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the specified Data Lake Store account information.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to update.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the Data Lake Store account.
            /// </param>
            public static DataLakeStoreAccount BeginUpdate(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccountUpdateParameters parameters)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).BeginUpdateAsync(resourceGroupName, name, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the specified Data Lake Store account information.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='name'>
            /// The name of the Data Lake Store account to update.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the Data Lake Store account.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataLakeStoreAccount> BeginUpdateAsync(this IAccountOperations operations, string resourceGroupName, string name, DataLakeStoreAccountUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to delete.
            /// </param>
            public static void Delete(this IAccountOperations operations, string resourceGroupName, string accountName)
            {
                Task.Factory.StartNew(s => ((IAccountOperations)s).DeleteAsync(resourceGroupName, accountName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to delete.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IAccountOperations operations, string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, accountName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Deletes the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to delete.
            /// </param>
            public static void BeginDelete(this IAccountOperations operations, string resourceGroupName, string accountName)
            {
                Task.Factory.StartNew(s => ((IAccountOperations)s).BeginDeleteAsync(resourceGroupName, accountName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to delete.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IAccountOperations operations, string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, accountName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to retrieve.
            /// </param>
            public static DataLakeStoreAccount Get(this IAccountOperations operations, string resourceGroupName, string accountName)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).GetAsync(resourceGroupName, accountName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to retrieve.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataLakeStoreAccount> GetAsync(this IAccountOperations operations, string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, accountName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Attempts to enable a user managed key vault for encryption of the
            /// specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to attempt to enable the Key Vault
            /// for.
            /// </param>
            public static void EnableKeyVault(this IAccountOperations operations, string resourceGroupName, string accountName)
            {
                Task.Factory.StartNew(s => ((IAccountOperations)s).EnableKeyVaultAsync(resourceGroupName, accountName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Attempts to enable a user managed key vault for encryption of the
            /// specified Data Lake Store account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account.
            /// </param>
            /// <param name='accountName'>
            /// The name of the Data Lake Store account to attempt to enable the Key Vault
            /// for.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task EnableKeyVaultAsync(this IAccountOperations operations, string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.EnableKeyVaultWithHttpMessagesAsync(resourceGroupName, accountName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within a specific resource group. The
            /// response includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account(s).
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='select'>
            /// OData Select statement. Limits the properties on each entry to just those
            /// requested, e.g. Categories?$select=CategoryName,Description. Optional.
            /// </param>
            /// <param name='count'>
            /// A Boolean value of true or false to request a count of the matching
            /// resources included with the resources in the response, e.g.
            /// Categories?$count=true. Optional.
            /// </param>
            public static IPage<DataLakeStoreAccount> ListByResourceGroup(this IAccountOperations operations, string resourceGroupName, ODataQuery<DataLakeStoreAccount> odataQuery = default(ODataQuery<DataLakeStoreAccount>), string select = default(string), bool? count = default(bool?))
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).ListByResourceGroupAsync(resourceGroupName, odataQuery, select, count), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within a specific resource group. The
            /// response includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Azure resource group that contains the Data Lake Store
            /// account(s).
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='select'>
            /// OData Select statement. Limits the properties on each entry to just those
            /// requested, e.g. Categories?$select=CategoryName,Description. Optional.
            /// </param>
            /// <param name='count'>
            /// A Boolean value of true or false to request a count of the matching
            /// resources included with the resources in the response, e.g.
            /// Categories?$count=true. Optional.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataLakeStoreAccount>> ListByResourceGroupAsync(this IAccountOperations operations, string resourceGroupName, ODataQuery<DataLakeStoreAccount> odataQuery = default(ODataQuery<DataLakeStoreAccount>), string select = default(string), bool? count = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, odataQuery, select, count, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within the subscription. The response
            /// includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='select'>
            /// OData Select statement. Limits the properties on each entry to just those
            /// requested, e.g. Categories?$select=CategoryName,Description. Optional.
            /// </param>
            /// <param name='count'>
            /// The Boolean value of true or false to request a count of the matching
            /// resources included with the resources in the response, e.g.
            /// Categories?$count=true. Optional.
            /// </param>
            public static IPage<DataLakeStoreAccount> List(this IAccountOperations operations, ODataQuery<DataLakeStoreAccount> odataQuery = default(ODataQuery<DataLakeStoreAccount>), string select = default(string), bool? count = default(bool?))
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).ListAsync(odataQuery, select, count), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within the subscription. The response
            /// includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='select'>
            /// OData Select statement. Limits the properties on each entry to just those
            /// requested, e.g. Categories?$select=CategoryName,Description. Optional.
            /// </param>
            /// <param name='count'>
            /// The Boolean value of true or false to request a count of the matching
            /// resources included with the resources in the response, e.g.
            /// Categories?$count=true. Optional.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataLakeStoreAccount>> ListAsync(this IAccountOperations operations, ODataQuery<DataLakeStoreAccount> odataQuery = default(ODataQuery<DataLakeStoreAccount>), string select = default(string), bool? count = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(odataQuery, select, count, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within a specific resource group. The
            /// response includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DataLakeStoreAccount> ListByResourceGroupNext(this IAccountOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).ListByResourceGroupNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within a specific resource group. The
            /// response includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataLakeStoreAccount>> ListByResourceGroupNextAsync(this IAccountOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within the subscription. The response
            /// includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DataLakeStoreAccount> ListNext(this IAccountOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IAccountOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the Data Lake Store accounts within the subscription. The response
            /// includes a link to the next page of results, if any.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataLakeStoreAccount>> ListNextAsync(this IAccountOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
