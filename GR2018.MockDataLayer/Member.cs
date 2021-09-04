namespace GR2018.MockDataLayer
{
    using System;
    using System.Collections.Generic;

    public partial class Member
    {
        public Member()
        {
            GiftRegistryMembers = new HashSet<GiftRegistryMember>();
            MemberGifts = new HashSet<MemberGift>();
        }

        public int MemberID { get; set; }

        public string MemberName { get; set; }

        public string MemberEmail { get; set; }

        public bool HasEmail { get; set; }

        public string AccountID { get; set; }


        public virtual ICollection<GiftRegistryMember> GiftRegistryMembers { get; set; }

        public virtual ICollection<MemberGift> MemberGifts { get; set; }
    }
}
