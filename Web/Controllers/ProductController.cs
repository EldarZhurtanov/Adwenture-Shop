using System.Web.Mvc;
using Web.Models;
using Web.ProductServiceReference;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductServiceClient productService = new ProductServiceClient();
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            int productsPerPage = 20;
            var products = productService.GetShortProducts((page - 1) * productsPerPage, productsPerPage);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = productsPerPage, TotalItems = productService.GetProductsCount() };

            ViewData["Products"] = products;
            ViewData["PageInfo"] = pageInfo;
            return View();

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = productService.GetDetailProduct(id);
            return View(product);
        }
        public FileResult Thumbnail(int id)
        {
            var photo = productService.GetPhotoThumbnail(id);

            return File(photo, "image/gif");
        }
        public FileResult Photo(int id)
        {
            var photo = productService.GetLargePhoto(id);

            return File(photo, "image/gif");
        }
    }
}
