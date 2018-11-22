using Parser.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parser.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            List<Item> items = ItemsDB.GetAllItems();

            return View(items);
        }

        public ActionResult Item(int id)
        {
            Item item = ItemsDB.GetItemById(id);

            return View(item);
        }
    }
}