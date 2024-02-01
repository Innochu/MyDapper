namespace MyDapper.Dto
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public Guid CompanyId { get; set; }
    }
}
