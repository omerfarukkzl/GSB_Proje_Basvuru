using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class KullaniciController : ControllerBase
{
    private readonly AppDbContext _context;

    public KullaniciController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Kullanici
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kullanici>>> GetKullanicilar()
    {
        return await _context.Kullanicilar.ToListAsync();
    }

    // GET: api/Kullanici/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Kullanici>> GetKullanici(int id)
    {
        var kullanici = await _context.Kullanicilar.FindAsync(id);

        if (kullanici == null)
        {
            return NotFound();
        }

        return kullanici;
    }

    // POST: api/Kullanici
    [HttpPost]
public async Task<ActionResult<Kullanici>> PostKullanici(KullaniciDto kullaniciDto)
{
    var kullanici = new Kullanici
    {
        KullaniciAdi = kullaniciDto.KullaniciAdi,
        Sifre = kullaniciDto.Sifre
    };

    _context.Kullanicilar.Add(kullanici);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetKullanici), new { id = kullanici.Id }, kullanici);
}

    // DELETE: api/Kullanici/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKullanici(int id)
    {
        var kullanici = await _context.Kullanicilar.FindAsync(id);
        if (kullanici == null)
        {
            return NotFound();
        }

        _context.Kullanicilar.Remove(kullanici);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}