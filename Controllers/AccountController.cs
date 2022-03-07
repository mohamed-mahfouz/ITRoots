using ITRoots.Models;
using ITRoots.Repositories;
using ITRoots.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ITRoots.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly ApplicationDbContext _dbContext;
        public AccountController()
        {
            _userRepository = new UserRepository();
            _dbContext = new ApplicationDbContext();
        }
        // GET: Account
        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.AddUser(registerViewModel);
                string message = string.Empty;
                message = "Registration successful, Please verify your email";
                SendActivationEmail(user);
                ViewBag.Message = message;

                return View("Activation");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {

            var user = _dbContext.Users.Where(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password).FirstOrDefault();

            if (user != null)
            {
                if (user.IsActivated)
                {

                    var userRoleId = _dbContext.UserRoles.First(u => u.UserId == user.Id).RoleId;
                    var userRoleName = _dbContext.Roles.First(r => r.Id == userRoleId).RoleName;
                    Session["UserName"] = user.UserName;
                    Session["UserId"] = user.Id;
                    Session["UserRole"] = userRoleName;
                }

                else
                {
                    ViewBag.Message = "please check your mail to activate account!";
                    return View("Activation");
                }
            }

            else if(user == null)
            {
                ModelState.AddModelError("", "Invalid username or password!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            Session["UserRole"] = string.Empty;

            return RedirectToAction("Login", "Account");
        }


        public ActionResult Activation()
        {
            ViewBag.Message = "Invalid Activation code.";
            if (RouteData.Values["id"] != null)
            {
                var activationCode = new Guid(RouteData.Values["id"].ToString());
                var userId = _dbContext.UsersActivation.Where(p => p.ActivationCode == activationCode).FirstOrDefault().UserId;
                var userActivation = _dbContext.UsersActivation.Where(p => p.ActivationCode == activationCode).FirstOrDefault();
                if (userActivation != null)
                {
                    var user = _dbContext.Users.Single(u => u.Id == userId);
                    user.IsActivated = true;
                    _dbContext.UsersActivation.Remove(userActivation);  
                    _dbContext.Users.Attach(user);
                    _dbContext.Entry(user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        private void SendActivationEmail(User user)
        {
            var activationCode = Guid.NewGuid();
            _dbContext.UsersActivation.Add(new UserActivation
            {
                UserId = user.Id,
                ActivationCode = activationCode
            });
            _dbContext.SaveChanges();

            using (MailMessage mm = new MailMessage("itrootdemo@gmail.com", user.Email))
            {

                mm.Subject = "Account Activation";
                string body = "Hello " + user.UserName + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("{0}://{1}/Account/Activation/{2}", Request.Url.Scheme, Request.Url.Authority, activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("itrootdemo@gmail.com", "Medo@123");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
