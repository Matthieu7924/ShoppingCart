using ShoppingCartDataAccess.Data;
using ShoppingCartModels;

namespace ShoppingCart.Repositories
{
    public class ProduitRepository :Repository<Produit>, IProduitRepository
    {
        private ApplicationDbContext _context;

        public ProduitRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(Produit produit)
        {
            var produitDb = _context.Produits.FirstOrDefault(x => x.Id == produit.Id);
            if(produitDb != null)
            {
                produitDb.Nom = produit.Nom;
                produitDb.Description = produit.Description;
                produitDb.Prix = produit.Prix;
                if(produit.ImageUrl !=null)
                {
                    produitDb.ImageUrl = produit.ImageUrl;
                }
            }


        }
    }
   
}
