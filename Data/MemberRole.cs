using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeniorLearnSystem.Data;

public class MemberRole
{
  
    public int Id { get; set; }
    public DateTime ActivationDate { get; set; }
    public DateTime? DeactivationDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFirstActivation { get; set; } = true;
    public int ExtensionMonthsApplied { get; set; } = 0;

    //Relationships
    public int MemberId { get; set; }
    public virtual Member Member { get; set; } = null!;
    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

}
