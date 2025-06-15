using SeniorLearnSystem.Data;
using SeniorLearnSystem.Data;
using SeniorLearnSystem.Areas.Administration.Models.Member;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SeniorLearnSystem.Services;

public class MembershipService
{
    protected readonly ApplicationDbContext _context;
    public MembershipService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Member> MemberRegistrationAsync(string firstname, string lastname, string email, string phone, DateTime registrationDate)
    {
        //TODO:b 216. Implement RegisterMemberAsync
        var member = new Member { FirstName = firstname, LastName = lastname, Email = email, RegistrationDate = registrationDate };
        member.Register(registrationDate);
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        //Simultaneous Role config
        //if (result.Succeeded)
        //{
        //    await _userManager.AddToRoleAsync(member, Roles.MEMBER.ToString());
        //    //TODO:b 448. Add Claim to Member when being registered
        //    await _userManager.AddClaimAsync(member, new Claim("bibliotheca", libraryId.ToString()));
        //    return member.Adapt<MemberDTO>();
        //}
        //throw new ApplicationException(result.Errors.First().Description);
        return member;
    }

    public async Task<List<Member>> GetMembersAsync()
    {
        var members = await _context.Members.ToListAsync();
        
        return members;
    }


}
