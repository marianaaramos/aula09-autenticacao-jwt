using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aula08.Models;
using aula08.Data;

namespace aula08.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll() => await _context.Clientes.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Update(int codigo, Cliente cliente)
        {
            if (codigo != cliente.Codigo) return BadRequest();
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            var cliente = await _context.Clientes.FindAsync(codigo);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}