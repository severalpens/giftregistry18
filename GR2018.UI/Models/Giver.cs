using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace GR2018.UI.Models
{



    public class Giver
    {
        [Key]
        public int  GiverID { get; set; }

        [Required]
        public string GiverName { get; set; }

        public virtual IEnumerable<Giver> Givers { get; set; }
    }
}