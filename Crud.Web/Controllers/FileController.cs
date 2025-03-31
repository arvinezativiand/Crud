using Microsoft.AspNetCore.Mvc;

namespace Crud.Web.Controllers;

public class FileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
