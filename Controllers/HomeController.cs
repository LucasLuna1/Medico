using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurneroMedico.Models;
using TurneroMedico.Data;
using AutoMapper;
using TurneroMedico.DTOs;

namespace TurneroMedico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITurnoRepository<Turno> _turnorepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ITurnoRepository<Turno> turnoRepository, IMapper mapper)
        {
            _logger = logger;
            _turnorepository = turnoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var turnos = await _turnorepository.GetAllAsync();
            var turnosDTO = _mapper.Map<IEnumerable<TurnoDTO>>(turnos);

            // Pasar los turnos a la vista
            return View(turnosDTO);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
