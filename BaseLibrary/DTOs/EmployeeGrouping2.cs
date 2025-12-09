using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.DTOs;

public class EmployeeGrouping2
{
    [Required]
    public string JobName { get; set; } = string.Empty;
    [Required, Range(1, 99999, ErrorMessage = "You must  select Branch ")]
    public int BranchId { get; set; }
    [Required, Range(1, 99999, ErrorMessage = "You must select Town")]
    public int TownId { get; set; }
    [Required]
    public string? Other { get; set; }
}