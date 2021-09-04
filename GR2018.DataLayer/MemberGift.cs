namespace GR2018.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GR.MemberGift")]
    public partial class MemberGift
    {
        public int MemberGiftID { get; set; }

        public int GiftID { get; set; }

        public int MemberID { get; set; }

        public bool Recipient { get; set; }

        public bool Suggestor { get; set; }

        public bool Contributor { get; set; }

        public virtual Gift Gift { get; set; }

        public virtual Member Member { get; set; }
    }
}
