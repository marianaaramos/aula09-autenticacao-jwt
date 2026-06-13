using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aula08.Data;
using aula08.Models;

namespace aula08.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FornecedorController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get() => await _context.Fornecedores.ToListAsync();

        [HttpPost]
        public async Task<ActionResult> Post(Fornecedor f) {
            _context.Fornecedores.Add(f);
            await _context.SaveChangesAsync();
            return Ok(f);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, Fornecedor f) {
            var banco = await _context.Fornecedores.FindAsync(codigo);
            if (banco == null) return NotFound();
            banco.Nome = f.Nome; banco.Cnpj = f.Cnpj; banco.Email = f.Email; banco.Telefone = f.Telefone;
            await _context.SaveChangesAsync();
            return Ok(banco);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo) {
            var f = await _context.Fornecedores.FindAsync(codigo);
            if (f == null) return NotFound();
            _context.Fornecedores.Remove(f);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}