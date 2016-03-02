// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;

    internal class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public override bool Equals(object obj)
        {
            Book other = obj as Book;

            if (other == null)
            {
                return false;
            }

            return 
<<<<<<< HEAD
                ISBN == other.ISBN && 
                Title == other.Title && 
                Author == other.Author &&
                PublishDate == other.PublishDate;
=======
                this.ISBN == other.ISBN &&
                this.Title == other.Title &&
                this.Author == other.Author &&
                this.PublishDate == other.PublishDate;
>>>>>>> origin/AutoRest
        }

        public override int GetHashCode()
        {
            return (this.ISBN != null) ? this.ISBN.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format(
<<<<<<< HEAD
                "ISBN: {0}; Title: {1}; Author: {2}; PublishDate: {3}", 
                ISBN, 
                Title, 
                Author, 
                PublishDate);
=======
                "ISBN: {0}; Title: {1}; Author: {2}; PublishDate: {3}",
                this.ISBN,
                this.Title,
                this.Author,
                this.PublishDate);
>>>>>>> origin/AutoRest
        }
    }
}
