using Microsoft.EntityFrameworkCore; // Para EntityState e DbUpdateConcurrencyException
using Microsoft.AspNetCore.Mvc; // Para ControllerBase e ActionResult
using LivrariaAPI.Data; // Para LivrariaContext
using LivrariaAPI.Models; // Para Livro
using System.Collections.Generic; // Para IEnumerable
using System.Linq; // Para ToList


namespace LivrariaAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrariaContext _context;

        public LivrosController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: api/livros
        [HttpGet]
        public ActionResult<IEnumerable<Livro>> GetLivros()
        {
            return _context.Livros.ToList();
        }

        // POST: api/livros
        [HttpPost]
        public ActionResult<Livro> PostLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLivros), new { id = livro.Id }, livro);
        }

        // PUT: api/livros/{id}
        [HttpPut("{id}")]
        public IActionResult PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Livros.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/livros/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
