using EmpManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementAPI.Data
{
    public class EmpdbContext : DbContext
    {
        public EmpdbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Employee> Employees { get; set; }
    }
}
