using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MicroConsole
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }

    [EnableCors(origins:"*", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        Book[] books = new Book[]
        {
        new Book{ISBN="978-0-85783-307-1", Name="101 Things for kids", Author="Dawn Issac"},
        new Book{ISBN="987-0-88753-370-5", Name="Pricess Cinderella", Author="Disney Books"}
        };

        //GET api/books
        public IEnumerable<Book> Get()
        {
            return books;
        }

        //GET api/books/ISBN
        public Book Get(string isbn)
        {
            try
            {
                return (books.Where(b=>b.ISBN==isbn).ToArray())[0];
            }
            catch (Exception ex)
            {
                return new Book();
            }
        }
    }
}
