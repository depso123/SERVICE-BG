using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SERVICE_BG.Entities;
using SERVICE_BG.Models;

namespace SERVICE_BG.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<SERVICE_BG.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
        public DbSet<Category>Categories {get; set;}
        public DbSet<Service>Services { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
