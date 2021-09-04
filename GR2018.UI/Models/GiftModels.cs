using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GR2018.DataLayer;

namespace GR2018.UI.Models
{
    public class CreateGiftPOCO
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public int MemberID { get; set; }
        public string GiverName { get; set; }
        public string RecipientName { get; set; }

     //   internal void CreateNewGift()
     //   {
    //        GR2018.DataLayer.Model1 m1 = new Model1();
    //        Gift gift = new Gift();
    //        gift.GiftName = GiftName;
    //        gift.GiftDescription = GiftDescription;
    //        gift.GiftRegistryID = Id;
    //        m1.Gifts.Add(gift);
    //        m1.SaveChanges();

    //        MemberGift SuggestedBy = new MemberGift();
    //        SuggestedBy.GiftID = gift.GiftID;
    //        SuggestedBy.Gift = gift;
    //        SuggestedBy.MemberID = MemberID;
    //        SuggestedBy.Member = m1.Members.Find(MemberID);
    //        SuggestedBy.Suggestor = true;
    //        m1.MemberGifts.Add(SuggestedBy);

    //        MemberGift Recipient = new MemberGift();
    //        Recipient.GiftID = gift.GiftID;
    //        Recipient.Gift = gift;
    //        Recipient.MemberID = MemberID;
    //        Recipient.Member = m1.Members.Find(MemberID);
    //        Recipient.Recipient = true;
    //        m1.MemberGifts.Add(Recipient);


    //        MemberGift Giver = new MemberGift();
    //        Giver.GiftID = gift.GiftID;
    //        Giver.Gift = gift;
    //        Giver.MemberID = MemberID;
    //        Giver.Member = m1.Members.Find(MemberID);
    //        Giver.Contributor = true;
    //        m1.MemberGifts.Add(Giver);

    //        m1.SaveChanges();


    //    }
    //}
    //public class GiftEditViewModel
    //{
    //    public int Id { get; set; }
    //    public string GiftName { get; set; }
    //    public string GiftDescription { get; set; }
    //    public string Comments { get; set; }

    //    public Member SuggestedBy { get; set; }

    //    public int GiverId { get; set; }
    //    public string GiverName { get; set; }
    //    public Member Giver { get; set; }
    //    public IEnumerable<int> GiverIds { get; set; }
    //    public IEnumerable<SelectListItem> GiverNames { get; set; }
    //    public IEnumerable<string> Givers { get; set; }

    //    public int RecipientId { get; set; }
    //    public string RecipientName { get; set; }
    //    public Member Recipient { get; set; }
    //    public IEnumerable<int> RecipientIds { get; set; }
    //    public IEnumerable<SelectListItem> RecipientNames { get; set; }
    //    public IEnumerable<string> Recipients { get; set; }


    //    public GiftEditViewModel(int id, int memberId)
    //    {
    //        GR2018.DataLayer.Model1 m1 = new Model1();


    //        Id = id;
    //        //GiftName = "bedazzler";
    //        //GiftDescription = "As seen on TV";
    //        //Comments = "John saw it on TV and wanted it";

    //        SuggestedBy = m1.GiftRegistryMembers.Where(x => x.GiftRegistryID == id)
    //            .Where(x => x.MemberID == memberId).Select(x => x.Member).FirstOrDefault();

    //        SuggestedBy.MemberID = memberId;
    //        SuggestedBy.MemberName = "Ringo";

    //        Recipient = new Member();
    //        Recipient.MemberID = 1;
    //        Recipient.MemberName = "John";
    //        RecipientId = Recipient.MemberID;
    //        RecipientName = Recipient.MemberName;

    //        Giver = new Member();
    //        Giver.MemberID = 2;
    //        Giver.MemberName = "Paul";
    //        GiverId = Giver.MemberID;
    //        GiverName = Giver.MemberName;

    //        GiverNames = GetNames(id, memberId);
    //        RecipientNames = GetNames(id, memberId);


    //    }


    
    //    public IEnumerable<SelectListItem> GetNames(int id, int memberId )
    //    {
    //        Model1 m1 = new Model1();
    //        var members = m1.GiftRegistryMembers.Where(x => x.GiftRegistryID == id)
    //            .Where(x => x.MemberID == memberId)
    //            .Select(x => new {  x.MemberID,  x.Member.MemberName  }).ToList();

    //        List<SelectListItem> names = members
    //                    .Select(n =>
    //                    new SelectListItem
    //                    {
    //                        Value = n.MemberID.ToString(),
    //                        Text = n.MemberName
    //                    }).ToList();
    //            var namestip = new SelectListItem()
    //            {
    //                Value = null,
    //                Text = "--- select member ---"
    //            };
    //        names.Insert(0, namestip);
    //            return new SelectList(names, "Value", "Text");
    //    }
    }
}