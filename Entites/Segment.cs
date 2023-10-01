namespace Nanoly.Entities;

public class Segment
{
    public int Id { get; set; }
    public string segment { get; set; }

    public virtual Resource Resource { get; set; }
}