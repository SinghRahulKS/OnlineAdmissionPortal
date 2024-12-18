using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Account
{
    public interface IAccountService
    {
        public List<User> GetUsers(User user);
        public User GetUserDetail(Guid id);
        public User EditUser(User user);
    }
}
