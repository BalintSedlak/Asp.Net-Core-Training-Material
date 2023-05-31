using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Entities;

/// <summary>
/// The territory.
/// </summary>
[Table("Territories")]
public partial class TerritoryEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets the territory description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string TerritoryDescription { get; set; }

    /// <summary>
    /// Gets or sets the region id.
    /// </summary>
    public int RegionID { get; set; }

    /// <summary>
    /// Gets or sets the region.
    /// </summary>
    public virtual RegionEntity Region { get; set; }

    /// <summary>
    /// Gets or sets the employee territories.
    /// </summary>
    public virtual ICollection<EmployeeTerritoryEntity> EmployeeTerritories { get; set; }
}
