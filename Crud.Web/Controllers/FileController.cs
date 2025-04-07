using Crud.Application.DTOs;
using Crud.Application.Services.Interfaces;
using Crud.Domain.DTOs;
using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Web.Controllers;

public class FileController : Controller
{
    private readonly IRPouyaFileService _fileService;
    private readonly IHtmlSanitizer _sanitizer;

    public FileController(IRPouyaFileService fileService, IHtmlSanitizer sanitizer)
    {
        _fileService = fileService;
        _sanitizer = sanitizer;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] RPouyaFileDTO fileDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        fileDTO.Data.Title = _sanitizer.Sanitize(fileDTO.Data.Title);
        fileDTO.Data.Description = _sanitizer.Sanitize(fileDTO.Data.Description);
        await _fileService.AddFile(fileDTO);
        return Ok(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(PaginationRequest request)
    {
        var files = await _fileService.GetAllFiles(request);
        return Ok(files);
    }
}
