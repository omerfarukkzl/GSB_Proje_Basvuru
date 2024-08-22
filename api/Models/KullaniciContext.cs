using api.Controllers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class KullaniciContext : DbContext
{
    public KullaniciContext(DbContextOptions<KullaniciContext> options)
        : base(options)
    {
    }

    public DbSet<Kullanici> KullaniciItems { get; set; } = null!;
}