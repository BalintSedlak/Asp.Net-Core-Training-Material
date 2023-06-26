using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Entities;

/// <summary>
/// The category.
/// </summary>
[Table("Categories")]
public partial class CategoryEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets the category name.
    /// </summary>
    [Required]
    [StringLength(15)]
    public string CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the picture.
    /// </summary>
    public byte[] Picture { get; set; }

    /// <summary>
    /// Gets the picture display.
    /// </summary>
    [NotMapped]
    public byte[] PictureDisplay
    {
        get
        {
            return Picture.Skip(78).ToArray();
        }
    }

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    public virtual ICollection<ProductEntity> Products { get; set; }
}
