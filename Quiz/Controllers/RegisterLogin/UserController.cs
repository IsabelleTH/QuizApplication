using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Quiz.Models;
using System.Data.Entity;
using System.Net;
using PagedList;

namespace Quiz.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

      

        //[Authorize(Roles = "User")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameParam = String.IsNullOrWhiteSpace(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameParam = String.IsNullOrWhiteSpace(sortOrder) ? "lastname_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }

            else
            {
                searchString = currentFilter;
            }
            var users = from s in _context.Users select s;
          
           if (!String.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(m => m.LastName.Contains(searchString) || m.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstname_desc":
                    users = users.OrderByDescending(m => m.FirstName);
                    break;

                default:
                    users = users.OrderByDescending(m => m.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

      

        public ActionResult List()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        //GET: /Login/Edit/id
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {

            //var user = loginList.Where(u => u.UserId == Id).FirstOrDefault();
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //POST: /Login/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)   
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{
            //    _context.Entry(login).State = System.Data.Entity.EntityState.Modified;
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");

            //}

            return View(user);
        }

    
        public ActionResult DeleteUser (int? id) 
        {
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpDelete, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser (int id)
        {
            User login = _context.Users.Find(id);
            _context.Users.Remove(login);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CreateUser ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser (User user)
        {
               if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            else
            {
                return View(user);
            }

            
        }
         
    }
}