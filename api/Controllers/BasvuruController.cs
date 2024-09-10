using api.DTOs;
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
    public async Task<ActionResult<IEnumerable<BasvuruDto>>> GetBasvurular([FromQuery] BasvuruFiltreDTO filtre)
    {
        var query = _context.Basvurular.AsQueryable();

        if (filtre != null)
        {
            if (!string.IsNullOrEmpty(filtre.ProjeAdi))
                query = query.Where(b => b.ProjeAdi.Contains(filtre.ProjeAdi));

            if (filtre.BasvuranBirimId.HasValue)
                query = query.Where(b => b.BasvuranBirimId == filtre.BasvuranBirimId);

            if (filtre.BasvuruYapilanProjeId.HasValue)
                query = query.Where(b => b.BasvuruYapilanProjeId == filtre.BasvuruYapilanProjeId);

            if (filtre.BasvuruYapilanTurId.HasValue)
                query = query.Where(b => b.BasvuruYapilanTurId == filtre.BasvuruYapilanTurId);

            if (filtre.KatilimciTurId.HasValue)
                query = query.Where(b => b.KatilimciTurId == filtre.KatilimciTurId);

            if (filtre.BasvuruDonemId.HasValue)
                query = query.Where(b => b.BasvuruDonemId == filtre.BasvuruDonemId);

            if (filtre.BasvuruDurumId.HasValue)
                query = query.Where(b => b.BasvuruDurumId == filtre.BasvuruDurumId);

            if (filtre.BasvuruTarihiBaslangic.HasValue)
                query = query.Where(b => b.BasvuruTarihi >= filtre.BasvuruTarihiBaslangic);

            if (filtre.BasvuruTarihiBitis.HasValue)
                query = query.Where(b => b.BasvuruTarihi <= filtre.BasvuruTarihiBitis);
        }

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