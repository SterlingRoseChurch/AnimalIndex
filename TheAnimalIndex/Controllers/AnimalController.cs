using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheAnimalIndex.Models;
using Microsoft.EntityFrameworkCore;

namespace TheAnimalIndex.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalContext context { get; set; }

        public AnimalController(AnimalContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Types = context.Types.OrderBy(t => t.Name).ToList();
            return View("Edit", new Animals());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Types = context.Types.OrderBy(t => t.Name).ToList();
            var animals = context.Animalss.Find(id);
            return View(animals);
        }

        [HttpPost]
        public IActionResult Edit(Animals animals)
        {
            if (ModelState.IsValid)
            {
                if (animals.AnimalId == 0) 
                {
                    context.Animalss.Add(animals);
               
                }



                else
                    context.Animalss.Update(animals);
                context.SaveChanges();
           
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (animals.AnimalId == 0) ? "Add" : "Edit";
                ViewBag.Types = context.Types.OrderBy(t => t.Name).ToList();
                return View(animals);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var animals = context.Animalss.Find(id);
            return View(animals);
        }

        [HttpPost]
        public IActionResult Delete(Animals animals)
        {
            context.Animalss.Remove(animals);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
