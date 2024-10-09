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
        public List<Student> GetStudents(Student student);
    }
}
