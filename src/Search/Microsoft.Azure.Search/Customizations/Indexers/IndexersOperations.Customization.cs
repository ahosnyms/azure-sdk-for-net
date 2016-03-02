﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models;

    internal partial class IndexersOperations
    {
        /// <inheritdoc />
        public Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(
            string indexerName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExistsHelper.ExistsFromGetResponse(() =>
                this.GetWithHttpMessagesAsync(indexerName, searchRequestOptions, customHeaders, cancellationToken));
        }
    }
}
