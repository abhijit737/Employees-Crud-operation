using Employee_CRUD_Rasor.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD_Rasor.Data
{
    public class EmpContextdb:DbContext

    {
        public EmpContextdb()
        {
            
        }

        DbSet<Employee>Employees { get; set; }
    }
}
