using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Infrasturcture.Entities;

/// <summary>
/// The territory.
/// </summary>
[Table("Territories")]
public partial class TerritoryEntity
{
    [Key, Column("Id", Order = 0)]
    public int Id { get; set; }
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
