using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class RegisterUserController : Controller
    {

        private ApplicationDbContext _context;

        public RegisterUserController ()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: RegisterUser
        public ActionResult Index()
        {
            var getUsers = _context.RegisterUsers.ToList();
            return View(getUsers);
        }

        //GET: //Register
        public ActionResult Register ()
        {
            //View should be of type Create to add new users to db
            //Adding a list of roles for users to choose from in the 
            //Dropdown list.

            ViewBag.Name = new SelectList(_context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View();
        }

        //POST: /Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register (RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                _context.RegisterUsers.Add(registerUser);
                _context.SaveChanges();
            }

            //ModelState.Clear();
            ViewBag.Message = registerUser.FirstName + " " + registerUser.LastName + "was successfully logged in";
            return View();
        }

        //GET: //LoggedIn
        public ActionResult Login ()
        {
            //View should be of type empty to customize to user when logged in
            return View();
        }

        //POST: //LoggedIn
        [HttpPost]
        public ActionResult Login (RegisterUser registerUser)
        {
           var usr = _context.RegisterUsers.FirstOrDefault(m => m.Email == registerUser.Email && m.Password == registerUser.Password);

           if (usr != null)
           {
             Session["UserId"] = usr.UserId.ToString();
             Session["Email"] = usr.Email.ToString();
             Session["FirstName"] = usr.FirstName.ToString();
                Session["DataScore"] = usr.DataScore.ToString();

             return RedirectToAction("LoggedIn");
            }

            
            else
            {
                ModelState.AddModelError("", "Email or password is wrong.");

            }
            return View(registerUser);
        }

        public ActionResult LoggedIn ()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login");
            }
        }

        //DELETE: //User
        public ActionResult DeleteUser (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RegisterUser user = _context.RegisterUsers.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUser (int id)
        {
            RegisterUser user = _context.RegisterUsers.Find(id);
            _context.RegisterUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");

            
        }

        //GET: //RegisterUser
        public ActionResult Details (int? id)
        {
            if (id  == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RegisterUser user = _context.RegisterUsers.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }
    }
}