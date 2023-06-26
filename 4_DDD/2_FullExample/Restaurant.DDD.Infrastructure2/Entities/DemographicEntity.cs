using Restaurant.DDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DDD.Infrasturcture.Entities;

/// <summary>
/// The demographic.
/// </summary>
[Table("CustomerDemographics")]
public partial class DemographicEntity : Entity
{
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [Column("CustomerDesc")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the customer demographics.
    /// </summary>
    public virtual ICollection<CustomerDemographicEntity> CustomerDemographics { get; set; }
}
