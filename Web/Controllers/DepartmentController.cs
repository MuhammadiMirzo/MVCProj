using AutoMapper;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class DepartmentController:Controller
{
    private  IDeparmentService _departmentService;
    private readonly IMapper _mapper;

    public DepartmentController(IDeparmentService departmentService,IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _departmentService.GetDepartments());
    }

    [HttpGet]
    public IActionResult Add()
    {
        var empty = new AddDepartmentDto();
        return View(empty);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddDepartmentDto addDepartmentDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(addDepartmentDto);
        }
        await _departmentService.AddDepartment(addDepartmentDto);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Update(GetDepartmentDto addDepartmentDto)
    {
        var depart = await _departmentService.GetDepartmentById(addDepartmentDto.Id);
        var mapped = _mapper.Map<AddDepartmentDto>(depart.Data);
        return View(mapped);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AddDepartmentDto addDepartmentDto)
    {
        if(ModelState.IsValid == false)
        {
            return View(addDepartmentDto);
        }
        await _departmentService.UpdateDepartment(addDepartmentDto);
        return RedirectToAction(nameof(Index));
    }


     [HttpGet]
     public async Task <IActionResult> Delete(int id)
    {
      await _departmentService.DeleteDepartment(id);
      return RedirectToAction(nameof(Index));
    }

}

