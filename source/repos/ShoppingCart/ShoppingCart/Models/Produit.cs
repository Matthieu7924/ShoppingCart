using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartModels
{
    public class Produit
    {

        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        [ValidateNever]
        [Required]
        public double Prix { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        public int CategorieId { get; set; }

        [ValidateNever]
        public Categorie Categorie { get; set; }
    }
}
