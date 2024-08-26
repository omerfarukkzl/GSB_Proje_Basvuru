using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class KullaniciBasvuruController : ControllerBase
{
    private readonly AppDbContext _context;

    public KullaniciBasvuruController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/KullaniciBasvuru
    [HttpGet]
    public async Task<ActionResult<IEnumerable<KullaniciBasvuruDto>>> GetKullaniciBasvurular()
    {
        var kullaniciBasvurular = await _context.KullaniciBasvurular
            .Select(kb => new KullaniciBasvuruDto
            {
                KullaniciId = kb.KullaniciId,
                BasvuruId = kb.BasvuruId
            }).ToListAsync();

        return Ok(kullaniciBasvurular);
    }

    // POST: api/KullaniciBasvuru
    [HttpPost]
    public async Task<ActionResult<KullaniciBasvuruDto>> PostKullaniciBasvuru(KullaniciBasvuruDto kullaniciBasvuruDto)
    {
        var kullaniciBasvuru = new KullaniciBasvuru
        {
            KullaniciId = kullaniciBasvuruDto.KullaniciId,
            BasvuruId = kullaniciBasvuruDto.BasvuruId
        };

        _context.KullaniciBasvurular.Add(kullaniciBasvuru);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetKullaniciBasvurular), new { id = kullaniciBasvuru.KullaniciId }, kullaniciBasvuruDto);
    }

    // DELETE: api/KullaniciBasvuru/5
    [HttpDelete("{kullaniciId}/{basvuruId}")]
    public async Task<IActionResult> DeleteKullaniciBasvuru(int kullaniciId, int basvuruId)
    {
        var kullaniciBasvuru = await _context.KullaniciBasvurular.FindAsync(kullaniciId, basvuruId);
        if (kullaniciBasvuru == null)
        {
            return NotFound();
        }

        _context.KullaniciBasvurular.Remove(kullaniciBasvuru);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}