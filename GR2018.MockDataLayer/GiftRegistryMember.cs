namespace GR2018.MockDataLayer
{
    using System;
    using System.Collections.Generic;

    public partial class GiftRegistryMember
    {
        public int GiftRegistryMemberID { get; set; }

        public int GiftRegistryID { get; set; }

        public int MemberID { get; set; }

        public bool IsAdmin { get; set; }

        public virtual GiftRegistry GiftRegistry { get; set; }

        public virtual Member Member { get; set; }
    }
}
