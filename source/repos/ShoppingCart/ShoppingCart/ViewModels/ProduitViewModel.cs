using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartModels;

namespace ShoppingCart.ViewModels
{
	public class ProduitViewModel
	{
		public Produit Produit { get; set; } = new Produit();


		[ValidateNever]
		public IEnumerable<Produit> Produits { get; set; } = new List<Produit>();


		[ValidateNever]
		public IEnumerable<SelectListItem>? Categories { get; set; }



	}
}
