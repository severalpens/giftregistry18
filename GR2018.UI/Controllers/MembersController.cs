//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using GR2018.DataLayer;
//using GR2018.IdentityDataLayer;
//using Microsoft.AspNet.Identity;

//namespace GR2018.UI.Controllers
//{
//    public class MembersController : Controller
//    {
//        private Model1 db = new Model1();

//        // GET: Members
//        public ActionResult Index()
//        {
//            var userID = User.Identity.GetUserId();
//            IdentityModel idb = new IdentityModel();
//            string userEmail = idb.AspNetUsers.Where(x => x.Id == userID).FirstOrDefault().Email;
//            var Model1Member = db.Members.Where(x => x.MemberEmail == userEmail).FirstOrDefault();
//            return View(db.Members.Where(x => x.MemberEmail == userEmail).ToList());
//        }



//        // GET: Members/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Member member = db.Members.Find(id);
//            if (member == null)
//            {
//                return HttpNotFound();
//            }
//            return View(member);
//        }

//        // GET: Members/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Members/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "MemberID,MemberName,MemberEmail")] Member member)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Members.Add(member);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(member);
//        }

//        // GET: Members/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Member member = db.Members.Find(id);
//            if (member == null)
//            {
//                return HttpNotFound();
//            }
//            return View(member);
//        }

//        // POST: Members/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "MemberID,MemberName,MemberEmail")] Member member)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(member).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(member);
//        }

//        // GET: Members/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Member member = db.Members.Find(id);
//            if (member == null)
//            {
//                return HttpNotFound();
//            }
//            return View(member);
//        }

//        // POST: Members/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Member member = db.Members.Find(id);
//            db.Members.Remove(member);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
