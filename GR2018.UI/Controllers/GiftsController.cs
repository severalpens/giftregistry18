using GR2018.DataLayer;
using GR2018.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GR2018.UI.Data;
using GR2018.UI.ViewModels;



namespace GR2018.UI.Controllers
{
    public class GiftsController : Controller
    {
        string userId;
        UserManager<ApplicationUser> userManager;
        ApplicationUser user;
        Model1 dbContext;
        Member member;
        

        public GiftsController()
        {
            dbContext = new Model1();
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            user = userManager.FindById(userId);
            member = dbContext.Members
                .Where(x => x.MemberEmail == user.Email)
                .FirstOrDefault();
        }

        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            var repo = new GiftsRepository();
            var model = repo.GetGifts(id, member.MemberID);
            ViewBag.GRName = dbContext.GiftRegistries.Find(id).GiftRegistryName;
            return View(model);
        }

     

        // GET: Gifts/Create
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            var repo = new GiftsRepository();
            GiftEditViewModel model = repo.CreateGift(id, member.MemberID);
            model.Id = 0;
            return View(model);
        }

        // POST: Gifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, GiftRegistryId,GiftName,GiftDescription,MemberID,GiverID,RecipientID")] GiftEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new GiftsRepository();
                    model.Id = 0;
                    bool saved = repo.SaveGift(model);
                    if (saved)
                    {
                        return RedirectToAction("Index", routeValues: new { id = model.GiftRegistryId});
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: Gifts/Edit/5
        public ActionResult Edit(int id, int grid)
        {
            ViewBag.Id = grid;
            var repo = new GiftsRepository();
            GiftEditViewModel model = repo.EditGift(id, member.MemberID);
            model.Id = 0;
            return View(model);

        }

        // GET: Gifts/Details/5
        public ActionResult Details(int id, int grid)
        {
            ViewBag.Id = grid;
            var repo = new GiftsRepository();
            GiftDetailsViewModel model = repo.GiftDetails(id, member.MemberID);
            return View(model);
        }
        // POST: Gifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, GiftRegistryId,GiftName,GiftDescription,MemberID,GiverID,RecipientID")] GiftEditViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new GiftsRepository();
                    bool saved = repo.SaveGift(model);
                    if (saved)
                    {
                        return RedirectToAction("Index", routeValues: new { id = model.GiftRegistryId });
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Gifts/Delete/5
        public ActionResult Delete(int id, int grid)
        {
            //
            var gift = dbContext.Gifts.Find(id);
            var range = dbContext.MemberGifts.Where(x => x.GiftID == id);
            dbContext.MemberGifts.RemoveRange(range);
            if(gift != null)
            {
                dbContext.Gifts.Remove(gift);
            }
            dbContext.SaveChanges();

            return RedirectToAction("Index", new { id = grid });

        }

        // POST: Gifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var gift = dbContext.Gifts.Find(id);
            var range = dbContext.MemberGifts.Where(x => x.GiftID == id);
            dbContext.MemberGifts.RemoveRange(range);
            dbContext.Gifts.Remove(gift);
            dbContext.SaveChanges();
            return RedirectToAction("Index", routeValues: new { id = gift.GiftRegistryID});
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
