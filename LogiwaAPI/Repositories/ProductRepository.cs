using LogiwaAPI.Context;
using LogiwaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogiwaAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }


        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {

            _context.Products.Remove(product);
            _context.SaveChanges();

        }

        public Product EditProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductTitle = product.ProductTitle;
                existingProduct.ProductQuantity = product.ProductQuantity;
                existingProduct.ProductDesc = product.ProductDesc;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Active = product.Active;
                _context.Products.Update(existingProduct);
                _context.SaveChanges();
            }

            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            var categories = _context.Categories.ToList();
            foreach (var item in products)
            {
                var cName = categories.FirstOrDefault(x => x.CategoryId == item.CategoryId).CategoryTitle;                
                item.CategoryName = cName;
                item.ActiveString = item.Active == 1 ? "Yes" : "No";
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            return product;

        }
    }
}
