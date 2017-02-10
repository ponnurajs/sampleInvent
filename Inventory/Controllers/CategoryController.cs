using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var lstCategories = new List<Category>();
            lstCategories.Add(new Category { Id = 1, Code = "CSMT", Name = "Cosmetic", Description = "Soap item" });
            lstCategories.Add(new Category { Id = 2, Code = "MED", Name = "Medicine", Description = "Medical item" });

            ViewBag.isButtonClick = true;

            return View(lstCategories);
        }
    }
}