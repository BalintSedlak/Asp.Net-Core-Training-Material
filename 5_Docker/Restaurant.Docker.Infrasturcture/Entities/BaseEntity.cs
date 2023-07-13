using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Docker.Infrasturcture.Entities;

[PrimaryKey("Id")]
public abstract class BaseEntity
{
    [Key, Column("Id", Order = 0)]
    public int Id { get; set; }
}