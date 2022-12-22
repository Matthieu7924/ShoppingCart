using ShoppingCartModels;

namespace ShoppingCart.Repositories
{
    public interface IProduitRepository:IRepository<Produit>
    {

        void Update(Produit produit);
    }
}
