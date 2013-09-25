using System.Linq;
using System.Web.Http.OData;
using LindugRest.Models;

namespace LindugRest.Api
{
    public class HypermediaBooksController : EntitySetController<Book, int>
    {
        private readonly IBooksRepository _repo = new BooksRepository();

        // GET odata/hypermediaBooks
        public override IQueryable<Book> Get()
        {
            return _repo.GetBooks().AsQueryable();
        }

        // GET odata/hypermediaBooks(3)
        protected override Book GetEntityByKey(int key)
        {
            return _repo.GetBook(key);
        }
    }
}