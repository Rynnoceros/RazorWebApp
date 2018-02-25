using System;
using Microsoft.EntityFrameworkCore;
using RazorWebApp.Models;

namespace RazorWebApp.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
