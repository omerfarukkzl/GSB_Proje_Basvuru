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
    public async Task<ActionResult<IEnumerable<Basvuru>>> GetBasvurular()
    {
        return await _context.Basvurular.ToListAsync();
    }

    // GET: api/Basvuru/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Basvuru>> GetBasvuru(int id)
    {
        var basvuru = await _context.Basvurular.FindAsync(id);

        if (basvuru == null)
        {
            return NotFound();
        }

        return basvuru;
    }

    // POST: api/Basvuru
    [HttpPost]
    public async Task<ActionResult<Basvuru>> PostBasvuru(Basvuru basvuru)
    {
        _context.Basvurular.Add(basvuru);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBasvuru), new { id = basvuru.Id }, basvuru);
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