using api.Mappings;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Basvuru> Basvurular { get; set; }
    public DbSet<KullaniciBasvuru> KullaniciBasvurular { get; set; }
    public DbSet<Tip> Tipler { get; set; }
    public DbSet<AltTip> AltTipler { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // MySQL
            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            //string strBaglanti = configuration.GetConnectionString("MySQLServerProvider");
            //optionsBuilder.UseMySql("server=localhost;database=veritabaniDB;user=root;password=SQLSifresi;", ServerVersion.AutoDetect("server=localhost;database=coreDB;user=root;password=root;"));
            //optionsBuilder.EnableSensitiveDataLogging();

            // PostgreSQL
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            string strBaglanti = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(strBaglanti);
            // optionsBuilder.UseNpgsql("User ID=postgres;Password=SQLSifresi;Server=localhost;Port=5432;Database=mikroDB;Integrated Security=true;Pooling=true;");

            // SQLServer
            // IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            // string? strBaglanti = configuration.GetConnectionString("SQLServerProvider");
            // optionsBuilder.UseSqlServer(strBaglanti, builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
            // optionsBuilder.UseSqlServer("Server=.;Database=cizgisiteDB;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;TrustServerCertificate=True");
            // optionsBuilder.UseSqlServer("Server=localhost;Database=veritabaniDB;User ID=user;Password=SQLSifresi;trusted_connection=false;MultipleActiveResultSets=true;TrustServerCertificate=True");


            // Oracle
            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            //string strBaglanti = configuration.GetConnectionString("OracleProvider");
            //optionsBuilder.UseOracle("User Id=SYSTEM;Password=SQLSifresi;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))", options => options.UseOracleSQLCompatibility("12"));
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   

        modelBuilder.ApplyConfiguration(new KullaniciMap());
        modelBuilder.ApplyConfiguration(new TipMap());
        modelBuilder.ApplyConfiguration(new AltTipMap());
        modelBuilder.ApplyConfiguration(new BasvuruMap());       
        modelBuilder.ApplyConfiguration(new KullaniciBasvuruMap());



       /* modelBuilder.Entity<KullaniciBasvuru>()
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
            .WithMany(t => t.ListAltTipler)
            .HasForeignKey(at => at.TipId);

         modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruDurumu)
            .WithMany(t => t.ListBasvurularDurum)
            .HasForeignKey(b => b.BasvuruDurumId);

        modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruYapilanProje)
            .WithMany(t => t.ListBasvurularProje)
            .HasForeignKey(b => b.BasvuruYapilanProjeId);

        modelBuilder.Entity<Basvuru>()
            .HasOne(b => b.BasvuruYapilanTur)
            .WithMany(t => t.ListBasvurularTur)
            .HasForeignKey(b => b.BasvuruYapilanTurId);  */
    }
}