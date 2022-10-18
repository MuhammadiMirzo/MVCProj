using AutoMapper;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class EmployeeController : Controller
{
    private  IEmployeeService _emplyeeService;
    private  IMapper _mapper;
    private readonly IDeparmentService _deparment;

    public EmployeeController(IEmployeeService emplyeeService,IMapper mapper,IDeparmentService deparment)
    {
        _emplyeeService = emplyeeService;
        _mapper = mapper;
        _deparment = deparment;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _emplyeeService.GetEmployeeDtos());
    }
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        ViewBag.deparments = await _deparment.GetDeparts();  
        var empty = new AddEmployeeDto();
        return View(empty);
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeDto model)
    {
         ViewBag.deparments = await _deparment.GetDeparts();  
        if(ModelState.IsValid == false)return View(model);
        await _emplyeeService.AddEmployee(model);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
         ViewBag.deparments = await _deparment.GetDeparts();  
        var emp = await _emplyeeService.GetEmployeeById(id);
        return View(emp);
    }
    [HttpPost]
    public async Task<IActionResult> Update(GetEmployeeDto model)
    {

        if(ModelState.IsValid == false)
        {
            return View(model);
        }
         ViewBag.deparments = await _deparment.GetDeparts(); 
          
        await _emplyeeService.UpdateEmployee(model);
        return RedirectToAction(nameof(Index));
    
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _emplyeeService.DeleteEmployee(id);
        return RedirectToAction(nameof(Index));
    }

}
