using Clavaxtask.Models;
using Microsoft.EntityFrameworkCore;

namespace Clavaxtask.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
