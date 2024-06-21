namespace MyDapper.Domain
{
    public record CompanywithEmployee
    {
            public Guid CompanyId { get; init; }
            public string? Name { get; init; }
            public string? FullAddress { get; init; }
            public List<Employee> Employees { get; init; } = new List<Employee>();
        
    }
}
