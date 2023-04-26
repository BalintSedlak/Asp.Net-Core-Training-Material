using Microsoft.EntityFrameworkCore;
using Restaurant.Infrasturcture.Entities;

namespace Restaurant.WebApp_Controller.DAL;

public class ControllerAppContext : DbContext
{
    public ControllerAppContext(DbContextOptions<ControllerAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmployeeTerritoryEntity>()
            .HasKey(et => new { et.EmployeeID, et.TerritoryID });

        modelBuilder.Entity<EmployeeTerritoryEntity>()
            .HasOne(et => et.Employee)
            .WithMany(e => e.EmployeeTerritories)
            .HasForeignKey(et => et.EmployeeID);

        modelBuilder.Entity<EmployeeTerritoryEntity>()
            .HasOne(et => et.Territory)
            .WithMany(e => e.EmployeeTerritories)
            .HasForeignKey(et => et.TerritoryID);

        modelBuilder.Entity<OrderEntity>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerID);

        modelBuilder.Entity<OrderEntity>()
            .HasOne(o => o.Employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(o => o.EmployeeID);

        modelBuilder.Entity<OrderDetailEntity>()
            .HasKey(od => new { od.OrderID, od.ProductID });

        modelBuilder.Entity<OrderDetailEntity>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderID);

        modelBuilder.Entity<OrderDetailEntity>()
            .HasOne(od => od.Product)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.ProductID);
    }

    public DbSet<CategoryEntity> Categories{ get; set; }
    public DbSet<CustomerDemographicEntity> CustomerDemographics { get; set; }
    public DbSet<CustomerEntity> Customers{ get; set; }
    public DbSet<DemographicEntity> Demographics{ get; set; }
    public DbSet<EmployeeTerritoryEntity> EmployeeTerritories{ get; set; }
    public DbSet<OrderDetailEntity> OrderDetails{ get; set; }
    public DbSet<OrderEntity> Orders{ get; set; }
    public DbSet<ProductEntity> Products{ get; set; }
    public DbSet<RegionEntity> Regions{ get; set; }
    public DbSet<ShipperEntity> Shippers{ get; set; }
    public DbSet<TerritoryEntity> Territories{ get; set; }
}
