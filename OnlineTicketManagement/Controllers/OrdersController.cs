using Microsoft.AspNetCore.Mvc;
using OnlineTicketManagement.Data.Cart;
using OnlineTicketManagement.Data.Servies;
using OnlineTicketManagement.Data.ViewModel;

namespace OnlineTicketManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieServices movieServices;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderServices orderServices;
        public OrdersController(IMovieServices _movieServices, ShoppingCart _shoppingCart, IOrderServices _orderServices)
        {
            movieServices = _movieServices;
            shoppingCart = _shoppingCart;
            orderServices = _orderServices;
        }
        public IActionResult ListOrder()
        {
            int userId = 0;
            var orders = orderServices.GetOrdersByUserId(userId);
            return View(orders);
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
        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var item = movieServices.GetMovieById(id);
            if(item!= null)
            {
                shoppingCart.AddItemtoCart(item);

            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveItemToShoppingCart(int id)
        {
            var item = movieServices.GetMovieById(id);
            if (item != null)
            {
                shoppingCart.RemoveItemtoCart(item);

            }
            return RedirectToAction("Index");
        }
        public IActionResult CompleteOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();
            int userId=0;
            string userEmail = "";
            orderServices.StoreOrder(items, userId, userEmail);
            shoppingCart.ClearShoppingCart();
            return View("OrdersCompleted");
        }
    }
}
