using GameAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GameAPP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Login = User.Identity.Name;
                return RedirectToAction("Menu", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Player player = null;
                using (DbFifteenContext db = new DbFifteenContext())
                {
                    player = db.Players.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                }
                if (player != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    ViewBag.message = "Пользователя с таким логином и паролем нет";
                    ViewBag.ThisLogin = Convert.ToString(model.Login);
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Login = User.Identity.Name;
                return RedirectToAction("Menu", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Password != model.Password2)
                {
                    ViewBag.message = "Пароли не совпадают!";
                    ModelState.AddModelError("", "Пароли не совпадают!");
                    return View(model);
                }
                Player player = null;
                using (DbFifteenContext db = new DbFifteenContext())
                {
                    player = db.Players.FirstOrDefault(u => u.Login == model.Login);
                }
                if (player == null)
                {
                    // создаем нового пользователя
                    using (DbFifteenContext db = new DbFifteenContext())
                    {
                        db.Players.Add(new Player { Login = model.Login, Password = model.Password });
                        db.SaveChanges();

                        player = db.Players.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (player != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        ViewBag.Login = model.Login;
                        return RedirectToAction("Menu", "Home");
                    }
                }
                else
                {
                    ViewBag.message = "Вы уже зарегестрированы!";
                    ViewBag.ThisLogin = Convert.ToString(model.Login);
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}