using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;
using TurneroMedico.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TurneroMedico.Controllers
{
    public class TurnoController : Controller
    {
        private readonly ITurnoRepository<Turno> _turnorepository;
        private readonly IMapper _mapper;

        public TurnoController(ITurnoRepository<Turno> turnoRepository, IMapper mapper)
        {
            _turnorepository = turnoRepository;
            _mapper = mapper;
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
            var turnos = await _turnorepository.GetAllAsync();
            var turnosDTO = _mapper.Map<IEnumerable<TurnoDTO>>(turnos);
            return View(turnosDTO);
        }

        // GET: Turno/Create
        public IActionResult Create()
        {
            return View();

        }

        // POST: Turno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TurnoDTO turnoDTO)
        {
            if (ModelState.IsValid)
            {
                var turno = _mapper.Map<Turno>(turnoDTO);
                await _turnorepository.AddAsync(turno);
                return RedirectToAction(nameof(Index));
            }

            return View(turnoDTO);
        }

        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var turno = await _turnorepository.GetByIdAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            var turnoDTO = _mapper.Map<TurnoDTO>(turno);
            return View(turnoDTO);
        }

        // POST: Turno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TurnoDTO turnoDTO)
        {
            if (id != turnoDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var turno = _mapper.Map<Turno>(turnoDTO);
                await _turnorepository.UpdateAsync(turno);
                return RedirectToAction(nameof(Index));
            }

            return View(turnoDTO);
        }

        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var turno = await _turnorepository.GetByIdAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            var turnoDTO = _mapper.Map<TurnoDTO>(turno);
            return View(turnoDTO);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _turnorepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
