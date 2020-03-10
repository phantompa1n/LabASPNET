using GameAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GameAPP.Controllers
{
    public class HomeController : Controller
    {
        DbFifteenContext db = new DbFifteenContext();

        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Login = User.Identity.Name;
                return RedirectToAction("Menu", "Home");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChooseDifficult()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Field(int size)
        {
            ViewBag.size = size;
            return View(ViewBag);
        }

        [HttpPost]
        [Authorize]
        public void Field(string record,string size)
        {
                int idPlayer = db.Players.FirstOrDefault(p => p.Login == User.Identity.Name).Id;
                if (Convert.ToInt32(record) != 0)
                {
                    db.Records.Add(new Record { Player_Id = idPlayer, Size_field = Convert.ToInt32(size), Step_count = Convert.ToInt32(record) });
                    db.SaveChanges();
                }
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
            int[] pole = new int[size * size];
            pole[0] = 1;
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

        [HttpPost]
        public ActionResult GetRecord(int action)
        {
            var players = db.Players;
            var records = db.Records;
            ViewBag.size = action;
            string[] allRecords = getRecords(action,ref players, ref records);
            if (allRecords == null)
                return View("");
            else
                return View(allRecords.ToList());
        }

        string[] getRecords(int size,ref DbSet<Player> Players, ref DbSet<Record> Records)
        {
            string records = null;
            foreach (var k in Records)
            {
                if (k.Size_field == size)
                {
                    IEnumerable<dynamic> players = Players;
                    records += players.FirstOrDefault(p => p.Id == k.Player_Id).Login + "   " + k.Step_count + "\n";
                }
            }
            if (records == null)
                return null;
            string[] allRecords = records.Split('\n');
            return allRecords;
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
        [Authorize]
        public ActionResult Menu()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Login = User.Identity.Name;
            }
            return View();
        }
    }
}