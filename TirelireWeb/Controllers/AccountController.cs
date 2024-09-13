using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tirelire.Models;
using Tirelire.Models.ViewModel;
using Tirelire.Utility;

namespace TirelireWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid) { 
                //login
                var result = await signInManager.PasswordSignInAsync(loginVM.Email!,loginVM.Password!,loginVM.RememberMe,false);
                //if succeed go to home => index
                if (result.Succeeded) { 
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt !");
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Register()
        {
            if (!roleManager.RoleExistsAsync(SD.Role_Client).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(SD.Role_Client)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(SD.Role_Assistant)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(SD.Role_Moderateur)).GetAwaiter().GetResult();

            }
            RegisterVM registerVM = new RegisterVM();
            registerVM.RoleList = roleManager.Roles.Select(u=>u.Name).Select(i=> new SelectListItem { Text = i , Value = i});
            return View(registerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                //register
                AppUser user = new()
                {
                    Email = registerVM.Email,
                    Name = registerVM.Name,
                    UserName = registerVM.Email
                };
                var result = await userManager.CreateAsync(user,registerVM.Password!);
                if (result.Succeeded) {
                    //add a role to a user
                    if (!string.IsNullOrEmpty(registerVM.Role))
                    {
                        await userManager.AddToRoleAsync(user, registerVM.Role);
                    }
                    else { 
                        await userManager.AddToRoleAsync(user,SD.Role_Client);
                    }
                    await signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) { 
                    ModelState.AddModelError("",error.Description);
                }

            }
            return View(registerVM);
        }

        public async Task<IActionResult> Logout()
        { 
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
