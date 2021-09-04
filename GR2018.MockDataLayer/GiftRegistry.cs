namespace GR2018.MockDataLayer
{
    using System;
    using System.Collections.Generic;

    public partial class GiftRegistry
    {
        public GiftRegistry()
        {
            GiftRegistryMembers = new HashSet<GiftRegistryMember>();
            GiftRegistryInvites = new HashSet<GiftRegistryInvite>();
        }

        public int GiftRegistryID { get; set; }

        public string GiftRegistryName { get; set; }

        public virtual ICollection<GiftRegistryMember> GiftRegistryMembers { get; set; }

        public virtual ICollection<GiftRegistryInvite> GiftRegistryInvites { get; set; }

    }
}
