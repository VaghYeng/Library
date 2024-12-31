using DataAccessLayer.Interfaces;
using DataAccessLayer.DBTools;
using System.Linq.Expressions;

namespace Library.Models.Entities
{


    public class CreateBook
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }

    }
    public class Books : IErrMsg
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsAvailable { get; set; }
        public string ErrMsg { get; set; }

        public async Task<List<Books>> GetBooksAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                };
                return await MySQLDataAccess<Books>.ExecuteSPListAsync("GetAllBooks", par);
            }
            catch (Exception ex)
            {


                Console.WriteLine($"Func: Student.GetStudents, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }

        public async Task<Books> AddNewBookAsync(CreateBook NewBook)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("Title",  NewBook.Title),
                    new SPParam("AuthorId", NewBook.AuthorId),
                    new SPParam("Genre", NewBook.Genre)
                 };

                var item = await MySQLDataAccess<Books>.ExecuteSPItemAsync("AddNewBook", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { }
        }

        public async Task<Books> BorrowBookAsync(int bid, int memid)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("bid", bid),
                    new SPParam("memid", memid)
                };
                var item = await MySQLDataAccess<Books>.ExecuteSPItemAsync("BorrowBook", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
            finally
            {

            }
        }

        public async Task<Books> ReturnBookAsync(int bid)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("bid" , bid)
                };
                var book = await MySQLDataAccess<Books>.ExecuteSPItemAsync("ReturnBook", par);
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { }
        }
        public async Task<List<Books>> ReturnBooksListAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam> { };
                var books = await MySQLDataAccess<Books>.ExecuteSPListAsync("ReturnBooksList", par);
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { }
        }

    }

    public class ListOfBorrowedBooks : IErrMsg
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Retruned { get; set; }
        public string ErrMsg { get; set; }

        public async Task<List<ListOfBorrowedBooks>> ReturnBooksListAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam> { };

                var books = await MySQLDataAccess<ListOfBorrowedBooks>.ExecuteSPListAsync("ReturnBooksList", par);
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { }
        }
    }
}
