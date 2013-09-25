using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LindugRest.Models;

namespace LindugRest.Api
{
    public class DemoController : ApiController
    {
        private IBooksRepository _repo = new BooksRepository();

        public IEnumerable<Book> Get()
        {
            return _repo.GetBooks();
        }

        public Book Get(int id)
        {
            return _repo.GetBook(id);
        }
    }
}
