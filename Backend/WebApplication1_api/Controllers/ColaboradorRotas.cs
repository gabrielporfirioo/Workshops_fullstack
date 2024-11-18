using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1_api.Data;
using WebApplication1_api.Dtos;
using WebApplication1_api.Models;
using System.Linq;

namespace WebApplication1_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/colaborador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorDto>>> GetColaboradores()
        {
            var colaboradores = await _context.Colaboradores
                .Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Nome = c.Nome
                })
                .ToListAsync();

            return Ok(colaboradores);
        }

        // GET: api/colaborador/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorDto>> GetColaborador(int id)
        {
            var colaborador = await _context.Colaboradores
                .Where(c => c.Id == id)
                .Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Nome = c.Nome
                })
                .FirstOrDefaultAsync();

            if (colaborador == null)
                return NotFound("Colaborador não encontrado.");

            return Ok(colaborador);
        }

        // POST: api/colaborador
        [HttpPost]
        public async Task<IActionResult> CreateColaborador([FromBody] ColaboradorDto dto)
        {
            if (dto == null)
                return BadRequest("Colaborador inválido.");

            var colaborador = new Colaborador
            {
                Nome = dto.Nome
            };

            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id }, dto);
        }

        // PUT: api/colaborador/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColaborador(int id, [FromBody] ColaboradorDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest("Dados inválidos para atualização.");

            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
                return NotFound("Colaborador não encontrado.");

            colaborador.Nome = dto.Nome;

            _context.Colaboradores.Update(colaborador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/colaborador/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
                return NotFound("Colaborador não encontrado.");

            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
