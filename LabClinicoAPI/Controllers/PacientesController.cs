using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClinicoAPI.Context;
using LabClinicoAPI.Models;
using LabClinicoAPI.DTOs;

namespace LabClinicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> GetPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();

            var pacientesDto = pacientes.Select(p => new PacienteDto
            {
                IdPaciente = p.IdPaciente,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono
            }).ToList();

            return Ok(pacientesDto);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null) return NotFound("Paciente no encontrado.");

            var pacienteDto = new PacienteDto
            {
                IdPaciente = paciente.IdPaciente,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Telefono = paciente.Telefono
            };

            return Ok(pacienteDto);
        }

        // POST: api/Pacientes
        [HttpPost]
        public async Task<ActionResult<PacienteDto>> PostPaciente(PacienteCreateDto pacienteCreateDto)
        {
            var paciente = new Paciente
            {
                Nombre = pacienteCreateDto.Nombre,
                Apellido = pacienteCreateDto.Apellido,
                Telefono = pacienteCreateDto.Telefono
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            var pacienteDto = new PacienteDto
            {
                IdPaciente = paciente.IdPaciente,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Telefono = paciente.Telefono
            };

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.IdPaciente }, pacienteDto);
        }

        // PUT: api/Pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteCreateDto pacienteUpdateDto)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound("Paciente no encontrado.");

            paciente.Nombre = pacienteUpdateDto.Nombre;
            paciente.Apellido = pacienteUpdateDto.Apellido;
            paciente.Telefono = pacienteUpdateDto.Telefono;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound("Paciente no encontrado.");

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}