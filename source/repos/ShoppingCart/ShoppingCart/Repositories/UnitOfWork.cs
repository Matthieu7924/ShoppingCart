using ShoppingCartDataAccess.Data;

namespace ShoppingCart.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;

        public ICategorieRepository Categorie { get; private set; }

        public IProduitRepository Produit { get; private set; }

        //public ICartRepository Cart { get; private set }
        //public IApplicationUser ApplicationUser { get; private set }
        //public IOrder Cart { get; private set }
        //public ICartRepository Cart { get; private set }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categorie = new CategorieRepository(context);
            Produit = new ProduitRepository(context);
            //Cart= new CartRepository(context);
            //AppplicationUser = new ApplicationRepository(context);
            //OrderDetail = new OrderDetailRepository(context);
            //OrderHeader = new OrderHeaderRepository(context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
