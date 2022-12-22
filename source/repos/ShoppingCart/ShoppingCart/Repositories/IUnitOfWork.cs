namespace ShoppingCart.Repositories
{
    public interface IUnitOfWork
    {
        ICategorieRepository Categorie { get; }

        IProduitRepository Produit { get; }

        //ICartRepository Cart { get; }
        //IApplicationUser ApplicationUser { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        //IOrderDetailRepository OrderDetail { get; }

        void Save();
    }
}
