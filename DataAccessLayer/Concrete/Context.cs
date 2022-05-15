using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=UFUK;database=Rys;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().HasData(DistrictData.GetList());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<PhoneOrder> PhoneOrders { get; set; }
        public DbSet<PhoneOrderDetail> PhoneOrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffRole> StaffsRoles { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableOrder> TableOrders { get; set; }
        public DbSet<TableOrderDetail> TableOrdersDetails { get; set; }
    }
}
