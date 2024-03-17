using QrSystem.Models.Auth;

using QrSystem.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;  
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using QrSystem.Models.Auth;
using System.Net.Mail;
using QrSystem.DAL;
using QrSystem.Models;

namespace QrSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _appDbContext;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser newUser = new AppUser()
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };
            IdentityResult registerResult = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!registerResult.Succeeded)
            {
                foreach (IdentityError error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            IdentityResult roleResult = await _userManager.AddToRoleAsync(newUser, UserRoles.User.ToString());
            if (!roleResult.Succeeded)
            {
                foreach (IdentityError error in roleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login, string? ReturnUrl)
        {
            if (!ModelState.IsValid) return View(login);

            // Kullanıcının giriş bilgilerini kontrol et
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                ModelState.AddModelError("", "Email or Password is wrong!");
                return View(login);
            }

            // Kullanıcının giriş yaptığında hangi restorana ait olduğunu belirleyin
            Restorant restorant = _appDbContext.Restorant.FirstOrDefault(r => r.Email == login.Email);
            if (restorant == null)
            {
                // Eğer restoran bulunamazsa, hata mesajı gösterin
                ModelState.AddModelError("", "No matching restaurant found!");
                return View(login);
            }

            // Kullanıcının rolüne ve restoran ID'sine göre uygun admin paneline yönlendirin
            if (await _userManager.IsInRoleAsync(user, "Admin") && user.RestorantId == restorant.Id)
            {
                // Kullanıcının giriş yaptıktan sonra admin paneline yönlendirin
                return RedirectToAction("Index", "Product","Admin");
            }
            else
            {
                // Kullanıcının rolüne veya restoranına uygun bir hata mesajı gösterin
                ModelState.AddModelError("", "You are not authorized to access this admin panel!");
                return View(login);
            }
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> AddRoles()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }
        //    return Json("Ok");
        //}
        public IActionResult AccessDenied()
        {
            return View();
        }
        public enum UserRoles
        {
            Admin,
            User,
            Moderator
        }
    }
}
