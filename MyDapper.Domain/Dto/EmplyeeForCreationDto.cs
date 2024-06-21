namespace MyDapper.Domain.Dto
{
    public class EmployeeForCreationDto
    {
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        
    }
}
