using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var tables = _context.Tables.Where(t => t.QrCode.RestorantId == restorantId).ToList();

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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TableVM tableVM)
        {
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
