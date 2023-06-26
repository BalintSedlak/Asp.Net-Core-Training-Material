using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Entities;

[Table("EmployeeTerritories")]
public partial class EmployeeTerritoryEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets the employee id.
    /// </summary>
    [Key, Column(Order = 1)]
    public int EmployeeID { get; set; }

    /// <summary>
    /// Gets or sets the territory id.
    /// </summary>
    [Key, Column(Order = 2)]
    [Required]
    public int TerritoryID { get; set; }

    public virtual EmployeeEntity Employee { get; set; }

    public virtual TerritoryEntity Territory { get; set; }
}
