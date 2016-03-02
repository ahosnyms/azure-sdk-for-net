<<<<<<< HEAD
﻿// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
=======
﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

>>>>>>> origin/AutoRest
    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public abstract class SuggestTests : QueryTests
    {
        protected void TestCanSuggestStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
                client.Documents.Suggest<Hotel>("good", "sg", suggestParameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("good", "sg", suggestParameters);

>>>>>>> origin/AutoRest
            Assert.Null(response.Coverage);
            Assert.NotNull(response.Results);

            IEnumerable<Hotel> expectedDocs =
                Data.TestDocuments.Where(h => h.HotelId == "4" || h.HotelId == "5").OrderBy(h => h.HotelId);
                
            SearchAssert.SequenceEqual(
                expectedDocs,
                response.Results.Select(r => r.Document));

            SearchAssert.SequenceEqual(
                expectedDocs.Select(h => h.Description),
                response.Results.Select(r => r.Text));
        }

        protected void TestCanSuggestDynamicDocuments()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
<<<<<<< HEAD
            DocumentSuggestResponse response = client.Documents.Suggest("good", "sg", suggestParameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult response = client.Documents.Suggest("good", "sg", suggestParameters);

>>>>>>> origin/AutoRest
            Assert.Null(response.Coverage);
            Assert.NotNull(response.Results);

            Document[] expectedDocs =
                Data.TestDocuments
                    .Where(h => h.HotelId == "4" || h.HotelId == "5")
                    .OrderBy(h => h.HotelId)
                    .Select(h => h.AsDocument())
                    .ToArray();

            Assert.Equal(expectedDocs.Length, response.Results.Count);
            for (int i = 0; i < expectedDocs.Length; i++)
            {
                SearchAssert.DocumentsEqual(expectedDocs[i], response.Results[i].Document);
                Assert.Equal(expectedDocs[i]["description"], response.Results[i].Text);
            }
        }

        protected void TestSuggestThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClient();

            var invalidParameters = new SuggestParameters() { OrderBy = new[] { "This is not a valid orderby." } };
            CloudException e =
                Assert.Throws<CloudException>(() => client.Documents.Suggest("hotel", "sg", invalidParameters));

            Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
            Assert.Contains(
                "Invalid expression: Syntax error at position 7 in 'This is not a valid orderby.'",
                e.Message);
        }

        protected void TestSuggestThrowsWhenGivenBadSuggesterName()
        {
            SearchIndexClient client = GetClient();

            CloudException e =
                Assert.Throws<CloudException>(
                    () => client.Documents.Suggest("hotel", "Suggester does not exist", new SuggestParameters()));

            Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
            Assert.Contains(
                "The specified suggester name 'Suggester does not exist' does not exist in this index definition.",
                e.Message);
        }

        protected void TestFuzzyIsOffByDefault()
        {
            SearchIndexClient client = GetClientForQuery();
<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg");

>>>>>>> origin/AutoRest
            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestCanGetFuzzySuggestions()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { UseFuzzyMatching = true };
<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg", suggestParameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg", suggestParameters);

>>>>>>> origin/AutoRest
            Assert.NotNull(response.Results);
            Assert.Equal(5, response.Results.Count);
        }

        protected void TestCanFilter()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters() { Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z" };
<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
=======
            DocumentSuggestResult<Hotel> response =
>>>>>>> origin/AutoRest
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "5");
        }

        protected void TestCanUseHitHighlighting()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    Filter = "category eq 'Luxury'",
                    Top = 1
                };

<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
=======
            DocumentSuggestResult<Hotel> response =
>>>>>>> origin/AutoRest
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1");

<<<<<<< HEAD
            // Note: Highlighting is not perfect due to the way Azure Search builds edge n-grams for suggestions.
            Assert.True(
                response.Results[0].Text.StartsWith("Best <b>hotel in</b> town", StringComparison.Ordinal));
=======
            Assert.True(
                response.Results[0].Text.StartsWith("Best <b>hotel</b> in town", StringComparison.Ordinal),
                String.Format(CultureInfo.InvariantCulture, "Actual text: {0}", response.Results[0].Text));
>>>>>>> origin/AutoRest
        }

        protected void TestOrderByProgressivelyBreaksTies()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    OrderBy = new string[] 
                    { 
                        "rating desc",
                        "lastRenovationDate asc",
                        "geo.distance(location, geography'POINT(-122.0 49.0)')"
                    }
                };

<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
=======
            DocumentSuggestResult<Hotel> response =
>>>>>>> origin/AutoRest
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "4", "3", "5", "2");
        }

        protected void TestTopTrimsResults()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    OrderBy = new string[] { "hotelId" },
                    Top = 3
                };

<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
=======
            DocumentSuggestResult<Hotel> response =
>>>>>>> origin/AutoRest
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "2", "3");
        }

        protected void TestCanSuggestWithSelectedFields()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    Select = new[] { "hotelName", "baseRate" }
                };

<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
=======
            DocumentSuggestResult<Hotel> response =
>>>>>>> origin/AutoRest
                client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

            var expectedDoc = new Hotel() { HotelName = "Fancy Stay", BaseRate = 199.0 };

<<<<<<< HEAD
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
>>>>>>> origin/AutoRest
            Assert.NotNull(response.Results);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestSearchFieldsExcludesFieldsFromSuggest()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    SearchFields = new[] { "hotelName" },
                };

<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response =
                client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

>>>>>>> origin/AutoRest
            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestCanSuggestWithMinimumCoverage()
        {
            SearchIndexClient client = GetClientForQuery();

            var parameters = new SuggestParameters() { MinimumCoverage = 50 };
<<<<<<< HEAD
            DocumentSuggestResponse<Hotel> response = client.Documents.Suggest<Hotel>("luxury", "sg", parameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Hotel> response = client.Documents.Suggest<Hotel>("luxury", "sg", parameters);

>>>>>>> origin/AutoRest
            Assert.Equal(100, response.Coverage);
        }

        protected void TestCanSuggestWithDateTimeInStaticModel()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index =
                new Index()
                {
<<<<<<< HEAD
                    Name = TestUtilities.GenerateName(),
=======
                    Name = SearchTestUtilities.GenerateName(),
>>>>>>> origin/AutoRest
                    Fields = new[]
                    {
                        new Field("ISBN", DataType.String) { IsKey = true },
                        new Field("Title", DataType.String) { IsSearchable = true },
                        new Field("Author", DataType.String),
                        new Field("PublishDate", DataType.DateTimeOffset)
                    },
                    Suggesters = new[] { new Suggester("sg", SuggesterSearchMode.AnalyzingInfixMatching, "Title") }
                };

<<<<<<< HEAD
            IndexDefinitionResponse createIndexResponse = serviceClient.Indexes.Create(index);
            SearchIndexClient indexClient = Data.GetSearchIndexClient(createIndexResponse.Index.Name);

            var doc1 = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" };
            var doc2 = new Book() { ISBN = "456", Title = "War and Peace", PublishDate = new DateTime(2015, 8, 18) };
            var batch = IndexBatch.Create(IndexAction.Create(doc1), IndexAction.Create(doc2));
=======
            serviceClient.Indexes.Create(index);
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

            var doc1 = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" };
            var doc2 = new Book() { ISBN = "456", Title = "War and Peace", PublishDate = new DateTime(2015, 8, 18) };
            var batch = IndexBatch.Upload(new[] { doc1, doc2 });
>>>>>>> origin/AutoRest

            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            var parameters = new SuggestParameters() { Select = new[] { "ISBN", "Title", "PublishDate" } };
<<<<<<< HEAD
            DocumentSuggestResponse<Book> response = indexClient.Documents.Suggest<Book>("War", "sg", parameters);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
=======
            DocumentSuggestResult<Book> response = indexClient.Documents.Suggest<Book>("War", "sg", parameters);
>>>>>>> origin/AutoRest
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc2, response.Results[0].Document);
        }

        private void AssertKeySequenceEqual(DocumentSuggestResult<Hotel> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            SearchAssert.SequenceEqual(expectedKeys, actualKeys);
        }
    }
}
