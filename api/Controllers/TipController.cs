using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TipController : ControllerBase
{
    private readonly AppDbContext _context;

    public TipController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Tip
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipDto>>> GetTipler()
    {
        var tipler = await _context.Tipler
            .Select(tip => new TipDto
            {
                Id = tip.Id,
                Ad = tip.Ad
            }).ToListAsync();

        return Ok(tipler);
    }

    // POST: api/Tip
    [HttpPost]
    public async Task<ActionResult<TipDto>> PostTip(TipDto tipDto)
    {
        var tip = new Tip
        {
            Ad = tipDto.Ad
        };

        _context.Tipler.Add(tip);
        await _context.SaveChangesAsync();

        tipDto.Id = tip.Id;

        return CreatedAtAction(nameof(GetTipler), new { id = tipDto.Id }, tipDto);
    }

    // DELETE: api/Tip/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTip(int id)
    {
        var tip = await _context.Tipler.FindAsync(id);
        if (tip == null)
        {
            return NotFound();
        }

        _context.Tipler.Remove(tip);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}