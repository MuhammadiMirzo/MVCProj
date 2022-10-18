using Domain.Dtos;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

}
