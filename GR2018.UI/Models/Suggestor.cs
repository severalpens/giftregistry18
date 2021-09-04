using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace GR2018.UI.Models
{



    public class Suggestor
    {
        [Key]
        public int SuggestorID { get; set; }

        [Required]
        public string SuggestorName { get; set; }

        public virtual IEnumerable<Suggestor> Suggestors { get; set; }
    }
}