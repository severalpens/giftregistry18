namespace GR2018.MockDataLayer
{
    using System;
    using System.Collections.Generic;

    public partial class GiftRegistryInvite
    {
        public int GiftRegistryInviteID { get; set; }

        public int GiftRegistryID { get; set; }

        public string InviteeName { get; set; }

        public string Email { get; set; }

        public virtual GiftRegistry GiftRegistry { get; set; }

    }
}
