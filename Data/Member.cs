using System.ComponentModel.DataAnnotations;

namespace SeniorLearnSystem.Data;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public DateTime MembershipStartDate { get; set; }
    public DateTime RenewalDate { get; set; }
    public bool IsActive { get; set; } = true;
    public List<MemberRole> MemberRoles { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();







}
