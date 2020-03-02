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

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Record()
        {
            return View();
        }


        public static int[] getRandomPictures(int size)
        {
            //Thread.Sleep(100);
            int[] pole = new int[size * size];
            pole[0] = 1;
            //int time = Convert.ToInt32(DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString());
            Random rnd = new Random();//(time);
            for (int i = 1; i < size * size; i++)
            {
                int th = rnd.Next(2, size * size + 1);
                if (NumberOnPole(pole, th))
                {
                    i--;
                    continue;
                }
                pole[i] = th;
            }
            return pole;
        }

        static bool NumberOnPole(int[] pole, int th)
        {
            foreach (int p in pole)
            {
                if (p == th)
                    return true;
            }
            return false;
        }
        public static bool WinPole(int[] pole)
        {
            int count = 0;
            for (int i = 0; i < pole.Length; i++)
            {
                for (int j = i; j < pole.Length; j++)
                {
                    if (pole[j] < pole[i])
                        count++;                   
                }
            }
            if (count % 2 == 0)
                return true;
            return false;
        }
        public static int getRandomCars()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6); 
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