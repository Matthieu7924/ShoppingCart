using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoppingCartModels;

namespace ShoppingCart.ViewModels
{
    public class CategorieViewModel
    {
        public Categorie Categorie { get; set; } = new Categorie();

		//[ValidatNever]
		public IEnumerable<Categorie> Kategories { get; set; } = new List<Categorie>();



    }
}
