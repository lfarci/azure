using Shop.Models;

namespace Shop.Services
{
    public class ProductsService
    {
        private readonly IList<Product> _products;

        public ProductsService()
        {
            _products = new List<Product>();

            Add(new Product { Name = "Milk", Amount = 15, Price = 2 });
            Add(new Product { Name = "Bread", Amount = 23, Price = 1 });
            Add(new Product { Name = "Butter", Amount = 10, Price = 3 });
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public void Clear()
        {
            _products.Clear();
        }
    }
}
