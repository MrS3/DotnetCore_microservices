namespace ShoppingCart.ShoppingCart
{
    public class ShoppingCartItem
    {
        public int ProductCatalogueId { get; }
        public string ProductName { get; }
        public string Desscription { get; }
        public Money Price { get; }

        public ShoppingCartItem(int productCatalogueId, string productName, string description, Money price)
        {
            this.ProductCatalogueId = productCatalogueId;
            this.ProductName = productName;
            this.Desscription = description;
            this.Price = price;
        }
    }
}