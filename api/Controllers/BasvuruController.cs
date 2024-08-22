using api.Data;
using api.Dtos.Kullanici;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasvuruController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BasvuruController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBasvuru()
        {
            var basvurus = _context.Basvurus.ToList().Select(b => b.toBasvuruDto());
            return Ok(basvurus);
        }

        [HttpGet("{BasvuruId}")]
        public async Task<ActionResult<Kullanici>> GetBasvuruId(int BasvuruId)
        {
            var Basvurus = await _context.Basvurus.FindAsync(BasvuruId);
            return Ok(Basvurus.toBasvuruDto());
        }


        [HttpPost]

        public IActionResult PostBasvuru([FromBody] BasvuruDto basvuruDto)
        {
            var basvuruModel = basvuruDto.toBasvuruModel();
            _context.Basvurus.Add(basvuruModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBasvuru), new { id = basvuruModel.BasvuruId }, basvuruModel);
        }




        

     /*   [HttpPut("{KullaniciId}")]
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

*/
        [HttpDelete("{BasvuruId}")]
        public async Task<IActionResult> DeleteBasvuru(int BasvuruId)
        {
            var basvuruItem = await _context.Basvurus.FindAsync(BasvuruId);
            if (basvuruItem == null)
            {
                return NotFound();
            }

            _context.Basvurus.Remove(basvuruItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


     /*   private bool KullaniciExists(int KullaniciId)
        {
            return _context.Kullanicis.Any(e => e.KullaniciId == KullaniciId);


        }


*/









    }


}
