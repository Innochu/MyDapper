namespace MyDapper.Persistence.Query
{
    public class Companyquery
    {
        public const string SelectCompanyQuery = @"SELECT CompanyId, [Name], [Address], Country  FROM Companies ORDER BY [Name]";

        public const string SelectCompanyByIdQuery = @"SELECT * FROM Companies WHERE CompanyId = @CompanyId";

        public const string SelectCompaniesWithEmployeesQuery = @"SELECT c.CompanyId, c.[Name],  CONCAT(c.[Address], ', ', c.Country) AS FullAddress,   e.EmployeeId, e.[Name], e.Age, e.Position  FROM Companies c JOIN Employees e ON c.CompanyId = e.CompanyId";

        public const string InsertCompanyQuery = @"INSERT INTO Companies (CompanyId, [Name], [Address], Country) OUTPUT inserted.CompanyId VALUES(default, @name, @address, @country);";



    }
}
