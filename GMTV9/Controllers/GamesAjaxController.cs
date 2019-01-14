using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GMTV9.Models;

namespace GMTV9.Controllers
{
    public class GamesAjaxController : Controller
    {
        private GMTVContext db = new GMTVContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGameList()
        {
            var AllGames = db.Game.ToList();
            //var Games = new Dictionary<string, object>();
            //var json = new JavaScriptSerializer().Serialize(AllGames);

            return Json(AllGames);//, JsonRequestBehavior.AllowGet);
            //var test = new List<string>();
            //test.Add("1rd");
            //test.Add("2st");
            //test.Add("3st");
            //test.Add("4rd");
            //return Json(test);
        }
        /* Return game detail */
        [HttpPost]
        public ActionResult GetGame(int? id)
        {
            Game game = db.Game.Find(id);
            return View(game);
        }

        public struct myStruct
        {
            public string type { get; set; }
            public int model { get; set; }
            public string color { get; set; }
        }

        [HttpPost]
        public ActionResult testSendFromClient(int carIdtype, List<myStruct> details)
        {
            //I was merely testing data being sent to server... however need to do this function so it
            //gives some kind of success return?
            return View();
        }

        [HttpPost]
        public ActionResult GetTestList()
        {
            var test = new List<string>();
            test.Add("1rd");
            test.Add("2st");
            test.Add("3st");
            test.Add("4rd");
            return Json(test);
        }

    }
}