using Crud.Application.DTOs;
using Crud.Application.Services.Interfaces;
using Crud.Domain.DTOs;
using Crud.Domain.Entities;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Web.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IRPouyaUserService _rPouyaUserService;
    private readonly IHtmlSanitizer _sanitizer;

    public UserController(IRPouyaUserService rPouyaUserService, IHtmlSanitizer sanitizer)
    {
        _rPouyaUserService = rPouyaUserService;
        _sanitizer = sanitizer;
    }

    public IActionResult Index()
    {
        var accessLevel = User.Claims.FirstOrDefault(c => c.Type == "AccessLevel")?.Value;
        return View((object)accessLevel);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllUsers([FromBody] PaginationRequest request)
    {
        var users = await _rPouyaUserService.GetAllUsers(request);
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

        user.FullName = _sanitizer.Sanitize(user.FullName);
        user.UserName = _sanitizer.Sanitize(user.UserName);
        user.IdNumber = _sanitizer.Sanitize(user.IdNumber);

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
