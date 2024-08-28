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
            select new KullaniciDto
            {
                KullaniciAdi = k.KullaniciAdi,
                Sifre = k.Sifre,
                RolAdi = r.RolAdi,
                RolId = k.RolId


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

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var kullanici = await _context.Kullanicilar
            .Include(k => k.KullaniciRol)
            .FirstOrDefaultAsync(k => k.KullaniciAdi == loginDto.KullaniciAdi && k.Sifre == loginDto.Sifre);

        if (kullanici == null)
        {
            return Unauthorized();  // Kullanıcı adı veya şifre yanlışsa 401 Unauthorized döndür
        }

        // Giriş başarılı, kullanıcının bilgilerini dönelim
        var result = new
        {
            KullaniciId = kullanici.Id,
            KullaniciAdi = kullanici.KullaniciAdi,
            RolAdi = kullanici.KullaniciRol.RolAdi
        };

        return Ok(result);  // 200 OK ve kullanıcı bilgilerini JSON olarak döndür
    }



}