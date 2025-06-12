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



    //Check whether this role type requires a payment
    public bool GetPaymentRequirement()
    {
        return RequiresPayment;
    }


    //Check what the default extension of this roletype is
    public int GetExtensionEligibility()
    {
        return DefaultExtensionMonths;
    }

    // static method to seed default roles
    public static List<Role> GetDefaultRoles()
    {
        return new List<Role>
        {
            new Role
            {
                RoleType = RoleType.Standard,
                Description = "Standard Member - Pays fees, can enroll in lessons",
                RequiresPayment = true,
                DefaultExtensionMonths = 0
            },
            new Role
            {
                RoleType = RoleType.Professional,
                Description = "Professional Member - Fee exempt, can teach lessons",
                RequiresPayment = false,
                DefaultExtensionMonths = 3
            },
            new Role
            {
                RoleType = RoleType.Honorary,
                Description = "Honorary Member - Lifetime fee exemption",
                RequiresPayment = false,
                DefaultExtensionMonths = 0
            }
        };
    }


}

public enum RoleType
{
    Standard = 1,
    Professional = 2,
    Honorary = 3
}