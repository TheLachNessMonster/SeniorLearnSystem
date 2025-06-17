using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorLearnSystem.Areas.Administration.Models.Member;
using SeniorLearnSystem.Data;
using SeniorLearnSystem.Services;

namespace SeniorLearnSystem.Areas.Administration.Controllers;

[Area("Administration")]
public class MemberController : Controller
{

    private readonly MembershipService _membershipService;
    public MemberController(ApplicationDbContext context, MembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    // GET: MemberController
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        //reconfigure this to use a DTO
        var m = await _membershipService.GetMembersAsync();
        return View(m);
    }

    // GET: MemberController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        return View();
    }

    // GET: MemberController/Create
    [HttpGet]
    public async Task<ActionResult> Create()
    {
        var m = new Create();
        return View(m);
    }


    // POST: MemberController/Create
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Create m)
    {
        if (ModelState.IsValid)
        {
            try
            {
                //TODO:b 297. Run and verfiy the create action (check the database for a new user)
                await _membershipService.MemberRegistrationAsync(m.FirstName, m.LastName, m.Email, m.Phone, m.RegistrationDate);
                //Redirect important to ensure index viewmodel is created
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return View(m);

    }

    // GET: MemberController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: MemberController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MemberController/Delete/5




    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: MemberController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
