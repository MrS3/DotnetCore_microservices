using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingCart.ShoppingCart;

namespace ShoppingCart.ProductCatalog
{
    public class ProductCatalogClient: IProductCatalogClient
    {
        private static string productCatalogBaseUrl = @"http://private-05cc8-chapter2productcataloguemicroservice.apiary-mock.com";
        private static string getProductPathTemplate = "/products?productIds=[{0}]";

        public Task<System.Collections.Generic.IEnumerable<ShoppingCartItem>> GetShoppingCartItems(int[] productCatalogueIds)
        {
            throw new System.NotImplementedException();
        }

        private static async Task<HttpResponseMessage> RequestProductFromProductCatalog(int[] productCatalogIds)
        {
            var productsResource = string.Format(getProductPathTemplate, string.Join(",", productCatalogIds));
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(productCatalogBaseUrl);
                return await httpClient.GetAsync(productsResource).ConfigureAwait(false);
            }
        }

        private static async Task<IEnumerable<ShoppingCartItem>> ConvertToShoppingCartItem(HttpResponseMessage response) 
        {
            response.EnsureSuccessStatusCode();
            var products = JsonConvert.DeserializeObject<List<ProductCatalogProduct>>( await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return products.Select(p => new ShoppingCartItem(
                int.Parse(p.ProductId),
                p.ProductName,
                p.ProductDescription,
                p.Price
            ));
        }

        private async Task<IEnumerable<ShoppingCartItem>> GetItemsFromCatalogue(int[] productCatalogueIds)
        {
            var response = await RequestProductFromProductCatalog(productCatalogueIds).ConfigureAwait(false);
            return await ConvertToShoppingCartItem(response).ConfigureAwait(false);
        }
    }
}
