using Microsoft.AspNetCore.Mvc;

namespace ASP_DotNetCoreLearning.Models
{
    public class MoviesController : Controller
    {
        //GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //return View(movie);
            //return Content("Hello World!");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            ViewData["RandomMovie"] = movie;
            ViewBag.RandomMovie = movie;
            return View();
        }
        public IActionResult Edit(int movieId)
        {
            return Content("id=" + movieId);
        }
        //movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }
            return Content(string.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }
        //Custom Route url
        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}