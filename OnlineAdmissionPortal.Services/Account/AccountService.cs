using Dapper;
using DataContext.Repository.Dapper;
using Entity.Common;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IDapperRepository _dapperRepository;
        public AccountService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository; 
        }

        public ApplicationUser GetUserDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUsers(ApplicationUser user)
        {
            var users = new List<ApplicationUser>();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @FirstName = user.FirstName,
                @LastName = user.LastName,
                @UserName = user.UserName,
                @RoleName = user.RoleName,
                @CurrentPage = user.CurrentPage,
                @PageSize = user.PageSize
            });
            users = _dapperRepository.GetAll<ApplicationUser>(DBProcedures.procGetAspNetUsers, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return users;
           
        }
    }
}
