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
            PacienteNombre = t.Paciente.Nombre,  // Solo se usa el 'Nombre' del paciente
            DoctorId = t.DoctorId,
            Fecha = t.FechaHora.Date,
            Hora = t.FechaHora.TimeOfDay
        }).ToList();

        return View(turnosDto);
    }

    // GET: Turno/Create
    [HttpGet]
    public IActionResult Create()
    {        
        return View();
    }

    // POST: Turno/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TurnoDTO turnoDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Doctores = _context.Doctores.ToList();
            return View(turnoDto);
        }

        // Buscar o crear el paciente
        var nombrePaciente = turnoDto.PacienteNombre.Trim();

        // Realizar la búsqueda en memoria solo con el 'Nombre' del paciente
        var paciente = _context.Pacientes
            .AsEnumerable()  // Ejecuta la consulta en memoria
            .FirstOrDefault(p => p.Nombre == nombrePaciente);  // Solo busca por 'Nombre'

        if (paciente == null)
        {
            var nuevoPaciente = new Paciente
            {
                Nombre = nombrePaciente,
                FechaNacimiento = DateTime.MinValue  // Establecer un valor por defecto
            };
            _context.Pacientes.Add(nuevoPaciente);
            await _context.SaveChangesAsync();
            paciente = nuevoPaciente;
        }

        // Crear el turno
        var turno = new Turno
        {
            PacienteId = paciente.Id,
            DoctorId = turnoDto.DoctorId,
            FechaHora = turnoDto.Fecha.Add(turnoDto.Hora)
        };

        await _turnoRepository.CreateTurnoAsync(turno);
        return RedirectToAction(nameof(Index));
    }

    // GET: Turno/Edit/{id}
    [HttpGet]
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

        // Buscar o crear el paciente
        var nombrePaciente = turnoDto.PacienteNombre.Trim();
        
        // Realizar la búsqueda en memoria solo con el 'Nombre' del paciente
        var paciente = _context.Pacientes
            .AsEnumerable()  // Ejecuta la consulta en memoria
            .FirstOrDefault(p => p.Nombre == nombrePaciente);  // Solo busca por 'Nombre'

        if (paciente == null)
        {
            paciente = new Paciente
            {
                Nombre = nombrePaciente,
                FechaNacimiento = DateTime.MinValue  // Establecer un valor por defecto
            };
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        // Buscar o crear el doctor
        var nombreDoctor = turnoDto.DoctorNombre.Trim();
        var doctor = _context.Doctores.FirstOrDefault(d => d.Nombre == nombreDoctor);

        if (doctor == null)
        {
            doctor = new Doctor
            {
                Nombre = nombreDoctor
            };
            _context.Doctores.Add(doctor);
            await _context.SaveChangesAsync();
        }

        // Actualizar el turno
        var turno = new Turno
        {
            Id = id,
            PacienteId = paciente.Id,
            DoctorId = doctor.Id,
            FechaHora = turnoDto.Fecha.Add(turnoDto.Hora)
        };

        await _turnoRepository.UpdateTurnoAsync(turno);
        return RedirectToAction(nameof(Index));
    }
}
