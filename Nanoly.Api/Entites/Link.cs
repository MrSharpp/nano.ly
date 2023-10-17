using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nanoly.Entities;

[Index(nameof(name), nameof(SpaceNameId), IsUnique = true)]
public class Link
{
    public int Id { get; set; }
    public string name { get; set; }

    [ForeignKey("SpaceName")]
    public int SpaceNameId { get; set; }

    public string link { get; set; }

}