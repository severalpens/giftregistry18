using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GR2018.DataLayer;

namespace GR2018.UI.Controllers
{
    public class GiftRegistryInvitesController : Controller
    {
        private Model1 db = new Model1();

        // GET: GiftRegistryInvites
        public ActionResult Index(int? id)
        {
            //var invites = db.Invites.Include(g => g.GiftRegistry);
            var invites = db.Invites.Where(x => x.GiftRegistryID == id);
            return View(invites.ToList());
        }

        // GET: GiftRegistryInvites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistryInvite giftRegistryInvite = db.Invites.Find(id);
            if (giftRegistryInvite == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistryInvite);
        }

        // GET: GiftRegistryInvites/Create
        public ActionResult Create()
        {
            ViewBag.GiftRegistryID = new SelectList(db.GiftRegistries, "GiftRegistryID", "GiftRegistryName");
            return View();
        }

        // POST: GiftRegistryInvites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GiftRegistryInviteID,GiftRegistryID,InviteeName,Email")] GiftRegistryInvite giftRegistryInvite)
        {
            if (ModelState.IsValid)
            {
                db.Invites.Add(giftRegistryInvite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GiftRegistryID = new SelectList(db.GiftRegistries, "GiftRegistryID", "GiftRegistryName", giftRegistryInvite.GiftRegistryID);
            return View(giftRegistryInvite);
        }

        // GET: GiftRegistryInvites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistryInvite giftRegistryInvite = db.Invites.Find(id);
            if (giftRegistryInvite == null)
            {
                return HttpNotFound();
            }
            ViewBag.GiftRegistryID = new SelectList(db.GiftRegistries, "GiftRegistryID", "GiftRegistryName", giftRegistryInvite.GiftRegistryID);
            return View(giftRegistryInvite);
        }

        // POST: GiftRegistryInvites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GiftRegistryInviteID,GiftRegistryID,InviteeName,Email")] GiftRegistryInvite giftRegistryInvite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giftRegistryInvite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GiftRegistryID = new SelectList(db.GiftRegistries, "GiftRegistryID", "GiftRegistryName", giftRegistryInvite.GiftRegistryID);
            return View(giftRegistryInvite);
        }

        // GET: GiftRegistryInvites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistryInvite giftRegistryInvite = db.Invites.Find(id);
            if (giftRegistryInvite == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistryInvite);
        }

        // POST: GiftRegistryInvites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftRegistryInvite giftRegistryInvite = db.Invites.Find(id);
            db.Invites.Remove(giftRegistryInvite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
