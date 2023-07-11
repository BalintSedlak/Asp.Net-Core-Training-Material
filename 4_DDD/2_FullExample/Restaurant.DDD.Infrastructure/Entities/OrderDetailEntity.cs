using Restaurant.DDD.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DDD.Infrasturcture.Entities;

/// <summary>
/// The order detail.
/// </summary>
[Table("Order Details")]
public partial class OrderDetailEntity : Entity
{
    /// <summary>
    /// Gets or sets the order id.
    /// </summary>
    [Key, Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int OrderID { get; set; }

    /// <summary>
    /// Gets or sets the product id.
    /// </summary>
    [Key, Column(Order = 2)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductID { get; set; }

    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    public short Quantity { get; set; }

    /// <summary>
    /// Gets or sets the discount.
    /// </summary>
    public float Discount { get; set; }

    /// <summary>
    /// Gets or sets the order.
    /// </summary>
    public virtual OrderEntity Order { get; set; }

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    public virtual ProductEntity Product { get; set; }
}
