using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BasvuruController : ControllerBase
{
    private readonly AppDbContext _context;

    public BasvuruController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Basvuru
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BasvuruDto>>> GetBasvurular()
    {
        var basvurular = await _context.Basvurular
            .Select(basvuru => new BasvuruDto
            {
                Id = basvuru.Id,
                ProjeAdi = basvuru.ProjeAdi,
                BasvuranBirimId = basvuru.BasvuranBirimId,
                BasvuruYapilanProjeId = basvuru.BasvuruYapilanProjeId,
                BasvuruYapilanTurId = basvuru.BasvuruYapilanTurId,
                KatilimciTurId = basvuru.KatilimciTurId,
                BasvuruDonemId = basvuru.BasvuruDonemId,
                BasvuruDurumId = basvuru.BasvuruDurumId,
                BasvuruTarihi = basvuru.BasvuruTarihi,
                AciklanmaTarihi = basvuru.AciklanmaTarihi,
                HibeTutari = basvuru.HibeTutari
            }).ToListAsync();

        return Ok(basvurular);
    }

    // GET: api/Basvuru/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BasvuruDto>> GetBasvuru(int id)
    {
        var basvuru = await _context.Basvurular
            .Select(basvuru => new BasvuruDto
            {
                Id = basvuru.Id,
                ProjeAdi = basvuru.ProjeAdi,
                BasvuranBirimId = basvuru.BasvuranBirimId,
                BasvuruYapilanProjeId = basvuru.BasvuruYapilanProjeId,
                BasvuruYapilanTurId = basvuru.BasvuruYapilanTurId,
                KatilimciTurId = basvuru.KatilimciTurId,
                BasvuruDonemId = basvuru.BasvuruDonemId,
                BasvuruDurumId = basvuru.BasvuruDurumId,
                BasvuruTarihi = basvuru.BasvuruTarihi,
                AciklanmaTarihi = basvuru.AciklanmaTarihi,
                HibeTutari = basvuru.HibeTutari
            }).FirstOrDefaultAsync(b => b.Id == id);

        if (basvuru == null)
        {
            return NotFound();
        }

        return Ok(basvuru);
    }

    // POST: api/Basvuru
    [HttpPost]
public async Task<ActionResult<BasvuruDto>> PostBasvuru(BasvuruDto basvuruDto)
{
    var basvuru = new Basvuru
    {
        ProjeAdi = basvuruDto.ProjeAdi,
        BasvuranBirimId = basvuruDto.BasvuranBirimId,
        BasvuruYapilanProjeId = basvuruDto.BasvuruYapilanProjeId,
        BasvuruYapilanTurId = basvuruDto.BasvuruYapilanTurId,
        KatilimciTurId = basvuruDto.KatilimciTurId,
        BasvuruDonemId = basvuruDto.BasvuruDonemId,
        BasvuruDurumId = basvuruDto.BasvuruDurumId,
        BasvuruTarihi = basvuruDto.BasvuruTarihi,  
        AciklanmaTarihi = basvuruDto.AciklanmaTarihi,
        HibeTutari = basvuruDto.HibeTutari
    };

    _context.Basvurular.Add(basvuru);
    await _context.SaveChangesAsync();

    basvuruDto.Id = basvuru.Id;

    return CreatedAtAction(nameof(GetBasvuru), new { id = basvuruDto.Id }, basvuruDto);
}

    // DELETE: api/Basvuru/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBasvuru(int id)
    {
        var basvuru = await _context.Basvurular.FindAsync(id);
        if (basvuru == null)
        {
            return NotFound();
        }

        _context.Basvurular.Remove(basvuru);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}