using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Entities;

[PrimaryKey("Id")]
public abstract class BaseEntity
{
    [Key, Column("Id", Order = 0)]
    public int Id { get; set; }
}