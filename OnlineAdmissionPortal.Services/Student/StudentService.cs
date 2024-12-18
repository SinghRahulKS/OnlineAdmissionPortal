using Dapper;
using DataContext.Repository.Dapper;
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
                @Email = student.Email
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
                @DateOfBirth = student.DateOfBirth,
                @Address = student.Address,
                @SavedBy = student.CreatedBy
            });
            resp = _dapperRepository.Insert<BoolResponse>(DBProcedures.procInsertStudentInfo, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return resp;
        }
    }
}
