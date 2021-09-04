using System;
using System.ComponentModel.DataAnnotations;

namespace GR2018.UI.ViewModels
{
    public class GiftDisplayViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Gift Registry Id")]
        public int GiftRegistryId { get; set; }

        [Display(Name = "Gift Name")]
        public string GiftName { get; set; }

        [Display(Name = "Gift Description")]
        public string GiftDescription { get; set; }

        [Display(Name = "Member ID")]
        public int MemberID { get; set; }

        [Display(Name = "Suggested By")]
        public string SuggestedBy { get; set; }


        [Display(Name = "Giver Name")]
        public string GiverName { get; set; }

        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }
    }
}