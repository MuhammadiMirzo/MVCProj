using AutoMapper;
namespace Infrastructure.Services;

using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<Employee>>> GetEmployeeDtos()
    {
       var res =  await _context.Employees.Include(x=>x.Department).ToListAsync();
        return new Response<List<Employee>>(res);
    }
    public async Task<GetEmployeeDto> GetEmployeeById(int id)
    {
        // var find = await _context.Employees.FindAsync(id);
        // if (find == null) return new Response<GetEmployeeDto>(System.Net.HttpStatusCode.NotFound, "");
        // var mapped = _mapper.Map<GetEmployeeDto>(find);
        // return new Response<GetEmployeeDto>(mapped);
        var mapped=await(from e in _context.Employees
                        where e.Id==id
                        select new GetEmployeeDto{
                        Id=e.Id,
                        Name=e.Name,
                        Email=e.Email,
                        Phone=e.Phone,
                        Image=e.Image,
                        DepartmentId=e.DepartmentId                         
                        }).FirstOrDefaultAsync();
        return mapped;
    }
    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model)
    {
        try
        {
            var mapped = _mapper.Map<Employee>(model);
            await _context.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddEmployeeDto>(_mapper.Map<AddEmployeeDto>(mapped));
        }
        catch (Exception ex)
        {

            return new Response<AddEmployeeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<int> UpdateEmployee(GetEmployeeDto model)
    {
      
            var find = await _context.Employees.FindAsync(model.Id);
            if (find == null) return 0;
            find.Name = model.Name;
            find.DepartmentId = model.DepartmentId;
            find.Email = model.Email;
            find.Image = model.Image;
            find.Phone = model.Phone;
             return await _context.SaveChangesAsync();
            
        
        
    }

    public async Task<Response<bool>> DeleteEmployee(int id)
    {
        try
        {
            var find = await _context.Employees.FindAsync(id);
            if (find == null) return new Response<bool>(System.Net.HttpStatusCode.NotFound, "");
            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
}
