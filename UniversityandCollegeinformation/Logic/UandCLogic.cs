using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using UniversityandCollegeinformation.collegedto;
using UniversityandCollegeinformation.DTO;
using UniversityandCollegeinformation.Interface;

namespace UniversityandCollegeinformation.Logic
{
    public class UandCLogic: UandCInterface
    {
        string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=student;Integrated Security=True;";
        public async Task<List<UandCDto>> UandCDetails()
        {
            IDbConnection obj = new SqlConnection(connectionstring);
            obj.Open();
            var DTO =obj.Query<UandCDto>("select c.collegename,u.universityname from university u  inner join  college c on u.universityid=c.universityid");

            obj.Close();
             var Result=DTO.ToList();
            return Result;
        }
        public int AddcollegeData(CollegesDto  dto )
        {
            IDbConnection obj = new SqlConnection(connectionstring);
            obj.Open();
            var result = obj.Execute("insert into college(collegeid,collegename,universityid)values(@collegeid,@collegename,@universityid)",
                 new { collegeid = dto.collegeid, collegename = dto.collegename, universityid = dto.universityid });
            obj.Close();
            return result ;
       
        }
        public int CollegeData(string  Collegename ,int collegeid)
        {
            IDbConnection obj = new SqlConnection(connectionstring);
            obj.Open();
            var result = obj.Execute("update college set collegename=@cname where collegeid=@cid",new { cname=Collegename,cid=collegeid });
                obj.Close();
              return result;
        }























        public int UpdateUniversity(int universityid,string universityname)
        {
            IDbConnection obj = new SqlConnection(connectionstring);
            obj.Open();
          int Data = obj.Execute("Update University set Universityname=@uname where Universityid=@uid", new { uname = universityname, uid = universityid });
            obj.Close();
            return Data;
        }




    }
}
