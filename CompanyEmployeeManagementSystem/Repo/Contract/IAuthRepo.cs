using CompanyEmployeeManagementSystem.DTOs;

namespace CompanyEmployeeManagementSystem.Repo.Contract
{
    public interface IAuthRepo
    {
        Task<string> Login(AuthLoginDTO dto);
    }
}
