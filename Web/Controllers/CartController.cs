﻿using System.Web.Mvc;
using Web.CartServiceReference;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private CartServiceClient cartService = new CartServiceClient();

        public ActionResult Index()
        {
            var cart = cartService.GetCart(Session.SessionID);
            return View(cart);
        }
        [HttpPost]
        public ActionResult Add(int productId, int quantity)
        {
            cartService.AddCartItem(Session.SessionID, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ChangeQuantity(int productId, int quantity)
        {
            cartService.ChangeCartItemQuantity(Session.SessionID, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete()
        {
            cartService.Delete(Session.SessionID);
            return RedirectToAction("Index");
        }
        public string GetCartId()
        {
            return Session.SessionID;
        }
    }
}
