using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GR2018.UI.Models
{
    public class Recipient
    {
        [Key]
        public int RecipientID { get; set; }

        [Required]
        public string RecipientName { get; set; }

        public virtual IEnumerable<Recipient> Recipients { get; set; }
    }
}