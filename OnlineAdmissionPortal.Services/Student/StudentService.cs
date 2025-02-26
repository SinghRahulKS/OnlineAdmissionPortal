using Dapper;
using DataContext.Repository.Dapper;
using Entity.Admission;
using Entity.Common;
using Entity.Student;
using Entity.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IDapperRepository _dapperRepository;
        public StudentService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }
        public StudentInfo GetStudentDetails(int id)
        {
            var studentInfo = new StudentInfo();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("id", id);
            studentInfo =  _dapperRepository.Get<StudentInfo>(DBProcedures.procDeleteUser, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return studentInfo;
        }

        public List<StudentInfo> GetStudents(StudentInfo student)
        {
            var studentInfos = new List<StudentInfo>();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @FirstName = student.FName,
                @LastName = student.LName,
                @Email = student.Email,
                @PhoneNo = student.Phone
            });
            studentInfos = _dapperRepository.GetAll<StudentInfo>(DBProcedures.procGetAllStudents, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return studentInfos;

        }

        public BoolResponse RegisterStudent(StudentInfo student)
        {
            var resp = new BoolResponse();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @FirstName = student.FName,
                @LastName = student.LName,
                @Email = student.Email,
                @PhoneNo = student.Phone,
                @Address = student.Address,
                @DateOfBirth = student.DateOfBirth,
                @CreatedBy = student.CreatedBy
            });
            resp = _dapperRepository.Insert<BoolResponse>(DBProcedures.procInsertStudentInfo, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return resp;
        }

        public BoolResponse TakeAdmission(Admission admission)
        {
            var resp = new BoolResponse();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @StudentName = admission.StudentName,
                @InstituteName = admission.InstituteName,   
                @InstituteType = admission.InstituteType,
                @Email = admission.Email,
                @PhoneNo = admission.Phone
            });
            resp = _dapperRepository.Insert<BoolResponse>(DBProcedures.procInsertStudentInfo, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return resp;
        }
    }
}
