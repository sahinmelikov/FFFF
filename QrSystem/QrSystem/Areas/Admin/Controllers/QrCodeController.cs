using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrSystem.DAL;
using QrSystem.Models;
using QrSystem.ViewModel;

namespace QrSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QrCodeController: Controller
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public QrCodeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.QrCodes.Include(d=>d.Restorant).ToList());
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            QrCode qrCode= _context.QrCodes.Find(id);
            if (qrCode is null) return NotFound();
            _context.QrCodes.Remove(qrCode);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QrCodeVM qrVM)
        {
          
            // QrCode nesnesini oluştururken Restorant özelliğine bu restorantı atayın
            QrCode qrCode = new QrCode
            {
                QRCode = qrVM.QrCode,
                DateTime = DateTime.Now,
                RestorantId = qrVM.RestorantId
            };

            // QrCode nesnesini veritabanına ekleyin
            _context.QrCodes.Add(qrCode);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
