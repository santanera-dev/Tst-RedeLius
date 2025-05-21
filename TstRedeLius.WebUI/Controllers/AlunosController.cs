using TstRedeLius.Application.DTOs;
using TstRedeLius.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TstRedeLius.WebUI.Controllers;

public class AlunosController : Controller
{
    private readonly IAlunoService _alunoService;
    private readonly IWebHostEnvironment _environment;

    public AlunosController(IAlunoService alunoAppService, IWebHostEnvironment environment)
    {
        _alunoService = alunoAppService;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var alunos = await _alunoService.GetAlunos();
        return View(alunos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AlunoDTO alunoDto)
    {
        if (ModelState.IsValid)
        {
            await _alunoService.Add(alunoDto);
            return RedirectToAction(nameof(Index));
        }
        return View(alunoDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var alunoDto = await _alunoService.GetById(id);

        if (alunoDto == null) return NotFound();

        return View(alunoDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AlunoDTO alunoDto)
    {
        if (ModelState.IsValid)
        {
            await _alunoService.Update(alunoDto);
            return RedirectToAction(nameof(Index));
        }
        return View(alunoDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var alunoDto = await _alunoService.GetById(id);

        if (alunoDto == null) return NotFound();

        return View(alunoDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _alunoService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var alunoDto = await _alunoService.GetById(id);

        if (alunoDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;

        return View(alunoDto);
    }
}
