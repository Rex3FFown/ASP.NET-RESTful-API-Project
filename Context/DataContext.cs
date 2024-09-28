using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using efcoreRestFull.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Context
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        // public DbSet<Student>? Students { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CustomerRole tablomun ilişkileri
            modelBuilder.Entity<CustomerRole>().HasKey(cr => new { cr.CustomerId, cr.RoleId });
            modelBuilder.Entity<CustomerRole>().HasOne(cr => cr.Customer).WithMany(c=>c.CustomerRoles).HasForeignKey(cr => cr.CustomerId);
            modelBuilder.Entity<CustomerRole>().HasOne(cr=>cr.Role).WithMany(c=>c.CustomerRoles).HasForeignKey(cr=>cr.RoleId);
            modelBuilder.Entity<CustomerRole>().ToTable("customer_role");
            
            //Basket tablomun ilişkileri
            //modelBuilder.Entity<Basket>().HasMany(b => b.BasketItems).WithOne(bi => bi.Basket).HasForeignKey(bi => bi.BasketId);
            
            base.OnModelCreating(modelBuilder);
        }
       

    }
}