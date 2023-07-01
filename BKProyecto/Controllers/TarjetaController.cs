using BKProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BKProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarjetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaTarjetas = await _context.TarjetaCreditos.ToListAsync();
                return Ok(listaTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TarjetaCredito tarjeta )
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (id != tarjeta.Id)
                {
                    return NotFound();
                }
                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new{message = "tarjeta actualizada"});
            }
            catch (Exception ex)
            {
                    return BadRequest($"{ex.Message}");
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCreditos.FindAsync(id);
                if (tarjeta == null)
                {
                    return NotFound();
                }
                _context.TarjetaCreditos.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "tarjeta fue eliminada" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
