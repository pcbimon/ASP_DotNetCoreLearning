using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DotNetCoreLearning.Models
{
    public class MoviesController : Controller
    {
        //GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name="Shrek!" };

            return View(movie);
        }
    }
}