using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;

        public CartController(Cart cart)
        {
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
