using HtmlAgilityPack;
using Parser.src.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Parser.Controllers
{
    public class ParserController : Controller
    {
        // GET: Parser
        public ActionResult Index()
        {
            return Content("Parser");
        }

        public async Task<ActionResult> Parse(string url)
        {
            try
            {
                ScraperFacade s = new ScraperFacade(url);
                Item _item = await s.ParseItemToDB();

                return Json(new { error = false, item = _item});
            }
            catch (Exception e)
            {
                return Json(new { error = "true", errorMessage = e.Message });
            }

        }
    }
}