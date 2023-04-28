using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Infrasturcture.Entities;

/// <summary>
/// The region.
/// </summary>
[Table("Region")]
public partial class RegionEntity
{
    [Key, Column("Id", Order = 0)]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the region description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string RegionDescription { get; set; }

    /// <summary>
    /// Gets or sets the territories.
    /// </summary>
    public virtual ICollection<TerritoryEntity> Territories { get; set; }
}
