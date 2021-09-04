namespace GR2018.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GR.GiftRegistry")]
    public partial class GiftRegistry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiftRegistry()
        {
            GiftRegistryMembers = new HashSet<GiftRegistryMember>();
            GiftRegistryInvites = new HashSet<GiftRegistryInvite>();
        }

        public int GiftRegistryID { get; set; }

        [StringLength(500)]
        public string GiftRegistryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftRegistryMember> GiftRegistryMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftRegistryInvite> GiftRegistryInvites { get; set; }

    }
}
