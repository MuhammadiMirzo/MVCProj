namespace Domain.Dtos;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Image { get; set; }
    //department
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
