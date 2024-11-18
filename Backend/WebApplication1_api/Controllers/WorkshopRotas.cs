using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1_api.Data;
using WebApplication1_api.Dtos;
using WebApplication1_api.Models;


namespace WebApplication1_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkshopController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/workshop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkshopWithColaboradoresDto>>> GetWorkshops()
        {
            var workshops = await _context.Workshops
                .Include(w => w.Colaboradores)
                .Select(w => new WorkshopWithColaboradoresDto
                {
                    Id = w.Id,
                    Nome = w.Nome,
                    Data = w.Data,
                    Descricao = w.Descricao,
                    Colaboradores = w.Colaboradores.Select(c => new ColaboradorDto
                    {
                        Id = c.Id,
                        Nome = c.Nome
                    }).ToList()
                })
                .ToListAsync();

            return Ok(workshops);
        }

        // GET: api/workshop/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkshopWithColaboradoresDto>> GetWorkshop(int id)
        {
            var workshop = await _context.Workshops
                .Include(w => w.Colaboradores)
                .Where(w => w.Id == id)
                .Select(w => new WorkshopWithColaboradoresDto
                {
                    Id = w.Id,
                    Nome = w.Nome,
                    Data = w.Data,
                    Descricao = w.Descricao,
                    Colaboradores = w.Colaboradores.Select(c => new ColaboradorDto
                    {
                        Id = c.Id,
                        Nome = c.Nome
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (workshop == null)
                return NotFound("Workshop não encontrado.");

            return Ok(workshop);
        }


        // POST: api/workshop
        [HttpPost]
        public async Task<IActionResult> CreateWorkshop([FromBody] WorkshopDto dto)
        {
            if (dto == null)
                return BadRequest("Workshop inválido.");

            var workshop = new Workshop
            {
                Nome = dto.Nome,
                Data = dto.Data,
                Descricao = dto.Descricao,
                Colaboradores = await _context.Colaboradores
                    .Where(c => dto.ColaboradoresIds.Contains(c.Id))
                    .ToListAsync()
            };

            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkshop), new { id = workshop.Id }, dto);
        }

        // PUT: api/workshop/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkshop(int id, [FromBody] WorkshopDto dto)
        {
            if (dto == null)
                return BadRequest("Dados inválidos para atualização.");

            var workshop = await _context.Workshops
                .Include(w => w.Colaboradores)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workshop == null)
                return NotFound("Workshop não encontrado.");

            // Atualiza as propriedades do workshop
            workshop.Nome = dto.Nome;
            workshop.Data = dto.Data;
            workshop.Descricao = dto.Descricao;

            // Atualiza os colaboradores vinculados
            workshop.Colaboradores = await _context.Colaboradores
                .Where(c => dto.ColaboradoresIds.Contains(c.Id))
                .ToListAsync();

            _context.Workshops.Update(workshop);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/workshop/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkshop(int id)
        {
            var workshop = await _context.Workshops.FindAsync(id);
            if (workshop == null)
                return NotFound("Workshop não encontrado.");

            _context.Workshops.Remove(workshop);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
