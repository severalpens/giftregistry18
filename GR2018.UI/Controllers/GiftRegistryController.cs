using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GR2018.DataLayer;
using GR2018.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


namespace GR2018.UI.Controllers
{
    [Authorize]
    public class GiftRegistryController : Controller
    {
        string userId;
        UserManager<ApplicationUser> userManager;
        ApplicationUser user;
        string userEmail;
        private Model1 dbContext = new Model1();


        public GiftRegistryController()
        {
            dbContext = new Model1();
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            user = userManager.FindById(userId);
            userEmail = user.Email;
        }



        //private IdentityModel idb = new IdentityModel();
        Member Model1Member;
        
        // GET: GiftRegistry
        public ActionResult Index()
        {
            //var userEmail = Membership.GetUser().Email;
            var userID = User.Identity.GetUserId();
            // var ue = Profile.PropertyValues;
            //userEmail = idb.AspNetUsers.Where(x => x.Id == userID).FirstOrDefault().Email;
            Model1Member = dbContext.Members.Where(x => x.MemberEmail == userEmail).FirstOrDefault();
            Console.WriteLine("about to writeline");
            if (userEmail.ToLower().Contains("beatles")){
                Console.WriteLine("caution contains beatles");
            }
            if (userEmail != null)
            {

            var GRListForLoggedInUser = dbContext.GiftRegistryMembers
                .Where(x => x.Member.MemberEmail == userEmail).ToList();

            return View(GRListForLoggedInUser);
            
            }
            else
            {
                return View("Error");
            }
        }

        // GET: GiftRegistry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistry giftRegistry = dbContext.GiftRegistries.Find(id);
            if (giftRegistry == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistry);
        }

        // GET: GiftRegistry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiftRegistry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GiftRegistryID,GiftRegistryName")] GiftRegistry giftRegistry)
        {
            if (ModelState.IsValid)
            {
                dbContext.GiftRegistries.Add(giftRegistry);
                var userID = User.Identity.GetUserId();
                //userEmail = idb.AspNetUsers.Where(x => x.Id == userID).FirstOrDefault().Email;
                Model1Member = dbContext.Members.Where(x => x.MemberEmail == userEmail).FirstOrDefault();
                Member defaultMember = dbContext.Members.Find(7);
                dbContext.GiftRegistryMembers.Add(
                    new GiftRegistryMember
                    {
                        GiftRegistryID = giftRegistry.GiftRegistryID,
                        GiftRegistry = giftRegistry,
                        MemberID = 7,
                        Member = defaultMember,
                        IsAdmin = true
                    });

                dbContext.GiftRegistryMembers.Add(
                    new GiftRegistryMember
                    {
                        GiftRegistryID = giftRegistry.GiftRegistryID,
                        GiftRegistry = giftRegistry,
                        MemberID = Model1Member.MemberID,
                        Member = Model1Member,
                        IsAdmin = true
                    });

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giftRegistry);
        }


        // GET: GiftRegistry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistry giftRegistry = dbContext.GiftRegistries.Find(id);
            if (giftRegistry == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistry);
        }

        // POST: GiftRegistry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GiftRegistryID,GiftRegistryName")] GiftRegistry giftRegistry)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(giftRegistry).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(giftRegistry);
            return View("Edit");
        }

        // GET: GiftRegistry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistry giftRegistry = dbContext.GiftRegistries.Find(id);
            if (giftRegistry == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistry);
        }

        // POST: GiftRegistry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var gifts = dbContext.Gifts.Where(x => x.GiftRegistryID == id);
            var membergifts = dbContext.MemberGifts.Where(x => x.Gift.GiftRegistryID == id);
            dbContext.MemberGifts.RemoveRange(membergifts);
            dbContext.Gifts.RemoveRange(gifts);
            var grmList = dbContext.GiftRegistryMembers.Where(x => x.GiftRegistryID == id);
            dbContext.GiftRegistryMembers.RemoveRange(grmList);




            GiftRegistry giftRegistry = dbContext.GiftRegistries.Find(id);
            dbContext.GiftRegistries.Remove(giftRegistry);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
