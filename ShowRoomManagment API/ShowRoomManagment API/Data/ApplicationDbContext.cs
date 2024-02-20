﻿using Microsoft.EntityFrameworkCore;
namespace ShowRoomManagment_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees {get; set;}


    }
}
