using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrSystem.DAL;
using QrSystem.Models;
using QrSystem.ViewModel;
using System.Diagnostics;

namespace QrSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]

        public IActionResult Index(int? qrCodeId) // qrCodeId URL'den gelecek
        {
            int? sessionQrCodeId = HttpContext.Session.GetInt32("QrCodeId");
            if (!qrCodeId.HasValue && sessionQrCodeId.HasValue)
            {
                // URL'den qrCodeId gelmediyse ama session'da varsa, session'daki değeri kullan
                qrCodeId = sessionQrCodeId;
            }

            if (qrCodeId.HasValue)
            {
                HttpContext.Session.SetInt32("QrCodeId", qrCodeId.Value);
                ViewBag.QrCodeId = qrCodeId.Value;

                var masa = _appDbContext.Tables.FirstOrDefault(m => m.QrCodeId == qrCodeId.Value);

                if (masa != null)
                {
                    HomeVM homeVM = new HomeVM()
                    {
                        Product = _appDbContext.Products.ToList(),
                        RestourantTables = _appDbContext.Tables.Where(d => d.QrCodeId == qrCodeId.Value).ToList(),
                        ParentsCategory = _appDbContext.ParentsCategories.ToList(),
                    };
                    return View(homeVM);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Masa bulunamadı. Lütfen geçerli bir QR kodu girin.");
                    return View();
                }
            }
            else
            {
                // qrCodeId değeri yoksa ve daha önce de saklanmamışsa, varsayılan davranış
                return RedirectToAction("ErrorPage"); // Varsayılan davranış olarak bir hata sayfasına yönlendirme
            }
        }


        

        public IActionResult Sebet()
        {

            HomeVM homeVM = new HomeVM()
            {
                Product = _appDbContext.Products.ToList(),
            };
            return View(homeVM);
        }
     

    }
}
