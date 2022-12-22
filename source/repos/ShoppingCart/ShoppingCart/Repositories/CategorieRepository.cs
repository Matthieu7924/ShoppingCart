using ShoppingCartDataAccess.Data;
using ShoppingCartModels;

namespace ShoppingCart.Repositories
{
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        private ApplicationDbContext _context;


        public CategorieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Categorie categorie)
        {
            var categorieDB = _context.Categories.FirstOrDefault(x => x.Id == categorie.Id);
            if(categorieDB== null )
            {
                categorieDB.Nom = categorie.Nom;
                categorie.DisplayOrder = categorie.DisplayOrder;
            }
        }
    }
}
