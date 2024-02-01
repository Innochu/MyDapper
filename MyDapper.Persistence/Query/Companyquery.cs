namespace MyDapper.Persistence.Query
{
    public class Companyquery
    {
        public const string SelectCompanyQuery = @"SELECT CompanyId, [Name], [Address], Country  FROM Companies ORDER BY [Name]";

        public const string SelectCompanyByIdQuery = @"SELECT * FROM Companies WHERE CompanyId = @CompanyId";

    }
}
