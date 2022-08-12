using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicketManagement.Data.Cart
{
    public class ShoppingCart
    {
        public TicketDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItems> ShoppingCartItems { get; set; }
        public ShoppingCart(TicketDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<TicketDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemtoCart(Movies Movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n=>n.Movies.Id == Movie.Id && n.ShoppingCartId==ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItems()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movies = Movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemtoCart(Movies Movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movies.Id == Movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }
        public List<ShoppingCartItems> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n=>n.ShoppingCartId== ShoppingCartId).Include(n=>n.Movies).ToList());
        }
        public double GetShoppingCartTotal()
        {
           var items  = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movies.Price * n.Amount).Sum();
            return items;

        }
        
        
    }
}
