using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Repositories;
using ShoppingCart.ViewModels;
using ShoppingCartModels;

namespace ShoppingCart.Controllers
{
	//[Area("Admin")]
	public class CategorieController : Controller
	{
		private IUnitOfWork _unitofWork;


		//constructeur
		public CategorieController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}


		//méthodes
		public IActionResult Index()
		{
			CategorieViewModel categorieVM = new CategorieViewModel();
			categorieVM.Kategories = _unitofWork.Categorie.GetAll();
			return View(categorieVM);
		}

		[HttpGet]
		public IActionResult CreateUpdate(int? id)
		{
			CategorieViewModel vm = new CategorieViewModel();
			if (id == null || id == 0)
			{
				return View(vm);
			}

			else
			{
				vm.Categorie = _unitofWork.Categorie.GetT(x => x.Id == id);
				if (vm.Categorie == null)
				{
					return NotFound();
				}
				else
				{
					return View(vm);
				}
			}
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateUpdate(CategorieViewModel vm)
		{
			if (ModelState.IsValid)
			{
				if (vm.Categorie.Id == 0)
				{
					_unitofWork.Categorie.Add(vm.Categorie);
					TempData["success"] = "Catégorie crée";
				}
				else
				{
					_unitofWork.Categorie.Update(vm.Categorie);
					TempData["success"] = "Catégorie mise à jour";
				}

				_unitofWork.Save();

				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categorie = _unitofWork.Categorie.GetT(x => x.Id == id);
			if (categorie == null)
			{
				return NotFound();
			}

			return View(categorie);

		}




		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteData(int? id)
		{
			ShoppingCartModels.Categorie categorie = _unitofWork.Categorie.GetT(x => x.Id == id);
			if (categorie == null)
			{
				return NotFound();
			}
			_unitofWork.Categorie.Delete(categorie);
			_unitofWork.Save();
			TempData["success"] = "Categorie supprimée";
			return RedirectToAction("Index");
		}


	}
}
