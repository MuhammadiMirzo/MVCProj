using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IDeparmentService
{   Task<List<Department>> GetDeparts();
    Task<Response<List<GetDepartmentDto>>> GetDepartments();
    Task<Response<GetDepartmentDto>> GetDepartmentById(int id);
    Task<Response<GetDepartmentDto>> AddDepartment(AddDepartmentDto dto);
    Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto dto);
    Task<Response<bool>> DeleteDepartment(int id);

}