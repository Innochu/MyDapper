namespace MyDapper.Persistence.Repository.Interface
{
    public interface IRepositoryManager
    {
        ICompanyRepo Company { get; }
        IEmployeeRepo Employee { get; }
    }
}
