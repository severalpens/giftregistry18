namespace GR2018.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GR.Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            GiftRegistryMembers = new HashSet<GiftRegistryMember>();
            MemberGifts = new HashSet<MemberGift>();
        }

        public int MemberID { get; set; }

        [StringLength(500)]
        public string MemberName { get; set; }

        [StringLength(500)]
        public string MemberEmail { get; set; }

        public bool HasEmail { get; set; }

        public string AccountID { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftRegistryMember> GiftRegistryMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberGift> MemberGifts { get; set; }
    }
}
