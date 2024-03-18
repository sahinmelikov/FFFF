using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrSystem.DAL;
using QrSystem.Models;
using QrSystem.Models.Auth;
using QrSystem.ViewModel;
using System.Security.Claims;

namespace QrSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TableController:Controller
    {
        private readonly UserManager<AppUser> _userManager;

        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public TableController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            // Kullanıcının bağlı olduğu restoranın ID'sini alın
            int restorantId = GetCurrentUserRestorantId();

            // Kullanıcının bağlı olduğu restorana ait masaları getirin
            var tables = _context.Tables.Include(d=>d.QrCode.Restorant).Where(t => t.QrCode.RestorantId == restorantId).ToList();

            return View(tables);
        }

        // Kullanıcının bağlı olduğu restoranın ID'sini döndüren yardımcı bir metot
        private int GetCurrentUserRestorantId()
        {
            // Kullanıcının kimliğini alın
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Kullanıcının bağlı olduğu restoranın ID'sini veritabanından alın
            var user = _userManager.FindByIdAsync(userId).Result;
            var restorantId = user.RestorantId;

            return restorantId.HasValue ? restorantId.Value : 0; // Varsayılan değer olarak 0 kullanıldı, siz istediğiniz bir değeri verebilirsiniz.
        }
        public IActionResult Create()
        {
            // Kullanıcının bağlı olduğu restoranın ID'sini alın
            int restorantId = GetCurrentUserRestorantId();

            // Restoran ID'si bulunamazsa hata mesajı döndürün veya uygun bir işlem yapın
            if (restorantId == 0)
            {
                // Hata mesajı göstermek için ModelState kullanabilirsiniz
                ModelState.AddModelError(string.Empty, "Restoran bulunamadı.");
                return View();
            }

            // Restoran ID'si bulunduysa, yeni bir QR kodu oluşturmak için kullanabiliriz
            var qrVM = new TableVM { RestorantId = restorantId };
            return View(qrVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TableVM tableVM)
        {
            // Kullanıcının bağlı olduğu restoranın ID'sini alın
            int restorantId = GetCurrentUserRestorantId();
            
            RestourantTables tables = new RestourantTables { QrCodeId = tableVM.QrCodeId, TableNumber = tableVM.TableNumber, DateTime = DateTime.Now  };
            _context.Tables.Add(tables);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            RestourantTables tables= _context.Tables.Find(id);
            if (tables is null) return NotFound();
            _context.Tables.Remove(tables);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
