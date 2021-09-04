using GR2018.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace GR2018.UI.Data
{
    public class GiversRepository
    {
        public IEnumerable<SelectListItem> GetGivers(int id, int suggestorId)
        {
            using (var context = new Model1())
            {
                List<SelectListItem> Givers = context.GiftRegistryMembers
                    .Where(x => x.GiftRegistryID == id)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.MemberID.ToString(),
                            Text = n.Member.MemberName
                        }).ToList();
                //var countrytip = new SelectListItem()
                //{
                //    Value = 0.ToString(),
                //    Text = "-"
                //};
                //Givers.Insert(0, countrytip);
                return new SelectList(Givers, "Value", "Text","7");
            }
        }
    }
}