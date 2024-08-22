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
            var Kullanici = _context.Kullanici.ToList().Select(s => s.toKullaniciDto());
            return Ok(Kullanici);
        }

        [HttpGet("{KullaniciId}")]
        public async Task<ActionResult<Kullanici>> GetKullaniciId(int KullaniciId)
        {
            var Kullanici = await _context.Kullanici.FindAsync(KullaniciId);
            return Ok(Kullanici.toKullaniciDto());
        }


        [HttpPost]
        public async Task<ActionResult<Kullanici>> PostKullanici(Kullanici kullaniciItem)
        {
            _context.Kullanici.Add(kullaniciItem);
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
            var kullaniciItem = await _context.Kullanici.FindAsync(KullaniciId);
            if (kullaniciItem == null)
            {
                return NotFound();
            }

            _context.Kullanici.Remove(kullaniciItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool KullaniciExists(int KullaniciId)
        {
            return _context.Kullanici.Any(e => e.KullaniciId == KullaniciId);
        }










    }


}
