using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Books.v1;
using MiddlewareWebAPI.Model;

namespace MiddlewareWebAPI.Service
{
    public class BooksMiddlewareService : IBooksMiddlewareService
    {
        public async Task<IEnumerable<Book>> SearchBooks(string query)
        {
            BooksService booksService = new BooksService();

            var request = booksService.Volumes.List(query);
            request.MaxResults = 20;
            var response = await request.ExecuteAsync();

            var books = response.Items.Select(item => new Book
            {
                Id = item.Id,
                Title = item.VolumeInfo.Title,
                Authors = item.VolumeInfo.Authors,
                Thumbnail = item.VolumeInfo.ImageLinks == null ? null : item.VolumeInfo.ImageLinks.Thumbnail,
                InfoLink = item.VolumeInfo.InfoLink
            });

            return books;
        }
    }
}
