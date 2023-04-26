using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Infrasturcture.Entities;

[PrimaryKey("Id")]
[Table("EmployeeTerritories")]
public partial class EmployeeTerritoryEntity
{
    [Key, Column("Id", Order = 0)]
    public int Id { get; set; }
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
