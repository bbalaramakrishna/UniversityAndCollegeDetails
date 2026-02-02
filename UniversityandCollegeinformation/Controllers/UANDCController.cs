using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityandCollegeinformation.collegedto;
using UniversityandCollegeinformation.Interface;
using UniversityandCollegeinformation.Logic;

namespace UniversityandCollegeinformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UANDCController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>  Universityandcollege()
        {
            UandCInterface obj =new UandCLogic();
           var result = await obj.UandCDetails();
            return Ok(result);

        }

        [HttpPost]
        public IActionResult Collegedata(CollegesDto dtocollege)
        {
            if (dtocollege != null)
            {
                UandCInterface obj = new UandCLogic();
                var result = obj.AddcollegeData(dtocollege);
                string message = " ";
                if (result > 0)
                {
                    message = "Data inserted successfully";
                }
                else
                {
                    message = "Data insertion failed";
                }

                return Ok(message);
            }
            else
            {
                return BadRequest("Invalid college data");
            }

        }
        [Route("updatecollege")]
        [HttpPut]
       public IActionResult UpdateCollegeData(string collegeName,int collegeId)
        {
            UandCInterface obj =new UandCLogic();

        var result    =obj.CollegeData(collegeName, collegeId);

            string message="";
            if (result>0)
            {
                message="updated succesful";

            }
            else
            {
                message="not updated";
            }

                return Ok(message);
       }
        [Route("updatedata")]
        [HttpPut]
        public IActionResult UpdateData(string Uname,int uid )
        {
            UandCInterface obj = new  UandCLogic();
            var result = obj.UpdateUniversity(uid, Uname);

            string message = "";
            if (result>0)
            {
                message="inserted succesfully";
                    
            }
            else
            {
                message="not successful";
            }


                return Ok(message);

                         
        }

    }
}
