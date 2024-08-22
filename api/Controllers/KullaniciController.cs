using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetKullanici()
        {
            var kullanicis = _context.Kullanicis.ToList().Select(s => s.toKullaniciDto());
            return Ok(kullanicis);
        }

        [HttpGet("{KullaniciId}")]
        public async Task<ActionResult<Kullanici>> GetKullaniciId(int KullaniciId)
        {
            var Kullanicis = await _context.Kullanicis.FindAsync(KullaniciId);
            return Ok(Kullanicis.toKullaniciDto());
        }


        [HttpPost]
        public async Task<ActionResult<Kullanici>> PostKullanici(Kullanici kullaniciItem)
        {
            _context.Kullanicis.Add(kullaniciItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetKullanici), new { id = kullaniciItem.KullaniciId }, kullaniciItem);
        }

        [HttpPut("{KullaniciId}")]
        public async Task<IActionResult> PutKullanici(int KullaniciId, Kullanici kullaniciItem)
        {
            if (KullaniciId != kullaniciItem.KullaniciId)
            {
                return BadRequest();
            }

            _context.Entry(kullaniciItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciExists(KullaniciId))
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


        [HttpDelete("{KullaniciId}")]
        public async Task<IActionResult> DeleteKullanici(int KullaniciId)
        {
            var kullaniciItem = await _context.Kullanicis.FindAsync(KullaniciId);
            if (kullaniciItem == null)
            {
                return NotFound();
            }

            _context.Kullanicis.Remove(kullaniciItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool KullaniciExists(int KullaniciId)
        {
            return _context.Kullanicis.Any(e => e.KullaniciId == KullaniciId);
        }










    }


}
