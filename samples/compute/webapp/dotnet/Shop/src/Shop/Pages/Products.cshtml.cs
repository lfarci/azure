using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Models;
using Shop.Services;

namespace Shop.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductsService _productsService;

        public ProductsModel(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [BindProperty]
        public Product? Product { get; set; }

        public IEnumerable<Product> Products => _productsService.GetAll();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Product is not null)
                {
                    _productsService.Add(Product);
                }

                Product = null;
                ModelState.Clear();
            }
        }
    }
}
