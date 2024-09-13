using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tirelire.Data.Data.Repository;
using Tirelire.Models;
using Tirelire.Utility;

namespace TirelireWeb.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class FabricantController : Controller
    {
        //retreive a data from database -> get data throw constructor
        private readonly IUnitOfWork _unitOfWork;
        public INotyfService _notifyService { get; }
        public FabricantController(IUnitOfWork unitOfWork, INotyfService notifyService)
        {
            _unitOfWork = unitOfWork;
            _notifyService = notifyService;
        }
        public IActionResult Index()
        {
            //get a list od fabricant
            List<Fabricant> objFabricantList = _unitOfWork.Fabricant.GetAll().ToList();
            //to pass a data to a view
            return View(objFabricantList);
        }

        //add a new action method called create 
        public IActionResult Create()
        {
            return View();
        }

        //add a new action method called create with parameter to get submit data
        [HttpPost]
        public IActionResult Create(Fabricant obj)
        {
            if (obj.Description?.Length > 200)
            {
                ModelState.AddModelError("description", "la description ne doit pas dépasser 200 charactères!");
            }
            //check if model "fabricant" is valid with all requirement
            if (ModelState.IsValid)
            {
                //add a new fabricant
                _unitOfWork.Fabricant.Add(obj);
                //saves a changes in database
                _unitOfWork.Save();
                _notifyService.Success("Fabricant crée avec succes!");
                //return to index view and reload data
                return RedirectToAction("Index");
            }
            return View();
        }

        //add a new action method called Edit : get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Fabricant? fabricantFromDb = _db.Fabricants.Find(id);
            Fabricant? fabricantFromDb1 = _unitOfWork.Fabricant.Get(u => u.Id == id);
            if (fabricantFromDb1 == null)
            {
                return NotFound();
            }
            return View(fabricantFromDb1);
        }

        //add a new action method called Edit with parameter to get submit data
        [HttpPost]
        public IActionResult Edit(Fabricant obj)
        {
            if (obj.Description?.Length > 200)
            {
                ModelState.AddModelError("description", "la description ne doit pas dépasser 200 charactères!");
            }
            //check if model "fabricant" is valid with all requirement
            if (ModelState.IsValid)
            {
                //add a new fabricant
                _unitOfWork.Fabricant.Update(obj);
                //saves a changes in database
                _unitOfWork.Save();
                _notifyService.Success("Fabricant modifié avec succes!");
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
            //Fabricant? fabricantFromDb = _db.Fabricants.Find(id);
            Fabricant? fabricantFromDb1 = _unitOfWork.Fabricant.Get(u => u.Id == id);
            if (fabricantFromDb1 == null)
            {
                return NotFound();
            }
            return View(fabricantFromDb1);
        }

        //add a new action method called Delete with parameter to get submit data
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Fabricant? obj = _unitOfWork.Fabricant.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Fabricant.Remove(obj);
            _unitOfWork.Save();
            _notifyService.Success("Fabricant supprimé avec succes!");
            return RedirectToAction("Index");
        }
    }
}
