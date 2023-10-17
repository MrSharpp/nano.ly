using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Nanoly.Dto;

namespace Nanoly.Entities;

[Index(nameof(name), IsUnique = true)]
public class SpaceName
{
    public int Id { get; set; }

    public string name { get; set; }
    public string content { get; set; }

    [ForeignKey("User")]
    required public int UserId { get; set; }


    public virtual Link[] links { get; set; }
}