using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.AddControllers{

    [ApiController]

    [Route("[controller]s")]
    public class BookController: ControllerBase
    {
        private readonly BookStoreDBContext _context;
        public BookController(BookStoreDBContext context){
            _context=context;
        }  
        // private static List<Book> BookList= new List<Book>()
        // {
           
        // };

        [HttpGet]
        public List<Book> GetBooks(){
            var bookList= _context.Books.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;
        }
         [HttpGet("{id}")]
        public Book GetById(int id){
            var book= _context.Books.Where(x=>x.Id==id).SingleOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book= _context.Books.SingleOrDefault(x=>x.Title==newBook.Title);
            if (book is not null){
                return BadRequest();
            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book=_context.Books.SingleOrDefault(x=>x.Id==id);
            if(book is null)
                return BadRequest();
            
            book.GenreId=updateBook.GenreId !=default ? updateBook.GenreId:book.GenreId;
            book.Id=updateBook.Id!=default? updateBook.Id:book.Id;
            book.Title=updateBook.Title!=default? updateBook.Title:book.Title;
            book.PublishDate=updateBook.PublishDate!=default? updateBook.PublishDate:book.PublishDate;
            
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book= _context.Books.SingleOrDefault(x=>x.Id==id);
            if(book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}