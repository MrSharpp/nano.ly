using System.ComponentModel.DataAnnotations;

namespace Nanoly.Dto;

public class CreateSpaceNameRequestDTO
{
    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string Content { get; set; }
}