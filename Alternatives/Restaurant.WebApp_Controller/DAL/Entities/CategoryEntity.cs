using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace Restaurant.Infrasturcture.Entities;

/// <summary>
/// The category.
/// </summary>
[PrimaryKey("CategoryId")]
[Table("Categories")]
public partial class CategoryEntity
{
    [Key, Column("Id", Order = 0)]
    public int CategoryId { get; set; }
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
