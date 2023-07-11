using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.Infrasturcture.Entities;
using System.Reflection.Emit;

namespace Restaurant.DDD.Infrasturcture;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
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

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    public DbSet<CategoryEntity> Categories { get; set; }

    /// <summary>
    /// Gets or sets the customer demographics.
    /// </summary>
    public DbSet<CustomerDemographicEntity> CustomerDemographics { get; set; }

    /// <summary>
    /// Gets or sets the customers.
    /// </summary>
    public DbSet<CustomerEntity> Customers { get; set; }

    /// <summary>
    /// Gets or sets the demographics.
    /// </summary>
    public DbSet<DemographicEntity> Demographics { get; set; }

    /// <summary>
    /// Gets or sets the employees.
    /// </summary>
    public DbSet<EmployeeEntity> Employees { get; set; }

    /// <summary>
    /// Gets or sets the employee territories.
    /// </summary>
    public DbSet<EmployeeTerritoryEntity> EmployeeTerritories { get; set; }

    /// <summary>
    /// Gets or sets the order details.
    /// </summary>
    public DbSet<OrderDetailEntity> OrderDetails { get; set; }

    /// <summary>
    /// Gets or sets the orders.
    /// </summary>
    public DbSet<OrderEntity> Orders { get; set; }

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    public DbSet<ProductEntity> Products { get; set; }

    /// <summary>
    /// Gets or sets the regions.
    /// </summary>
    public DbSet<RegionEntity> Regions { get; set; }

    /// <summary>
    /// Gets or sets the shippers.
    /// </summary>
    public DbSet<ShipperEntity> Shippers { get; set; }

    /// <summary>
    /// Gets or sets the suppliers.
    /// </summary>
    public DbSet<SupplierEntity> Suppliers { get; set; }

    /// <summary>
    /// Gets or sets the territories.
    /// </summary>
    public DbSet<TerritoryEntity> Territories { get; set; }
}
