using AutoMapper;
using Domain.Dtos;

namespace Infrastructure.AutoMapper;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<AddDepartmentDto,Department>().ReverseMap();
        CreateMap<Department,GetDepartmentDto>().ReverseMap();
        CreateMap<GetDepartmentDto,AddDepartmentDto>().ReverseMap();
        CreateMap<Employee,GetEmployeeDto>().ReverseMap();
        CreateMap<GetEmployeeDto,Employee>();
        CreateMap<Employee,AddEmployeeDto>().ReverseMap();
        CreateMap<Employee,UpdateEmployeeDto>().ReverseMap();
    }
}
