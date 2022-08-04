using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
	public class EmployeeDBContext : DbContext
	{
		public DbSet<Employee> employees { get; set; }

		public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
		 : base(options)
		{

		}

	}
}