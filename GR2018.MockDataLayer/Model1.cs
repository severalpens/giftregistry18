namespace GR2018.MockDataLayer
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    public partial class Model1 
    {
        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<GiftRegistry> GiftRegistries { get; set; }
        public virtual DbSet<GiftRegistryMember> GiftRegistryMembers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberGift> MemberGifts { get; set; }
        public virtual DbSet<GiftRegistryInvite> Invites { get; set; }

    }
}
