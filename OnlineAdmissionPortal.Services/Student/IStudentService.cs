using Entity.Admission;
using Entity.Common;
using Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Student
{
    public interface IStudentService
    {
        public List<StudentInfo> GetStudents(StudentInfo student);
        public StudentInfo GetStudentDetails(int id);
        public BoolResponse RegisterStudent(StudentInfo student);
        public BoolResponse TakeAdmission(Admission admission);
    }
}
