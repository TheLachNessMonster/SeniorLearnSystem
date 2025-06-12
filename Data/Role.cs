using System.ComponentModel.DataAnnotations;

namespace SeniorLearnSystem.Data;

public class Role
{
    public int Id { get; set; }
    public RoleType RoleType { get; set; }
    public string Description { get; set; } 
    public bool RequiresPayment { get; set; }
    public int DefaultExtensionMonths { get; set; }
    // nav properties
    public virtual List<MemberRole> MemberRoles { get; set; } = new();

}

public enum RoleType
{
    Standard = 1,
    Professional = 2,
    Honorary = 3
}