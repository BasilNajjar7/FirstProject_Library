using FirstProject_Library.Data;
using FirstProject_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public readonly ApplicationDbContext _dbcontext;
        public BookController(ApplicationDbContext dbcontect)
        {
            _dbcontext=dbcontect;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Book>>Get()
        {
            var record = _dbcontext.Set<Book>().ToList();
            return Ok(record);
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id)
        {
            var record = _dbcontext.Set<Book>().Find(Id);
            return (record == null ? NotFound() : Ok(record));
        }
        [HttpPost]
        [Route("")]
        public ActionResult<int> AddNewBook(BookReceive book)
        {
            book.Id = 0;
            Book NewBook = new Book
            {
                Id = 0,
                Title = book.Title,
                Auther = book.Auther,
                Description = book.Description,
                EmployeeId = book.EmployeeId
            };
            _dbcontext.Set<Book>().Add(NewBook);
            _dbcontext.SaveChanges(); 
            return Ok(NewBook.Id);
        }
        [HttpPut]
        [Route("")]
        public ActionResult UpdateBook(BookReceive book)
        {
            var LastBook = _dbcontext.Set<Book>().Find(book.Id);
            if(LastBook == null)return NotFound();
            LastBook.Id = book.Id;
            LastBook.Title = book.Title;
            LastBook.Auther = book.Auther;
            LastBook.EmployeeId = book.EmployeeId;
            LastBook.Description = book.Description;
            _dbcontext.Set<Book>().Update(LastBook);
            _dbcontext.SaveChanges();
            return Ok(LastBook);
        }
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeletBook(int Id)
        {
            var ExistingBook = _dbcontext.Set<Book>().Find(Id);
            if(ExistingBook == null) return NotFound();
            _dbcontext.Set<Book>().Remove(ExistingBook);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}