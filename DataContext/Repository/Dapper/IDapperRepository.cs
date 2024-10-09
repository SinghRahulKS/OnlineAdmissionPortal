﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repository.Dapper
{
    public interface IDapperRepository
    {
        T Get<T>(string sp, DynamicParameters parms, string connectionName, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, string connectionName, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, string connectionName, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, string connectionName, CommandType commandType = CommandType.StoredProcedure);
    }
}
