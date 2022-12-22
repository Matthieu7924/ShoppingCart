using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Repositories;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
	public class ProduitController : Controller
	{


		private IUnitOfWork _unitofWork;
		private IWebHostEnvironment _hostingEnvironment;

		public ProduitController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
		{
			_unitofWork = unitOfWork;
			_hostingEnvironment = hostingEnvironment;
		}


		public IActionResult AllProducts()
		{
			var produits = _unitofWork.Produit.GetAll(includeProperties: "Categorie");
			return Json(new { data = produits });
		}


		public IActionResult Index()
		{
			ProduitViewModel produitVM = new ProduitViewModel();
			produitVM.Produits = _unitofWork.Produit.GetAll();
			return View(produitVM);
			//return View();
		}


		[HttpGet]
		public IActionResult CreateUpdate(int? id)
		{
			ProduitViewModel vm = new ProduitViewModel()
			{
				Produit = new(),
				Categories = _unitofWork.Categorie.GetAll()
				.Select(x => new SelectListItem()
				{
					Text = x.Nom,
					Value = x.Id.ToString()
				})
			};
			if (id == null || id == 0)
			{
				return View(vm);
			}
			else
			{
				vm.Produit = _unitofWork.Produit.GetT(x => x.Id == id);
				if (vm.Produit == null)
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
		public IActionResult CreateUpdate(ProduitViewModel vm, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string fileName = String.Empty;
				if (file != null)
				{
					string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "ProduitImage");
					fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
					string filePath = Path.Combine(uploadDir, fileName);

					if (vm.Produit.ImageUrl != null)
					{
						var oldimagePath = Path.Combine(_hostingEnvironment.WebRootPath,
							vm.Produit.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldimagePath))
						{
							System.IO.File.Delete(oldimagePath);
						}
					}
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					vm.Produit.ImageUrl = @"\ProduitImage _" + fileName;
				}
				if (vm.Produit.Id == 0)
				{
					_unitofWork.Produit.Add(vm.Produit);
					TempData["success"] = "Produit crée";
				}
				else
				{
					_unitofWork.Produit.Update(vm.Produit);
					TempData["success"] = "Produit mis à jour";
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
			var produit = _unitofWork.Produit.GetT(x => x.Id == id);
			if (produit == null)
			{
				return NotFound();
			}

			return View(produit);

		}




		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteData(int? id)
		{
			ShoppingCartModels.Produit produit = _unitofWork.Produit.GetT(x => x.Id == id);
			if (produit == null)
			{
				return NotFound();
			}
			_unitofWork.Produit.Delete(produit);
			_unitofWork.Save();
			TempData["success"] = "Produit supprimé";
			return RedirectToAction("Index");
		}






	}





}

