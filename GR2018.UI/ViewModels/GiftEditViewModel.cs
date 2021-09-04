using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GR2018.UI.ViewModels
{
    public class GiftEditViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "GiftRegistryId")]
        public int GiftRegistryId { get; set; }

        [Required]
        [Display(Name = "Gift Name")]
        public string GiftName { get; set; }

        [Display(Name = "Gift Description")]
        public string GiftDescription { get; set; }

        [Required]
        [Display(Name = "Member ID")]
        public int MemberID { get; set; }

        [Display(Name = "Giver")]
        public int  GiverID { get; set; }
        public IEnumerable<SelectListItem> Givers { get; set; }

        [Required]
        [Display(Name = "Recipient")]
        public int RecipientID { get; set; }
        public IEnumerable<SelectListItem> Recipients { get; set; }

    }
}