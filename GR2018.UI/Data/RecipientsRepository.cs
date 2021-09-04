using GR2018.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace GR2018.UI.Data
{
    public class RecipientsRepository
    {
        public IEnumerable<SelectListItem> GetRecipients(int id, int suggestorId)
        {
            using (var context = new Model1())
            {
                List<SelectListItem> Recipients = context.GiftRegistryMembers
                    .Where(x => x.GiftRegistryID == id)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.MemberID.ToString(),
                            Text = n.Member.MemberName
                        }).ToList();
                var countrytip = new SelectListItem()
                {
                    Value = null,
                    Text = "-"
                };
                Recipients.Insert(0, countrytip);
                return new SelectList(Recipients, "Value", "Text");
            }
        }
    }
}