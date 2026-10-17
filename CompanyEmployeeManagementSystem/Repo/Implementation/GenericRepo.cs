using CompanyEmployeeManagementSystem.Data;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployeeManagementSystem.Repo.Implementation
{
    public class GenericRepo<T>:IGenericRepo<T> where T :class
    {
        private readonly App_Database_Context _db;

        public GenericRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task AddObject(T obj)
        {
           await _db.Set<T>().AddAsync(obj);
        }

        public void DeleteObject(int id)
        {
            var get = _db.Set<T>().Find(id);
            
            _db.Set<T>().Remove(get);
        }

        public async Task<T> Get(int id)
        {
           var res = await _db.Set<T>().FindAsync(id);
            return res;
        }

        public async Task<List<T>> GetAll()
        {
            var res = await _db.Set<T>().ToListAsync();
            return res;
        }

        public void Updatebject(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
