using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GR2018.UI.Models;
using GR2018.UI.ViewModels;
using GR2018.UI;
using GR2018.DataLayer;
using System.Web.Mvc;

namespace GR2018.UI.Data
{
    public class GiftsRepository
    {
        Models.Gift gift;
        Giver giver;
        Recipient recipient;
        List<Giver> givers = new List<Giver>();
        List<Recipient> recipients = new List<Recipient>();
        List<Suggestor> suggestors = new List<Suggestor>();

        List<SelectListItem> giversSLI = new List<SelectListItem>();
        List<SelectListItem> recipientsSLI = new List<SelectListItem>();

        public List<GiftDisplayViewModel> GetGifts(int id, int memberId)
        {

            using (var context = new GR2018.DataLayer.Model1())
            {
                List<Models.Gift> Gifts = new List<Models.Gift>();
                var mgList = context.MemberGifts.Where(x => x.Gift.GiftRegistryID == id);

                foreach (var g in context.Gifts)
                {
                    if (g.GiftRegistryID == id)
                    {
                        gift = new Models.Gift
                        {
                            Id = g.GiftID,
                            GiftRegistryId = g.GiftRegistryID,
                            GiftDescription = g.GiftDescription,
                            GiftName = g.GiftName,
                            Giver = GetGiver( g.GiftID),
                            Recipient = GetRecipient( g.GiftID),
                            MemberID = memberId,
                            SuggestedBy = GetSuggestor(g.GiftID)
                        };

                        gift.GiverID = gift.Giver.GiverID;
                        gift.RecipientID = gift.Recipient.RecipientID;

                        Gifts.Add(gift);
                    }
                }


                if (Gifts != null)
                {
                    List<GiftDisplayViewModel> GiftsDisplay = new List<GiftDisplayViewModel>();
                    foreach (var x in Gifts)
                    {
                        if (x.RecipientID != memberId)
                        {
                            var GiftDisplay = new GiftDisplayViewModel()
                            {
                                Id = x.Id,
                                GiftRegistryId = x.GiftRegistryId,
                                GiftDescription = x.GiftDescription,
                                GiverName = x.Giver.GiverName,
                                MemberID = x.MemberID,
                                SuggestedBy = x.SuggestedBy.SuggestorName,
                                GiftName = x.GiftName,
                                RecipientName = x.Recipient.RecipientName
                            };
                            GiftsDisplay.Add(GiftDisplay);
                        }
                    }
                    return GiftsDisplay;
                }
                return null;
            }
        }
        
        private Giver GetGiver(int giftId)
        {
            Giver temp;
            using (var context = new GR2018.DataLayer.Model1())
            {

                var g = context.MemberGifts.Where(x => x.GiftID == giftId)
                .Where(x => x.Contributor == true)
                .FirstOrDefault();
                if (g != null)
                {
                    temp = new Giver
                    {
                        GiverID = g.MemberID,
                        GiverName = g.Member.MemberName,
                        Givers = givers
                    };
                }
                else
                {
                    temp = new Giver
                    {
                        GiverID = 0,
                        GiverName = "-",
                        Givers = givers
                    };

                }
            }

            return temp;
                
        }

        private Recipient GetRecipient( int giftId)
        {
            Recipient temp;
            using (var context = new GR2018.DataLayer.Model1())
            {

                var g = context.MemberGifts.Where(x => x.GiftID == giftId)
                .Where(x => x.Recipient == true)
                .FirstOrDefault();
                if (g != null)
                {
                    temp = new Recipient
                    {
                        RecipientID = g.MemberID,
                        RecipientName = g.Member.MemberName,
                        Recipients = recipients
                    };
                }
                else
                {
                    temp = new Recipient
                    {
                        RecipientID = 0,
                        RecipientName = "-",
                        Recipients = recipients
                    };

                }
            }
            return temp;

        }

        private Suggestor GetSuggestor(int giftId)
        {
            Suggestor temp;
            using (var context = new GR2018.DataLayer.Model1())
            {

                var g = context.MemberGifts.Where(x => x.GiftID == giftId)
                .Where(x => x.Suggestor == true)
                .FirstOrDefault();
                if (g != null)
                {
                    temp = new Suggestor
                    {
                        SuggestorID = g.MemberID,
                        SuggestorName = g.Member.MemberName,
                        Suggestors = suggestors
                    };
                }
                else
                {
                    temp = new Suggestor
                    {
                        SuggestorID = 0,
                        SuggestorName = "-",
                        Suggestors = suggestors
                    };

                }
            }
            return temp;

        }



        public ViewModels.GiftEditViewModel CreateGift(int id, int suggestorId)
        {
            var cRepo = new GiversRepository();
            var rRepo = new RecipientsRepository();

            using (var context = new GR2018.DataLayer.Model1())
            {
                //populateLists(id, context);
            }
            var Gift = new ViewModels.GiftEditViewModel()
            {
                Id = 0,
                GiftRegistryId = id,
                MemberID = suggestorId,
                  
                Givers = cRepo.GetGivers(id, suggestorId),
                Recipients = rRepo.GetRecipients(id, suggestorId)
            };
            return Gift;
        }

        public ViewModels.GiftEditViewModel EditGift(int id, int suggestorId)
        {
            var cRepo = new GiversRepository();
            var rRepo = new RecipientsRepository();

            using (var context = new GR2018.DataLayer.Model1())
            {
                var gift = context.Gifts.Find(id);
                var Gift = new ViewModels.GiftEditViewModel()
                {
                    Id = gift.GiftID,
                    GiftRegistryId = gift.GiftRegistryID,
                    MemberID = suggestorId,
                    GiftName = gift.GiftName,
                    GiftDescription = gift.GiftDescription,
                    GiverID = context.MemberGifts
                                .Where(x => x.GiftID == id && x.Contributor == true)
                                .FirstOrDefault()
                                .MemberID,
                    RecipientID = context.MemberGifts
                                .Where(x => x.GiftID == id && x.Recipient == true)
                                .FirstOrDefault()
                                .MemberID,



                    Givers = cRepo.GetGivers(gift.GiftRegistryID, suggestorId),
                    Recipients = rRepo.GetRecipients(gift.GiftRegistryID, suggestorId)
                };
            return Gift;
            }
        }

        public ViewModels.GiftDetailsViewModel GiftDetails(int id, int suggestorId)
        {
            using (var context = new GR2018.DataLayer.Model1())
            {
                var gift = context.Gifts.Find(id);
                var Gift = new ViewModels.GiftDetailsViewModel()
                {
                    GiftID = id,
                    GiftName = gift.GiftName,
                    GiftDescription = gift.GiftDescription,
                    SuggestedBy = context.MemberGifts
                                .Where(x => x.GiftID == id && x.Suggestor == true)
                                .FirstOrDefault()
                                .Member.MemberName,
                    Giver = context.MemberGifts
                                .Where(x => x.GiftID == id && x.Contributor == true)
                                .FirstOrDefault()
                                .Member.MemberName,
                    Recipient = context.MemberGifts
                                .Where(x => x.GiftID == id && x.Recipient == true)
                                .FirstOrDefault()
                                .Member.MemberName,
                };
                return Gift;
            }
        }

        public bool SaveGift(GiftEditViewModel Giftedit)
        {
            if (Giftedit != null)
            {
                using (var context = new Model1())
                {
                    var g = context.Gifts.Find(Giftedit.Id);
                    if(g != null)
                    {
                        g.GiftName = Giftedit.GiftName;
                        g.GiftDescription = Giftedit.GiftDescription;
                        recreateGiftMembers(context, g, Giftedit);
                    }
                    else
                    {
                        var newg = new GR2018.DataLayer.Gift();
                        newg.GiftName = Giftedit.GiftName;
                        newg.GiftDescription = Giftedit.GiftDescription;
                        newg.GiftRegistryID = Giftedit.GiftRegistryId;
                        context.Gifts.Add(newg);
                        context.SaveChanges();
                        recreateGiftMembers(context, newg, Giftedit);
                    }
                }
            }
            // Return false if Giftedit == null or GiftID is not a guid
            return true;
        }

        private void recreateGiftMembers(Model1 context, DataLayer.Gift g, GiftEditViewModel giftedit)
        {
            MemberGift suggestor = new MemberGift();
            MemberGift giver = new MemberGift();
            MemberGift recipient = new MemberGift();

            var memberGifts = context.MemberGifts.Where(x => x.GiftID == g.GiftID);

            foreach (var x in memberGifts)
            {
                context.MemberGifts.Remove(x);
            }

            suggestor.Gift = g;
            suggestor.GiftID = g.GiftID;
            suggestor.Member = context.Members.Find(giftedit.MemberID);
            suggestor.MemberID = giftedit.MemberID;
            suggestor.Suggestor = true;
            context.MemberGifts.Add(suggestor);

            giver.GiftID = g.GiftID;
            giver.Gift = context.Gifts.Find(giftedit.Id);
            giver.Member = context.Members.Find(giftedit.GiverID);
            giver.MemberID = giftedit.GiverID;
            giver.Contributor = true;
            context.MemberGifts.Add(giver);

            recipient.GiftID = g.GiftID;
            recipient.Gift = context.Gifts.Find(giftedit.Id);
            recipient.Member = context.Members.Find(giftedit.RecipientID);
            recipient.MemberID = giftedit.RecipientID;
            recipient.Recipient = true;
            context.MemberGifts.Add(recipient);

            context.SaveChanges();

        }
    }
}