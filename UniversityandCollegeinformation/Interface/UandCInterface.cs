using UniversityandCollegeinformation.collegedto;
using UniversityandCollegeinformation.DTO;

namespace UniversityandCollegeinformation.Interface
{
    public interface UandCInterface
    {
       Task< List<UandCDto>> UandCDetails();
        int AddcollegeData(CollegesDto dto);
        int CollegeData(string Collegename, int collegeid);
        int UpdateUniversity(int universityid, string universityname);
    }
}
