using Library.Models;
using Library.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Library.Models.Entities.CreateMember;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        [HttpGet("GetBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            List<Books> Books = await new Books().GetBooksAsync();
            return Ok(Books);
        }

        [HttpPost("AddNewBook")]
        public async Task<ActionResult> AddNewBook([FromBody] CreateBook NewBooks)
        {
            var book = await new Books().AddNewBookAsync(NewBooks);
            if (book.ErrMsg == "The Author does not exist")
                return NotFound(book.ErrMsg);
            
            return Ok(book.ErrMsg); 
        }
        [HttpPost("BorrowBook")]
        public async Task<ActionResult> BorrowBook(int bookid, int memberid)
        {
            var res = await new Books().BorrowBookAsync(bookid, memberid);
            if (res.ErrMsg == "This book is not available now or book does not exist")
                return NotFound(res.ErrMsg);
            else if (res.ErrMsg == "Member does not exist")
                return BadRequest(res.ErrMsg);
            return Ok(res.ErrMsg); 
        }
        [HttpPost("ReturnBook")]
        public async Task<ActionResult> ReturnBook(int bid)
        {
            var res = await new Books().ReturnBookAsync(bid);
            if (res.ErrMsg == "This book is here")
                return Created();
            else if (res.ErrMsg == "This book does not exist")
                return NotFound(res.ErrMsg);
            else 
                return Ok(res.ErrMsg);

        }
        
        [HttpGet("ReturnAllBooks")]
        public async Task<ActionResult> AllBooks()
        {
            var res = await new ListOfBorrowedBooks().ReturnBooksListAsync();
            return Ok(res);
        }

        [HttpGet("GetAuthors")]
        public async Task<ActionResult> Authors()
        {
            var res  = await new Authors().GetAuthorsAsync();
            return Ok(res);
        }
        [HttpPost("AddNEwAuthor")]
        public async Task<ActionResult> AddNEwAuthor([FromBody] CreateAuthor newAuthor)
        {
            var author = await new Authors().AddAuthor(newAuthor);
            return Ok(author);
        
        }

        [HttpPost("AddNewMember")]
        public async Task<ActionResult> Registration([FromBody] CreateMember newMember)
        {
            var resp = await new Members().MemberRegisterAsync(newMember);
            return Ok(resp);
        }

    }
}
