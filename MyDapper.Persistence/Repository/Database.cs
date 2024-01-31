﻿using Dapper;
using MyDapper.Persistence.DapperContextFolder;

namespace MyDapper.Persistence.Repository

{
    public class Database
    {
        private readonly DapperContext _context;
        public Database(DapperContext context)
        {
            _context = context;
        }
        public void CreateDatabase(string dbName)
        {
            var query = "SELECT * FROM CompanyEmployeeDapper WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using (var connection = _context.CreateMasterConnection())
            {
                var records = connection.Query(query, parameters);
                if (!records.Any())
                    connection.Execute($"CREATE DATABASE {dbName}");
            }
        }
    }
}
