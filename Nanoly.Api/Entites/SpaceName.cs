using Nanoly.Dto;

namespace Nanoly.Entities;

public class SpaceName
{
    public int Id { get; set; }
    public string name { get; set; }
    public string content { get; set; }

    public virtual Link[] links { get; set; }
}