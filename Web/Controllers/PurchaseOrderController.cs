using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.PurchaseOrderServiceReference;

namespace Web.Controllers
{
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        private IAuthenticationManager authenticationManager => HttpContext.GetOwinContext().Authentication;
        private readonly PurchaseOrderServiceClient purchaseOrder = new PurchaseOrderServiceClient();
        public ActionResult Index()
        {
            var purchaseOrderHeadersDTOs = purchaseOrder.GetPurchaseOrderHeadersDTO(new PurchaseOrderFilterDTO()
            {
                UserID = authenticationManager.User.Identity.GetUserId(),
                UserRole = Roles.GetRolesForUser().First(),
                Skip = 0,
                Take = 10
            });
            return View(purchaseOrderHeadersDTOs);
        }

        public ActionResult Details(Guid id)
        {
            return View(purchaseOrder.GetPurchaseOrderDetailDTO(id));
        }

        [HttpPost]
        public ActionResult Create()
        {
            purchaseOrder.Create(Session.SessionID, authenticationManager.User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Ship()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Close()
        {
            return View();
        }
    }
}
