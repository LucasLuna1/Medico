using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;
using TurneroMedico.Data;


public class TurnoController : Controller
{
    private readonly ITurnoRepository _turnoRepository;
    private readonly IMapper _mapper;

   private readonly ApplicationDbContext _context;

    public TurnoController(ITurnoRepository turnoRepository, IMapper mapper, ApplicationDbContext context)
    {
        _turnoRepository = turnoRepository;
        _mapper = mapper;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var turnos = await _turnoRepository.GetAllTurnosAsync();
        var turnosDto = _mapper.Map<List<TurnoDTO>>(turnos);
        return View(turnosDto);
    }

   public IActionResult Create()
{
    ViewBag.Pacientes = _context.Pacientes.ToList();
    ViewBag.Doctores = _context.Doctores.ToList();
    return View();
}

public async Task<IActionResult> Edit(int id)
{
    var turno = await _turnoRepository.GetTurnoByIdAsync(id);
    if (turno == null) return NotFound();
    ViewBag.Pacientes = _context.Pacientes.ToList();
    ViewBag.Doctores = _context.Doctores.ToList();
    var turnoDto = _mapper.Map<TurnoDTO>(turno);
    return View(turnoDto);
}

    [HttpPost]
public async Task<IActionResult> Edit(int id, TurnoDTO turnoDto)
{
    if (!ModelState.IsValid) return View(turnoDto);
    if (id != turnoDto.Id) return BadRequest();
    var turno = _mapper.Map<Turno>(turnoDto);
    await _turnoRepository.UpdateTurnoAsync(turno);
    return RedirectToAction(nameof(Index));
}
}
