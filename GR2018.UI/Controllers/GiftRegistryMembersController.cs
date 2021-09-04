using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GR2018.DataLayer;
using GR2018.UI.Models;

namespace GR2018.UI.Controllers
{
    [Authorize]
    public class GiftRegistryMembersController : Controller
    {

        // GET: GiftRegistryMembers
        public ActionResult Index(int? id)
        {
            Model1 db = new Model1();
            var giftRegistryMembers = db.GiftRegistryMembers.Where(x => x.GiftRegistryID == id).Include(g => g.GiftRegistry).Include(g => g.Member);
            ViewBag.id = id;
            ViewBag.GRName = db.GiftRegistries.Find(id).GiftRegistryName.ToString();
            return View(giftRegistryMembers.ToList());
        }

        // GET: GiftRegistryMembers/Details/5
        public ActionResult Details(int? id)
        {
            Model1 db = new Model1();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistryMember giftRegistryMember = db.GiftRegistryMembers.Find(id);
            if (giftRegistryMember == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", routeValues: new { id});
        }

        // GET: GiftRegistryMembers/NewMember
        public ActionResult NewMember(int? id)
        {
            Model1 db = new Model1();

            //var model = new NewGiftRegistryMember(id ?? 0);
            var model = new NGRM_POCO();
            model.GRID = id ?? 0;
            ViewBag.GRName = db.GiftRegistries.Find(id).GiftRegistryName;
            ViewBag.id = id ?? 0;
            model.MemberEmail = "NewMember1@gmail.com";
            model.MemberName = "NewMember1";
            return View(model);
        }

        // POST: GiftRegistryMembers/NewMember
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMember([Bind(Include = "GRID,MemberEmail,MemberName")] NGRM_POCO poco)
        {
            if (ModelState.IsValid)
            {
                NewGiftRegistryMember ngrm = new NewGiftRegistryMember();
                ngrm.AddMember(poco);
                return RedirectToAction("Index",  routeValues: new {id = poco.GRID });
            }

            return View(poco);
        }


        //// get: giftregistrymembers/edit/5
        //public actionresult edit(int? id)
        //{
        //    model1 db = new model1();
        //    var grm = db.giftregistrymembers.find(id);
        //    ngrm_poco model = new ngrm_poco();
        //    model.grid = grm.giftregistrymemberid
        //    return view(model);
        //}

        //// post: giftregistrymembers/edit/5
        //// to protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?linkid=317598.
        //[httppost]
        //[validateantiforgerytoken]
        //public actionresult edit([bind(include = "grid,memberemail,membername")] giftregistrymember grm)
        //{
        //    if (modelstate.isvalid)
        //    {
        //        newgiftregistrymember ngrm = new newgiftregistrymember();
        //        ngrm.addmember(poco);
        //        return redirecttoaction("index", routevalues: new { id = poco.grid });
        //    }

        //    return view(poco);
        //}

        // GET: GiftRegistryMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            Model1 db = new Model1();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftRegistryMember giftRegistryMember = db.GiftRegistryMembers.Find(id);
            if (giftRegistryMember == null)
            {
                return HttpNotFound();
            }
            return View(giftRegistryMember);
        }

        // POST: GiftRegistryMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model1 db = new Model1();

            GiftRegistryMember giftRegistryMember = db.GiftRegistryMembers.Find(id);
            int grid = giftRegistryMember.GiftRegistryID;
            db.GiftRegistryMembers.Remove(giftRegistryMember);
            db.SaveChanges();
            return RedirectToAction("Index", routeValues: new { id = grid });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
