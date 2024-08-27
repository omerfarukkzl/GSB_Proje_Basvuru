using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AltTipController : ControllerBase
{
    private readonly AppDbContext _context;

    public AltTipController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/AltTip
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AltTipDto>>> GetAltTipler()
    {
    
        var altTipler = await _context.AltTipler
            .Select(altTip => new AltTipDto
            {
                Id = altTip.Id,
                Ad = altTip.Ad,
                TipId = altTip.TipId
            }).ToListAsync();

        return Ok(altTipler);
    }

    // POST: api/AltTip
    [HttpPost]
    public async Task<ActionResult<AltTipDto>> PostAltTip(AltTipDto altTipDto)
    {
        var altTip = new AltTip
        {
            Ad = altTipDto.Ad,
            TipId = altTipDto.TipId
        };

        _context.AltTipler.Add(altTip);
        await _context.SaveChangesAsync();

        altTipDto.Id = altTip.Id;

        return CreatedAtAction(nameof(GetAltTipler), new { id = altTipDto.Id }, altTipDto);
    }

    // DELETE: api/AltTip/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAltTip(int id)
    {
        var altTip = await _context.AltTipler.FindAsync(id);
        if (altTip == null)
        {
            return NotFound();
        }

        _context.AltTipler.Remove(altTip);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}