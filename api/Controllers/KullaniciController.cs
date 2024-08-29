using api.Classes;
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
        var sorgu = from k in _context.Kullanicilar
        join r in _context.Roller on k.RolId equals r.Id
        where !k.SilinmeDurumu
            select new KullaniciDto
            {
                Id = k.Id,
                KullaniciAdi = k.KullaniciAdi,
                Sifre = k.Sifre,
                RolAdi = r.RolAdi,
                RolId = k.RolId,
                AktiflikDurumu = k.AktiflikDurumu,
                SilinmeDurumu = k.SilinmeDurumu


            };
        return Ok(sorgu);
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
        Sifre = kullaniciDto.Sifre,
        RolId = kullaniciDto.RolId,
        AktiflikDurumu = true,
        SilinmeDurumu = false
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

        kullanici.SilinmeDurumu = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
public async Task<IActionResult> UpdateUserStatus(int id, [FromBody] UpdateUserStatusDto updateUserStatusDto)
{

    Responses sonuc = new Responses();
    sonuc.result = 0;
    sonuc.message = "Bir hata oluştu";


    var kullanici = await _context.Kullanicilar.FindAsync(id);

    if (kullanici != null)
    {
        string kullaniciAdi = kullanici.KullaniciAdi;
        kullanici.AktiflikDurumu = updateUserStatusDto.AktiflikDurumu;
        kullanici.SilinmeDurumu = updateUserStatusDto.SilinmeDurumu;
        await _context.SaveChangesAsync();
        sonuc.result = 1;
        sonuc.message = $"{kullaniciAdi} adlı kullanıcının durumu güncellendi ";
    }
    return Ok(sonuc);



   /* if (kullanici == null)
    {
        return NotFound();
    }

    kullanici.SilinmeDurumu = updateUserStatusDto.SilinmeDurumu;
    kullanici.AktiflikDurumu = updateUserStatusDto.AktiflikDurumu;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Kullanicilar.Any(e => e.Id == id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }
*/
    return Ok();
}

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var kullanici = await _context.Kullanicilar
            .Include(k => k.KullaniciRol)
            .FirstOrDefaultAsync(k => k.KullaniciAdi == loginDto.KullaniciAdi && k.Sifre == loginDto.Sifre && k.AktiflikDurumu && !k.SilinmeDurumu );

        if (kullanici == null)
        {
            return Unauthorized();  // k.adı veya şifre yanlıssa
        }

        // Giriş başarılı, kullanıcının bilgilerini dönelim
        var result = new
        {
            KullaniciId = kullanici.Id,
            KullaniciAdi = kullanici.KullaniciAdi,
            RolAdi = kullanici.KullaniciRol.RolAdi
        };

        return Ok(result); 
    }



}