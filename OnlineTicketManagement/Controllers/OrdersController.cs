﻿using Microsoft.AspNetCore.Mvc;
using OnlineTicketManagement.Data.Cart;
using OnlineTicketManagement.Data.Servies;
using OnlineTicketManagement.Data.ViewModel;

namespace OnlineTicketManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieServices movieServices;
        private readonly ShoppingCart shoppingCart;
        public OrdersController(IMovieServices _movieServices, ShoppingCart _shoppingCart)
        {
            movieServices=_movieServices;
            shoppingCart = _shoppingCart;
        }
        public IActionResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}