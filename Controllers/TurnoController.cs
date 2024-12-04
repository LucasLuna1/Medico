using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;
using TurneroMedico.Data;
using Microsoft.EntityFrameworkCore;


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
    var turnos = await _context.Turnos
        .Include(t => t.Paciente)
        .Include(t => t.Doctor)
        .ToListAsync();

    var turnosDto = turnos.Select(t => new TurnoDTO
    {
        Id = t.Id,
        PacienteId = t.PacienteId,
        PacienteNombre = $"{t.Paciente.Nombre} {t.Paciente.Apellido}",
        DoctorId = t.DoctorId,
        DoctorNombre = t.Doctor.Nombre,
        Fecha = t.FechaHora.Date,
        Hora = t.FechaHora.TimeOfDay
    }).ToList();

    return View(turnosDto);
}


    // GET: Turno/Create
   public IActionResult Create()
{
    ViewBag.Pacientes = _context.Pacientes
        .Select(p => new { p.Id, NombreCompleto = $"{p.Nombre} {p.Apellido}" })
        .ToList();
        
    ViewBag.Doctores = _context.Doctores
        .Select(d => new { d.Id, d.Nombre })
        .ToList();
        
    return View();
}


    // POST: Turno/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TurnoDTO turnoDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Pacientes = _context.Pacientes.ToList();
            ViewBag.Doctores = _context.Doctores.ToList();
            return View(turnoDto);
        }

        var turno = _mapper.Map<Turno>(turnoDto);
        await _turnoRepository.CreateTurnoAsync(turno);
        return RedirectToAction(nameof(Index));
    }

    // GET: Turno/Edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        var turno = await _turnoRepository.GetTurnoByIdAsync(id);
        if (turno == null) return NotFound();
        ViewBag.Pacientes = _context.Pacientes.ToList();
        ViewBag.Doctores = _context.Doctores.ToList();
        var turnoDto = _mapper.Map<TurnoDTO>(turno);
        return View(turnoDto);
    }

    // POST: Turno/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TurnoDTO turnoDto)
    {
        if (!ModelState.IsValid) return View(turnoDto);
        if (id != turnoDto.Id) return BadRequest();
        var turno = _mapper.Map<Turno>(turnoDto);
        await _turnoRepository.UpdateTurnoAsync(turno);
        return RedirectToAction(nameof(Index));
    }
}

