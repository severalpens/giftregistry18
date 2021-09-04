namespace GR2018.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<GiftRegistry> GiftRegistries { get; set; }
        public virtual DbSet<GiftRegistryMember> GiftRegistryMembers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberGift> MemberGifts { get; set; }
        public virtual DbSet<GiftRegistryInvite> Invites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gift>()
                .Property(e => e.GiftName)
                .IsUnicode(false);

            modelBuilder.Entity<Gift>()
                .Property(e => e.GiftDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Gift>()
                .HasMany(e => e.MemberGifts)
                .WithRequired(e => e.Gift)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiftRegistry>()
                .Property(e => e.GiftRegistryName)
                .IsUnicode(false);

            modelBuilder.Entity<GiftRegistry>()
                .HasMany(e => e.GiftRegistryMembers)
                .WithRequired(e => e.GiftRegistry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.MemberName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.MemberEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.GiftRegistryMembers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberGifts)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiftRegistryInvite>()
                .Property(e => e.InviteeName)
                .IsUnicode(false);

            modelBuilder.Entity<GiftRegistryInvite>()
                           .Property(e => e.Email)
                           .IsUnicode(false);

            modelBuilder.Entity<Gift>()
                           .Property(e => e.Email)
                           .IsUnicode(false);


            modelBuilder.Entity<GiftRegistry>()
              .HasMany(e => e.GiftRegistryInvites)
              .WithRequired(e => e.GiftRegistry)
              .WillCascadeOnDelete(false);




        }
    }
}
