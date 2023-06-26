using Restaurant.DDD.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DDD.Infrasturcture.Entities;

/// <summary>
/// The customer demographic.
/// </summary>
[Table("CustomerCustomerDemo")]
public partial class CustomerDemographicEntity : Entity
{
    /// <summary>
    /// Gets or sets the customer id.
    /// </summary>
    [Key, Column("CustomerTypeId", Order = 1)]
    [Required]
    [StringLength(5, MinimumLength = 5)]
    public string CustomerID { get; set; }

    /// <summary>
    /// Gets or sets the demographic id.
    /// </summary>
    [Key, Column("DemographicTypeId", Order = 2)]
    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string DemographicID { get; set; }

    /// <summary>
    /// Gets or sets the customer.
    /// </summary>
    public virtual CustomerEntity Customer { get; set; }

    /// <summary>
    /// Gets or sets the demographic.
    /// </summary>
    public virtual DemographicEntity Demographic { get; set; }
}
