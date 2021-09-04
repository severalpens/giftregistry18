using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GR2018.UI.ViewModels
{
    public class GiftDetailsViewModel
    {
        [Display(Name = "GiftID")]
        public int GiftID { get; set; }

        [Display(Name = "Gift Name")]
        public string GiftName { get; set; }

        [Display(Name = "Gift Description")]
        public string GiftDescription { get; set; }

        [Display(Name = "Suggested By")]
        public string SuggestedBy { get; set; }

        [Display(Name = "Giver")]
        public string Giver { get; set; }

        [Display(Name = "Recipient")]
        public string Recipient { get; set; }




    }
}