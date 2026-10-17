namespace CompanyEmployeeManagementSystem.Repo.Contract
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task AddObject(T obj); 
        void Updatebject(T obj); 
        void DeleteObject(int id); 
    }
}
