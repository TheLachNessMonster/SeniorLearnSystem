using Mapster;
using Microsoft.EntityFrameworkCore;
using SeniorLearnSystem.Data;
using SeniorLearnSystem.Models;


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
        //Adapted workflow from Bibliotecha
        var member = new Member { FirstName = firstname, LastName = lastname, Email = email, RegistrationDate = registrationDate };
        member.Register(registrationDate);
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return member;
    }

    public async Task<List<MemberDTO>> GetMembersAsync()
    {
        var members = await _context.Members.ToListAsync();
        var dtoList = new List<MemberDTO>();
        foreach(var m in members)
        {
            dtoList.Add(m.Adapt<MemberDTO>());
        }
        
        return dtoList;
    }


}
