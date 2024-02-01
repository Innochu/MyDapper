namespace MyDapper.Dto
{
    public class CompanyDto
    {
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
