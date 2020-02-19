using GameAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GameAPP.Controllers
{
    public class HomeController : Controller
    {
        GameContext db = new GameContext();

        [HttpGet]
        public ActionResult Index()
        {
            var players = db.Players;
            ViewBag.Players = players;
            return View();
        }

        [HttpGet]
        public ActionResult Auth()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Auth(string Login, string Password)
        {
            if (Login == "vasya")
                return View("Menu");
            else
                return null;
        }

        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChooseDifficult()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Field(int size)
        {
            ViewBag.size = size;
            return View(ViewBag);
        }


        public static int getRandomPictures(int size)
        {
            //Thread.Sleep(100);
            int time = Convert.ToInt32(DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString());
            Random rnd = new Random(time);
            return rnd.Next(2, size * size);
        }
        public static int getRandomCars()
        {
            Random rnd = new Random();
            return rnd.Next(1, 5); 
        }

        protected void cellClick(object sender, EventArgs e)
        {
            e.ToString();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            return View();
        }

    }
}