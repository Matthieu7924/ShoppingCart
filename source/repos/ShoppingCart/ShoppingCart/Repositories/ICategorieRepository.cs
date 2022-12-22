using ShoppingCartModels;

namespace ShoppingCart.Repositories
{
    public interface ICategorieRepository:IRepository<Categorie>
    {

        void Update(Categorie categorie);
    }
}
