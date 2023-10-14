using System.ComponentModel.DataAnnotations.Schema;
using Nanoly.Dto;

namespace Nanoly.Entities;

public class SpaceName
{
    public int Id { get; set; }
    public string name { get; set; }
    public string content { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }


    public virtual Link[] links { get; set; }
}