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

   [HttpPost("Register")]
public async Task<ActionResult<Kullanici>> Register([FromBody] RegisterDTO registerDto)
{
    Responses sonuc = new Responses();
    sonuc.message = "Bu kullanıcı adı zaten kullanılıyor.";
    if (registerDto == null || string.IsNullOrEmpty(registerDto.KullaniciAdi) || string.IsNullOrEmpty(registerDto.Sifre))
    {
        return BadRequest("Kullanıcı adı ve şifre gereklidir.");
    }

    var existingUser = await _context.Kullanicilar
        .FirstOrDefaultAsync(u => u.KullaniciAdi == registerDto.KullaniciAdi);
    if (existingUser != null)
    {
        return  BadRequest(sonuc);
    }

    var kullanici = new Kullanici
    {
        KullaniciAdi = registerDto.KullaniciAdi,
        Sifre = registerDto.Sifre,
        RolId = registerDto.RolId,  
        AktiflikDurumu = false,    
        SilinmeDurumu = false     
    };

    _context.Kullanicilar.Add(kullanici);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(Register), new { id = kullanici.Id }, kullanici);
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

    return Ok();
}

    [HttpPost("Login")]
public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
{
    var kullanici = await _context.Kullanicilar
        .Include(k => k.KullaniciRol)
        .FirstOrDefaultAsync(k => k.KullaniciAdi == loginDto.KullaniciAdi && k.Sifre == loginDto.Sifre);

    if (kullanici == null)
    {
        return Unauthorized();  // Kullanıcı adı veya şifre yanlışsa
    }

    if (!kullanici.AktiflikDurumu)
    {
        return Forbid("Kullanıcı hesabı aktif değil.");  // Kullanıcı aktif değilse
    }

    if (kullanici.SilinmeDurumu)
    {
        return NotFound("Kullanıcı bulunamadı.");  // Kullanıcı silinmişse
    }

    // Giriş başarılı, kullanıcının bilgilerini döndürelim
    var result = new
    {
        KullaniciId = kullanici.Id,
        KullaniciAdi = kullanici.KullaniciAdi,
        RolAdi = kullanici.KullaniciRol.RolAdi
    };

    return Ok(result); 
}



}