using AppCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppCrud.Data
{

    public class MyDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-FF1278R;Database=MVCEF;Trusted_Connection=True;MultipleActiveResultSets=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //data seeding
            modelBuilder.Entity<Customer>().HasData(    
                new { Id = 1, FullName = "Châu Hoàng Bích Du", Birthday = new DateTime(2001, 2, 1), Date = new DateTime(2022, 1, 1), Phone = "0943357474", Address = "42/32 Nguyễn Huệ, Huế", Email = "chaudu301@gmail.com" },
                new { Id = 2, FullName = "Nguyễn Viết Hà", Birthday = new DateTime(1995, 1, 1), Date = new DateTime(2023, 1, 1), Phone = "0909099099", Address = "5 Nguyễn Tri Phương, Huế", Email = "vietha@gmail.com" });

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
