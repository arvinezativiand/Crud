using Crud.Application.DTOs;
using Crud.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Web.Controllers;

public class FileController : Controller
{
    private readonly IRPouyaFileService _fileService;

    public FileController(IRPouyaFileService fileService)
    {
        _fileService = fileService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] RPouyaFileDTO fileDTO)
    {
        await _fileService.AddFile(fileDTO);
        return Ok(new { success = true });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var files = await _fileService.GetAllFiles();
        return Ok(files);
    }
}
