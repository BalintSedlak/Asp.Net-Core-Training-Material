using Restaurant.DDD.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DDD.Infrasturcture.Entities;

/// <summary>
/// The shipper.
/// </summary>
[Table("Shippers")]
public partial class ShipperEntity : Entity
{
    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    [StringLength(24)]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the orders.
    /// </summary>
    public virtual ICollection<OrderEntity> Orders { get; set; }
}
