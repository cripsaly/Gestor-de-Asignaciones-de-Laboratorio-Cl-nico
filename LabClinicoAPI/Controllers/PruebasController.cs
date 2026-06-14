using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClinicoAPI.Context;
using LabClinicoAPI.Models;
using LabClinicoAPI.DTOs;

namespace LabClinicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PruebasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pruebas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PruebaDto>>> GetPruebas()
        {
            var pruebas = await _context.Pruebas.ToListAsync();

            var pruebasDto = pruebas.Select(p => new PruebaDto
            {
                IdPrueba = p.IdPrueba,
                NombrePrueba = p.NombrePrueba,
                Descripcion = p.Descripcion
            }).ToList();

            return Ok(pruebasDto);
        }

        // GET: api/Pruebas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PruebaDto>> GetPrueba(int id)
        {
            var prueba = await _context.Pruebas.FindAsync(id);
            if (prueba == null) return NotFound("Prueba clínica no encontrada.");

            var pruebaDto = new PruebaDto
            {
                IdPrueba = prueba.IdPrueba,
                NombrePrueba = prueba.NombrePrueba,
                Descripcion = prueba.Descripcion
            };

            return Ok(pruebaDto);
        }

        // POST: api/Pruebas
        [HttpPost]
        public async Task<ActionResult<PruebaDto>> PostPrueba(PruebaCreateDto pruebaCreateDto)
        {
            var prueba = new Prueba
            {
                NombrePrueba = pruebaCreateDto.NombrePrueba,
                Descripcion = pruebaCreateDto.Descripcion
            };

            _context.Pruebas.Add(prueba);
            await _context.SaveChangesAsync();

            var pruebaDto = new PruebaDto
            {
                IdPrueba = prueba.IdPrueba,
                NombrePrueba = prueba.NombrePrueba,
                Descripcion = prueba.Descripcion
            };

            return CreatedAtAction(nameof(GetPrueba), new { id = prueba.IdPrueba }, pruebaDto);
        }

        // PUT: api/Pruebas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrueba(int id, PruebaCreateDto pruebaUpdateDto)
        {
            var prueba = await _context.Pruebas.FindAsync(id);
            if (prueba == null) return NotFound("Prueba clínica no encontrada.");

            prueba.NombrePrueba = pruebaUpdateDto.NombrePrueba;
            prueba.Descripcion = pruebaUpdateDto.Descripcion;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pruebas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrueba(int id)
        { 
            var prueba = await _context.Pruebas.FindAsync(id);
            if (prueba == null) return NotFound("Prueba clínica no encontrada.");

            _context.Pruebas.Remove(prueba);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}