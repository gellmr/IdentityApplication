using System.Linq;
using System.Web.Mvc;
using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using gellmvc.Models;
using System.Collections.Generic;

namespace gellmvc.Controllers
{
  public class StoreController : Controller
  {
    private IProductRepository repository;
    public int PageSize = 5;

    public StoreController(IProductRepository productRepository)
    {
      this.repository = productRepository;
    }

    private StoreListViewModel GetPageOfProducts(Cart cart, int page = 1, string searchString = "")
    {
      searchString = searchString.ToLower();

      IEnumerable<Product> pageOfProducts;
      List<ProductLine> productLines = new List<ProductLine>();

      // Get the requested page of products from the repository.
      // If we have a searchstring then use it, and also pagination.
      // Otherwise just use pagination.

      pageOfProducts = repository.Products
        .Where(p => (searchString.Length > 0) ? (p.Name.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString)) : true)
        .OrderBy(p => p.Id)
        .Skip((page - 1) * PageSize)
        .Take(PageSize);

      // pageOfProducts now contains the requested page of products.
      // We will not display pageOfProducts, but we will use it to build a list of product lines, and display that.
      // productLines tells us how many of each item are in the user's cart.

      foreach (Product product in pageOfProducts)
      {
        int qty = cart.GetQuantity(product);
        productLines.Add(new ProductLine
        {
          Product = product,
          QtyInCart = qty,
          Subtotal = qty * product.UnitPrice
        });
      }

      // Construct the view model
      StoreListViewModel viewModel = new StoreListViewModel
      {
        ProductLines = productLines,
        Pager = new Pager(repository.Products.Count(), page, PageSize),
        Cart = cart,
        SearchString = searchString
      };

      return viewModel;
    }

    // GET: /Store/Search
    public ViewResult Search(Cart cart, int page = 1, string searchString = "")
    {
      StoreListViewModel model = GetPageOfProducts(cart, page, searchString);
      return View("Index", model);
    }
  }
}