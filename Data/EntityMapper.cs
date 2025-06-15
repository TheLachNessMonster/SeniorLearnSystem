using System.Data;
using Microsoft.EntityFrameworkCore;

namespace SeniorLearnSystem.Data;

public class EntityMapper
{
    public EntityMapper(ModelBuilder mb)
    {

        //Member Mapping
        // TODO: Date defaults are not working (?)
        mb.Entity<Member>(m =>
        {
            m.Property(m => m.FirstName).HasMaxLength(50).IsRequired();
            m.Property(m => m.LastName).HasMaxLength(50).IsRequired();
            m.Property(m => m.Email).HasMaxLength(150);
            m.Property(m => m.Phone).HasMaxLength(20);
            m.Property(m => m.RegistrationDate).IsRequired();
            m.Property(m => m.MembershipStartDate).IsRequired();
            m.Property(m => m.RenewalDate).IsRequired();
            m.Property(m => m.IsActive).HasDefaultValue(true);
            m.HasMany(m => m.MemberRoles)
                .WithOne(r => r.Member)
                    .HasForeignKey(r => r.MemberId)
                        .OnDelete(DeleteBehavior.Restrict);
            m.HasMany(m => m.Payments)
                .WithOne(p => p.Member)
                    .HasForeignKey(p => p.MemberId)
                        .OnDelete(DeleteBehavior.Restrict);

        });

        //MemberRole Mapping
        mb.Entity<MemberRole>(m=>
        {
            m.Property(m => m.ActivationDate).IsRequired();
            m.Property(m => m.IsActive).HasDefaultValue(true);
            m.Property(m => m.IsFirstActivation).HasDefaultValue(true);
            m.Property(m => m.ExtensionMonthsApplied).HasDefaultValue(0);
            //m.HasOne(m => m.Member).WithOne(r=>r).HasForeignKey
        });


        //Role Mapping
        mb.Entity<Role>(r =>
        {
            r.Property(r => r.RoleType).IsRequired();
            r.Property(r => r.RoleType)
             .HasConversion<int>();
            //What is the value of this?
            r.HasDiscriminator(r => r.RoleType)
               .HasValue<Role>(RoleType.Standard)
               .HasValue<Role>(RoleType.Professional)
               .HasValue<Role>(RoleType.Honorary);
            r.Property(r => r.Description).HasMaxLength(100).IsRequired();
            r.HasMany(r => r.MemberRoles)
                .WithOne(m => m.Role)
                    .HasForeignKey(m => m.RoleId);

        });

        //Payment Mapping
        mb.Entity<Payment>(p =>
        {
            p.Property(p => p.PaymentMethod).IsRequired();
            p.Property(p => p.PaymentMethod)
             .HasConversion<int>();
        });



    }
}
