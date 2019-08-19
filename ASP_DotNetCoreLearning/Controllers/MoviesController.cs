using ASP_DotNetCoreLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP_DotNetCoreLearning.Models
{
    public class MoviesController : Controller
    {
        //GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customer = new List<Customer>
            {
                new Customer{ Name = "Customer 1" },
                new Customer{ Name = "Customer 2" },
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customer,
            };
            //return View(movie);
            //return Content("Hello World!");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            //ViewData["RandomMovie"] = movie;
            //ViewBag.RandomMovie = movie;
            var viewResult = new ViewResult();
            return View(viewModel);
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