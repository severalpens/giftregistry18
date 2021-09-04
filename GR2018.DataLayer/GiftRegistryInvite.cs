namespace GR2018.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GR.GiftRegistryInvite")]
    public partial class GiftRegistryInvite
    {
        public int GiftRegistryInviteID { get; set; }

        public int GiftRegistryID { get; set; }

        public string InviteeName { get; set; }

        public string Email { get; set; }

        public virtual GiftRegistry GiftRegistry { get; set; }

    }
}
