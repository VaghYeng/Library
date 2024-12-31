using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;

namespace Library.Models.Entities
{
    public class CreateMember
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public class Members : IErrMsg
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public string ErrMsg { get; set; }
    
    public async Task<Members> MemberRegisterAsync(CreateMember NewMember)
            {
                try
                {
                    List<SPParam> par = new List<SPParam>
                {
                    new SPParam("name",  NewMember.FullName),
                    new SPParam("email", NewMember.Email),
                 };

                    var member = await MySQLDataAccess<Members>.ExecuteSPItemAsync("MemberRegister", par);
                    return member;
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


}
