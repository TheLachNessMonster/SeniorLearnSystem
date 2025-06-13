using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SeniorLearnSystem.Areas.Administration.Models.Member;

public class Create
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string Email { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }

    public DateTime RegistrationDate { get; set; }
}
