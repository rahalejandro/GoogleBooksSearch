using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MiddlewareWebAPI.Model;

namespace MiddlewareWebAPI.Service
{
    public  interface IBooksMiddlewareService
    {
        Task<IEnumerable<Book>> SearchBooks(string query);
    }
}
