using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

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




    //Functionality


    //Denote a role as active
    public void Activate()
    {
        IsActive = true;
        ActivationDate = DateTime.Now;
        DeactivationDate = null;
    }


    //Denote a role as inactive
    public void Deactivate()
    {
        IsActive = false;
        DeactivationDate = DateTime.Now;
    }


    //Determine membership renewal for readout to admin staff
    public int CalculateRenewalExtension()
    {
        if (Role.RoleType != RoleType.Professional)
            return 0;

        if (IsFirstActivation)
        {
            IsFirstActivation = false;
            return 3; // 3 months for first-time Professional
        }

        // for continuing Professional members
        // TODO: Add logic to check activity/contribution metrics
        return 12; // 12 months for active continuing Professional
    }

    
    //Check if unpaid extension may be offered for professional members - use this and above to provide info readouts to administrators
    public bool IsEligibleForExtension()
    {
        return IsActive && Role.RoleType == RoleType.Professional;
    }


    //Extend renewal by input number of months
    public void ApplyRenewalExtension(int months)
    {
        if (IsEligibleForExtension() && months > 0)
        {
            ExtensionMonthsApplied += months;
            var newRenewalDate = Member.CalculateNextRenewalDate(months);
            Member.RenewalDate = newRenewalDate;
        }
    }


    //Check if a membership has lapsed in the past
    public bool HasBeenActivatedBefore()
    {
        return !IsFirstActivation;
    }

}
