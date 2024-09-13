using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Tirelire.Data.Data.Repository;
using Tirelire.Models;

namespace TirelireWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public INotyfService _notifyService { get; }
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, INotyfService notifyService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            IEnumerable<Produit> tirelireList = _unitOfWork.Tirelire.GetAll(includeProps:"Fabricant");
            return View(tirelireList);
        }


        public IActionResult Detail(int tirelireId)
        {
            ShoppingCart shoppingCart = new()
            {
                Produit = _unitOfWork.Tirelire.Get(u => u.Id == tirelireId, includeProps:"Fabricant"),
                Count = 1,
                ProduitId = tirelireId
            };
            
            IEnumerable<Produit> tirelireWithSameColor = _unitOfWork.Tirelire.GetAll(u => u.Couleur == shoppingCart.Produit.Couleur,
                includeProps: "Fabricant").Take(4);
            ViewBag.tirelireWithSameColor = tirelireWithSameColor;
            return View(shoppingCart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Detail(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            //get userId
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.AppUserId = userId;

            //check if cart already exist
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u =>u.AppUserId == userId && u.ProduitId == shoppingCart.ProduitId);
            if(cartFromDb!= null)
            {
                //shoppingCart exist
                cartFromDb.Count += shoppingCart.Count;
                //update cartFromDb
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _notifyService.Success("ShoppingCart updated !");
            }
            else
            {
                //add a new shopping cart in database
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _notifyService.Success("New shoppingCart added !");
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
