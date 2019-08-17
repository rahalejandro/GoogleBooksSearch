using System;
using System.Collections.Generic;

namespace MiddlewareWebAPI.Model
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Thumbnail { get; set; }

        public string InfoLink { get; set; }
    }
}
