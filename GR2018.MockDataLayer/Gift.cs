namespace GR2018.MockDataLayer
{
    using System;
    using System.Collections.Generic;

    public partial class Gift
    {
        public Gift()
        {
            MemberGifts = new HashSet<MemberGift>();
        }

        public int GiftID { get; set; }

        public int GiftRegistryID { get; set; }

        public string GiftName { get; set; }

        public string GiftDescription { get; set; }

        public string Email { get; set; }


        public virtual ICollection<MemberGift> MemberGifts { get; set; }
    }
}
