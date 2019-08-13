using ASP_DotNetCoreLearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DotNetCoreLearning.Controllers
{
    [Route("/products")]  
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return Content("Products Index");
        }

        [Route("{id}")]
        [Route("/product/{id}")]
        public IActionResult Details(int id)
        {
            return Content("Product #" + id);
        }
        [Route("blog/{entryId:int}/{slug}")]
        public IActionResult Blog(int entryId, string slug)
        {
            return Content($"Blog entry with ID #{entryId} requested (URL Slug: {slug})");
        }
    }
}