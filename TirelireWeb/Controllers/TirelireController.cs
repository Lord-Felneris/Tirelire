using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tirelire.Data.Data.Repository;
using Tirelire.Models;
using Tirelire.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Tirelire.Utility;

namespace TirelireWeb.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class TirelireController : Controller
    {
        //retreive a data from database -> get data throw constructor
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public INotyfService _notifyService { get; }
        public TirelireController(IUnitOfWork unitOfWork, INotyfService notifyService, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _notifyService = notifyService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //get a list od Tirelire
            List<Produit> objTirelireList = _unitOfWork.Tirelire.GetAll(includeProps:"Fabricant").ToList();
            //to pass a data to a view
            return View(objTirelireList);
        }

        //add a new action method called upsert 
        public IActionResult Upsert(int? id)
        {
            //ViewBag.FabricantList = FabricantList;
            Produit? tirelireFromDb1 = _unitOfWork.Tirelire.Get(u => u.Id == id);
            TirelireVM tirelireVM = new()
            {
                FabricantList = _unitOfWork.Fabricant.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Tirelire = new Produit()
            };
            // create if id is not set
            if(id == null || id == 0)
            {
                return View(tirelireVM);
            }
            else
            {
                //edit or update
                tirelireVM.Tirelire = _unitOfWork.Tirelire.Get(u => u.Id == id);
                return View(tirelireVM);
            }
        }

        //add a new action method called upsert with parameter to get submit data
        [HttpPost]
        public IActionResult Upsert(TirelireVM obj, IFormFile? file,int? id)
        {
            //check if model "Tirelire" is valid with all requirement
            if (id.HasValue)
                obj.Tirelire.Id = id.Value;

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\produit");

                    //copy a file to a location
                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Tirelire.ImageUrl = @"\images\produit\"+filename;
                }
                if (obj.Tirelire.Id == 0)
                {
                    _unitOfWork.Tirelire.Add(obj.Tirelire);
                    //saves a changes in database
                    _unitOfWork.Save();
                    _notifyService.Success("Tirelire crée avec succes!");
                }
                else
                {
                    _unitOfWork.Tirelire.Update(obj.Tirelire);
                    _unitOfWork.Save();
                    _notifyService.Success("Tirelire modifiée avec succes!");
                }

                //return to index view and reload data
                return RedirectToAction("Index");
            }
            return View();
        }

        //add a new action method called Delete : get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Tirelire? TirelireFromDb = _db.Tirelires.Find(id);
            Produit? TirelireFromDb1 = _unitOfWork.Tirelire.Get(u => u.Id == id);
            if (TirelireFromDb1 == null)
            {
                return NotFound();
            }
            return View(TirelireFromDb1);
        }

        //add a new action method called Delete with parameter to get submit data
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Produit? obj = _unitOfWork.Tirelire.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Tirelire.Remove(obj);
            _unitOfWork.Save();
            _notifyService.Success("Tirelire supprimé avec succes!");
            return RedirectToAction("Index");
        }
    }
}
