﻿using Bookstore.Data;
using Bookstore.Models;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore.Controllers
{
    public class CartController : Controller
    {
        private readonly BookstoreContext _context;
        private readonly Cart _cart;

        public CartController(BookstoreContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;

            return View(_cart);
        }

        public IActionResult AddToCart(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.AddToCart(selectedBook, 1);
            }

            return RedirectToAction("Index", "Store");
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

    }
}