using Microsoft.EntityFrameworkCore;
using MockAssessment6Practice.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment6Practice.Services
{
    public class EmployeeRetireDbContext : DbContext
    {
        public EmployeeRetireDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EmployeeDAL> Employees { get; set; }
    }

}

