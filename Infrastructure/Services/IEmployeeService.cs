using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<Response<List<Employee>>> GetEmployeeDtos();
        Task<GetEmployeeDto> GetEmployeeById(int id);
        Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model);
        Task<int> UpdateEmployee(GetEmployeeDto model);
        Task<Response<bool>> DeleteEmployee(int id);
        
    }
}