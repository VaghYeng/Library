using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;

namespace Library.Models.Entities
{
    public class CreateAuthor
    {
        public string name { get; set; }
    }
        public class Authors : IErrMsg
        {
            public string ErrMsg { get; set; }
            public int AuthorId { get; set; }
            public string Name { get; set; }

            public async Task<List<Authors>> GetAuthorsAsync()
            {
                try
                {
                    List<SPParam> par = new List<SPParam> { };
                    return await MySQLDataAccess<Authors>.ExecuteSPListAsync("GetAuthor", par);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally { }
            }
            public async Task<Authors> AddAuthor(CreateAuthor NewAuthor)
            {
                try
                {
                    List<SPParam> par = new List<SPParam>
                    {
                    new SPParam("name", NewAuthor.name)
                    };
                    var author = await MySQLDataAccess<Authors>.ExecuteSPItemAsync("AddAuthor", par);
                    return author;
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
