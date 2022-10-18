using AutoMapper;
namespace Infrastructure.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

public class DepartmentService : IDeparmentService
{
    private DataContext _context;
    private IMapper _mapper;

    public DepartmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetDepartmentDto>>> GetDepartments()
    {
        var get = await _context.Departments.ToListAsync();
        var mapped = _mapper.Map<List<GetDepartmentDto>>(get);
        return new Response<List<GetDepartmentDto>>(mapped);
    }

    public async Task<Response<GetDepartmentDto>> GetDepartmentById(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        if(find == null)
        {
            return null;
        }
        var mapped = _mapper.Map<GetDepartmentDto>(find);
        return new Response<GetDepartmentDto>(mapped);
    }
    public async Task<Response<GetDepartmentDto>> AddDepartment(AddDepartmentDto dto)
    {

        try
        {
            var mapped = _mapper.Map<Department>(dto);
            await _context.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<GetDepartmentDto>(_mapper.Map<GetDepartmentDto>(mapped));
        }
        catch (Exception ex)
        {
            return new Response<GetDepartmentDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto dto)
    {
        try
        {
            var mapped = _mapper.Map<Department>(dto);
            _context.Attach(mapped);
            _context.Entry(mapped).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            return new Response<AddDepartmentDto>(dto);

        }
        catch (Exception ex)
        {
            return new Response<AddDepartmentDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }

    public async Task<Response<bool>> DeleteDepartment(int id)
    {
        try
        {
            var find = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(System.Net.HttpStatusCode.InternalServerError,ex.Message);
        }

    }

    public async Task<List<Department>> GetDeparts()
    {
       return await _context.Departments.ToListAsync();
    }
}
