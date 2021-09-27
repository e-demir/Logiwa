using LogiwaAPI.Models;
using System.Collections.Generic;

namespace LogiwaAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProduct(int id);

        Product AddProduct(Product product);

        void DeleteProduct(Product product);

        Product EditProduct(Product product);
    }
}
