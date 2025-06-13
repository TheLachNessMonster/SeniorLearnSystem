using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SeniorLearnSystem.Areas.Administration.Models.Member;

public class Create
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; }
}
