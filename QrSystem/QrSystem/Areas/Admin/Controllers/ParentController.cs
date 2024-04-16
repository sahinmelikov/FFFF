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
    
    public class ParentController: Controller
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        public ParentController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager = null)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            // Kullanıcının bağlı olduğu restoranın ID'sini alın
            int restorantId = GetCurrentUserRestorantId();

            // İstenen restoranın ID'sine sahip olan restoranı ve onun ürünlerini getirin
            var restoran = _context.Restorant

                                   .Include(r => r.ParentCategories) // Restoranın ürünlerini de getirin
                                   .FirstOrDefault(r => r.Id == restorantId);

            if (restoran == null)
            {
                // Eğer istenen restoran bulunamazsa, hata mesajı gösterin
                ViewBag.ErrorMessage = "No matching restaurant found!";
                return View();
            }

            return View(restoran.ParentCategories);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            ParentCategory parents = _context.ParentsCategories.Find(id);
            if (parents is null) return NotFound();
            _context.ParentsCategories.Remove(parents);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
            var qrVM = new ParentCategoryVM { RestorantId = restorantId };
            return View(qrVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ParentCategoryVM productVM)
        {
            // Kullanıcının bağlı olduğu restoranın ID'sini alın
            int restorantId = GetCurrentUserRestorantId();
          
           
           
            ParentCategory product = new ParentCategory { Name = productVM.Name, bigParentCategoryId=productVM.bigParentCategoryId ,RestorantId=restorantId};
            _context.ParentsCategories.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
