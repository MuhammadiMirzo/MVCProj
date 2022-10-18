namespace Domain.Dtos;

public class GetEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Image { get; set; }
    public int DepartmentId { get; set; }
}
