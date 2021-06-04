using Front.CartServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Front.Controllers
{
    public class CartController : Controller
    {
        private CartServiceClient productService = new CartServiceClient();

        public ActionResult Index()
        {
            var cart = productService.GetCart(Session.SessionID);
            return View(cart);
        }
        [HttpPost]
        public ActionResult Add(int productId, int quantity)
        {
            productService.AddCartItem(Session.SessionID, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ChangeQuantity(int productId, int quantity)
        {
            productService.ChangeCartItemQuantity(Session.SessionID, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete()
        {
            productService.Delete(Session.SessionID);
            return RedirectToAction("Index");
        }
    }
}
