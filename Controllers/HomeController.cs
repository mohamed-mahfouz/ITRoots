using ITRoots.Models;
using ITRoots.Repositories;
using ITRoots.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITRoots.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
       

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
           
        }
        public ActionResult Index()
        {
           if((string)Session["UserRole"] == "User" || (string)Session["UserRole"] == "Admin")
                    return View();
           
            
            return RedirectToAction("Login", "Account");
          
        }

        public ActionResult GetUsers()
        {
            var users = _dbContext.Users.ToList();

            return Json(new { data =  users }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            if ((string)Session["UserRole"] == "Admin")
            {
                var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }

            return RedirectToAction("UnAuthorized");
        }

        [HttpPost]
        public ActionResult Save(User model)
        {
           
                bool status = false;
                var user = _dbContext.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Password = model.Password;
                    user.UserName = model.UserName;
                }

                else
                {
                    _dbContext.Users.Add(user);
                }
                _dbContext.SaveChanges();
                status = true;

                return new JsonResult { Data = new { status = status } };                   
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if ((string)Session["UserRole"] == "Admin")
            {
                var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();

                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }
            }

           return RedirectToAction("UnAuthorized");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUser(Guid id)
        {
            
            bool status = false;
            var user = _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

    }
}