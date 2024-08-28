using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(KullaniciDto kullaniciDto)
        {
            if (await _context.Kullanicilar.AnyAsync(x => x.KullaniciAdi == kullaniciDto.KullaniciAdi))
                return BadRequest("Kullanıcı zaten mevcut.");

            var yeniKullanici = new Kullanici
            {
                KullaniciAdi = kullaniciDto.KullaniciAdi,
                Sifre = HashPassword(kullaniciDto.Sifre)
                // Diğer alanları buraya ekleyebilirsiniz.
            };

            _context.Kullanicilar.Add(yeniKullanici);
            await _context.SaveChangesAsync();

            return Ok("Kullanıcı başarıyla kayıt oldu.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(KullaniciDto kullaniciDto)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(x => x.KullaniciAdi == kullaniciDto.KullaniciAdi);

            if (kullanici == null || HashPassword(kullaniciDto.Sifre) != kullanici.Sifre)
                return Unauthorized("Geçersiz email veya şifre.");

            // Token oluşturma işlemi burada olabilir.
            return Ok("Giriş başarılı.");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a string.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

      
    }
}

