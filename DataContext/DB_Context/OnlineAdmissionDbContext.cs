using Entity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.DB_Context
{
    public class OnlineAdmissionDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public OnlineAdmissionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("OnlineAdmissionConnectionString");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
