// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Graph.RBAC
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure;
    using Models;

    public static partial class UserOperationsExtensions
    {
            /// <summary>
            /// Delete a user.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='user'>
            /// user object id or user principal name
            /// </param>
            public static void Delete(this IUserOperations operations, string user)
            {
                Task.Factory.StartNew(s => ((IUserOperations)s).DeleteAsync(user), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a user.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='user'>
            /// user object id or user principal name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IUserOperations operations, string user, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(user, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a new user.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// Parameters to create a user.
            /// </param>
            public static User Create(this IUserOperations operations, UserCreateParameters parameters)
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).CreateAsync(parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a new user.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// Parameters to create a user.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<User> CreateAsync( this IUserOperations operations, UserCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<User> result = await operations.CreateWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets list of users for the current tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            public static IPage<User> List(this IUserOperations operations, Expression<Func<User, bool>> filter = default(Expression<Func<User, bool>>))
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).ListAsync(filter), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets list of users for the current tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<User>> ListAsync( this IUserOperations operations, Expression<Func<User, bool>> filter = default(Expression<Func<User, bool>>), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IPage<User>> result = await operations.ListWithHttpMessagesAsync(filter, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets user information from the directory.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='upnOrObjectId'>
            /// User object Id or user principal name to get user information.
            /// </param>
            public static User Get(this IUserOperations operations, string upnOrObjectId)
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).GetAsync(upnOrObjectId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets user information from the directory.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='upnOrObjectId'>
            /// User object Id or user principal name to get user information.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<User> GetAsync( this IUserOperations operations, string upnOrObjectId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<User> result = await operations.GetWithHttpMessagesAsync(upnOrObjectId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a collection that contains the Object IDs of the groups of which the
            /// user is a member.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='objectId'>
            /// User filtering parameters.
            /// </param>
            /// <param name='parameters'>
            /// User filtering parameters.
            /// </param>
            public static IPage<string> GetMemberGroups(this IUserOperations operations, string objectId, UserGetMemberGroupsParameters parameters)
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).GetMemberGroupsAsync(objectId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a collection that contains the Object IDs of the groups of which the
            /// user is a member.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='objectId'>
            /// User filtering parameters.
            /// </param>
            /// <param name='parameters'>
            /// User filtering parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<string>> GetMemberGroupsAsync( this IUserOperations operations, string objectId, UserGetMemberGroupsParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IPage<string>> result = await operations.GetMemberGroupsWithHttpMessagesAsync(objectId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets list of users for the current tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<User> ListNext(this IUserOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets list of users for the current tenant.
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
            public static async Task<IPage<User>> ListNextAsync( this IUserOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IPage<User>> result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a collection that contains the Object IDs of the groups of which the
            /// user is a member.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<string> GetMemberGroupsNext(this IUserOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IUserOperations)s).GetMemberGroupsNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a collection that contains the Object IDs of the groups of which the
            /// user is a member.
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
            public static async Task<IPage<string>> GetMemberGroupsNextAsync( this IUserOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IPage<string>> result = await operations.GetMemberGroupsNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
