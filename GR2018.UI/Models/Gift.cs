using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GR2018.UI.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public int GiftRegistryId { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public int MemberID { get; set; }
        public int GiverID { get; set; }
        public int RecipientID { get; set; }
        public virtual Suggestor SuggestedBy { get; set; }
        public virtual Giver Giver { get; set; }
        public virtual Recipient Recipient { get; set; }
    }
}