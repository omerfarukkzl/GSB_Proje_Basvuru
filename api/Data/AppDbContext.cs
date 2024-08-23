using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Basvuru> Basvurular { get; set; }
    public DbSet<KullaniciBasvuru> KullaniciBasvurular { get; set; }
    public DbSet<Tip> Tipler { get; set; }
    public DbSet<AltTip> AltTipler { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KullaniciBasvuru>()
            .HasKey(kb => new { kb.KullaniciId, kb.BasvuruId });

        modelBuilder.Entity<KullaniciBasvuru>()
            .HasOne(kb => kb.Kullanici)
            .WithMany(k => k.KullaniciBasvurulari)
            .HasForeignKey(kb => kb.KullaniciId);

        modelBuilder.Entity<KullaniciBasvuru>()
            .HasOne(kb => kb.Basvuru)
            .WithMany(b => b.KullaniciBasvurular)
            .HasForeignKey(kb => kb.BasvuruId);

        modelBuilder.Entity<AltTip>()
            .HasOne(at => at.Tip)
            .WithMany(t => t.AltTipler)
            .HasForeignKey(at => at.TipId);

         modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruDurumu)
            .WithMany(t => t.Basvurular)
            .HasForeignKey(b => b.BasvuruDurumId);

        modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruYapilanProje)
            .WithMany(t => t.BasvurularProje)
            .HasForeignKey(b => b.BasvuruYapilanProjeId);

    modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruYapilanTur)
            .WithMany(t => t.BasvurularTur)
            .HasForeignKey(b => b.BasvuruYapilanTurId);
    }
}