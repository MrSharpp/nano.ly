using System.ComponentModel.DataAnnotations;

namespace Nanoly.Dto;

public class UpdateSpaceNameRequest
{
    public string? SpaceName { get; set; } = null;
    public string? Content { get; set; } = null;
}