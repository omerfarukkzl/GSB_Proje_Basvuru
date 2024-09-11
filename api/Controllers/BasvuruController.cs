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
    public async Task<ActionResult<IEnumerable<BasvuruDto>>> GetBasvurular(
        [FromQuery] string? projeAdi,
        [FromQuery] int? basvuranBirimId,
        [FromQuery] int? basvuruYapilanProjeId,
        [FromQuery] int? basvuruYapilanTurId,
        [FromQuery] int? katilimciTurId,
        [FromQuery] int? basvuruDonemId,
        [FromQuery] int? basvuruDurumId,
        [FromQuery] DateTime? basvuruTarihi,
        [FromQuery] DateTime? aciklanmaTarihi)
    {
        var query = _context.Basvurular.AsQueryable();

        if (!string.IsNullOrEmpty(projeAdi))
            query = query.Where(b => b.ProjeAdi.Contains(projeAdi));
        if (basvuranBirimId.HasValue)
            query = query.Where(b => b.BasvuranBirimId == basvuranBirimId);
        if (basvuruYapilanProjeId.HasValue)
            query = query.Where(b => b.BasvuruYapilanProjeId == basvuruYapilanProjeId);
        if (basvuruYapilanTurId.HasValue)
            query = query.Where(b => b.BasvuruYapilanTurId == basvuruYapilanTurId);
        if (katilimciTurId.HasValue)
            query = query.Where(b => b.KatilimciTurId == katilimciTurId);
        if (basvuruDonemId.HasValue)
            query = query.Where(b => b.BasvuruDonemId == basvuruDonemId);
        if (basvuruDurumId.HasValue)
            query = query.Where(b => b.BasvuruDurumId == basvuruDurumId);
        if (basvuruTarihi.HasValue)
            query = query.Where(b => b.BasvuruTarihi == basvuruTarihi.Value.Date);
        if (aciklanmaTarihi.HasValue)
            query = query.Where(b => b.AciklanmaTarihi == aciklanmaTarihi.Value.Date);

        var basvurular = await query
            .Select(basvuru => new BasvuruDto
            {
                Id = basvuru.Id,
                ProjeAdi = basvuru.ProjeAdi,
                BasvuranBirimId = basvuru.BasvuranBirimId,
                BasvuranBirimAdi = basvuru.BasvuranBirim.Ad,
                BasvuruYapilanProjeId = basvuru.BasvuruYapilanProjeId,
                BasvuruYapilanProjeAdi = basvuru.BasvuruYapilanProje.Ad,
                BasvuruYapilanTurId = basvuru.BasvuruYapilanTurId,
                BasvuruYapilanTurAdi = basvuru.BasvuruYapilanTur.Ad,
                KatilimciTurId = basvuru.KatilimciTurId,
                KatilimciTurAdi = basvuru.KatilimciTuru.Ad,
                BasvuruDonemId = basvuru.BasvuruDonemId,
                BasvuruDonemAdi = basvuru.BasvuruDonemi.Ad,
                BasvuruDurumId = basvuru.BasvuruDurumId,
                BasvuruDurumAdi = basvuru.BasvuruDurumu.Ad,
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