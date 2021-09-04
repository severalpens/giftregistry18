namespace GR2018.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GR.Gift")]
    public partial class Gift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gift()
        {
            MemberGifts = new HashSet<MemberGift>();
        }

        public int GiftID { get; set; }

        public int GiftRegistryID { get; set; }

        [StringLength(500)]
        public string GiftName { get; set; }

        [StringLength(4000)]
        public string GiftDescription { get; set; }

        [StringLength(500)]
        public string Email { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberGift> MemberGifts { get; set; }
    }
}
