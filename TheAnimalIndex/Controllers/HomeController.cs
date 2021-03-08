using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheAnimalIndex.Models;
using Microsoft.EntityFrameworkCore;


namespace TheAnimalIndex.Controllers
{
    public class HomeController : Controller
    {
        private AnimalContext context { get; set; }

        public HomeController(AnimalContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var animals = context.Animalss.Include(t => t.Type).ToList();
            return View(animals);
        }

        
    }
}
