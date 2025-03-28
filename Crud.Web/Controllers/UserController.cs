using Crud.Application.DTOs;
using Crud.Application.Services.Interfaces;
using Crud.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Web.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IRPouyaUserService _rPouyaUserService;

    public UserController(IRPouyaUserService rPouyaUserService)
    {
        _rPouyaUserService = rPouyaUserService;
    }

    public IActionResult Index()
    {
        var accessLevel = User.Claims.FirstOrDefault(c => c.Type == "AccessLevel")?.Value;
        return View((object)accessLevel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _rPouyaUserService.GetAllUsers();
        return Json(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] RPouyaUserDTO user)
    {
        var accessLevel = User.Claims.FirstOrDefault(c => c.Type == "AccessLevel")?.Value;

        if (accessLevel == "AdminBasic")
        {
            return Json(new { success = false, error = "عدم دسترسی" });
        }

        if (!ModelState.IsValid)
        {
            return Json(new { success = false, error = "داده‌ها نامعتبر هستند" });
        }

        try
        {
            await _rPouyaUserService.AddUser(user);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }
}
