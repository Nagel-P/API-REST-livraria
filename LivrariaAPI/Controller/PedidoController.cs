using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LivrariaAPI.Data;
using LivrariaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly LivrariaContext _context;

        public PedidosController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: api/pedidos
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            return _context.Pedidos.Include(p => p.Cliente).Include(p => p.Livros).ToList();
        }

        // POST: api/pedidos
        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Id }, pedido);
        }

        // PUT: api/pedidos/{id}
        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pedidos.Any(e => e.Id == id))
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

        // DELETE: api/pedidos/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
