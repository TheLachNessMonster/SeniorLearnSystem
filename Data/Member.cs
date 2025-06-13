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


    public Member(string firstname, string lastname, string email, string phone)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Phone = phone;
    }

    //Functionality


    //For first-time registation, set default parameters for a new member
    public void Register(DateTime registrationDate)
    {
        RegistrationDate = registrationDate;
        // always start membership on the first of next month !!
        MembershipStartDate = new DateTime(
            registrationDate.AddMonths(1).Year,
            registrationDate.AddMonths(1).Month,
                1);
        RenewalDate = MembershipStartDate.AddYears(1);
        IsActive = true;
    }


    //Checks if the Member has an active role of a given type - i.e., are they active as a Standard member, but not as a Professional
    public bool HasActiveRole(RoleType roleType)
    {
        return MemberRoles.Any(mr =>
            mr.Role.RoleType == roleType &&
            mr.IsActive &&
            mr.ActivationDate <= DateTime.Now &&
            (mr.DeactivationDate == null || mr.DeactivationDate > DateTime.Now));
    }


    //Determine if Member is elligible to enroll in a course
    // TODO: all members can enroll?  Should this just check isActive?
    public bool CanEnrolInLessons()
    {
        return IsActive && HasActiveRole(RoleType.Standard);
    }


    //Determine if Member is elligible to create a course
    public bool CanCreateLessons()
    {
        return IsActive && HasActiveRole(RoleType.Professional);
    }


    //Determine the next renewal date a member may have given an alloted extension of months.
    //Check - this can only ever return potentialNewDate, as any addition will make it greater than RenewalDate
    public DateTime CalculateNextRenewalDate(int extensionMonths)
    {
        var potentialNewDate = RenewalDate.AddMonths(extensionMonths);
        return potentialNewDate > RenewalDate ? potentialNewDate : RenewalDate;
    }


    //Return a list of roles which the member has active
    public List<MemberRole> GetActiveRoles()
    {
        return MemberRoles.Where(mr =>
                mr.IsActive &&
                mr.ActivationDate <= DateTime.Now &&
                (mr.DeactivationDate == null || mr.DeactivationDate > DateTime.Now))
                .ToList();
    }


    //Update contact info
    public void UpdateContact(string email, string phone)
    {
        if (!string.IsNullOrWhiteSpace(email))
            Email = email;
        if (!string.IsNullOrWhiteSpace(phone))
            Phone = phone;
    }
}







