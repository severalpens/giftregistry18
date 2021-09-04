using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GR2018.DataLayer;

namespace GR2018.UI.Models
{
    public class GRMViewModel
    {

    }
    public class GiftRegistryModels
    {
        public Model1 m1;
        public GiftRegistryModels()
        {
            m1 = new Model1();
            int LoggedInMemberID = 1;
            var LoggedInMemberRegIDs = m1.GiftRegistryMembers.Where(m => m.MemberID == LoggedInMemberID).Select(m => m.GiftRegistryID);

            var GiftRegistryList =
            from GRMRow in m1.GiftRegistryMembers
            where GRMRow.MemberID == LoggedInMemberID
            select new
            {
                GRMRow.GiftRegistryID,
                GRMRow.GiftRegistry.GiftRegistryName,
                GRMRow.IsAdmin

            };

        }
    }

    public class NGRM_POCO
    {
        public int GRID { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
    }

    public class NewGiftRegistryMember
    {

        public int GRID { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        private Member M { get; set; }
        private GiftRegistryMember grm { get; set; }
        public Model1 m1 { get; set; }

        public NewGiftRegistryMember()
        {
            m1 = new Model1();
        }


        public void AddMember(NGRM_POCO poco)
        {
            GRID = poco.GRID;
            M = m1.Members.Where(x => x.MemberEmail == poco.MemberEmail).FirstOrDefault();
            if(M != null)
            {
                var existingGRM = m1.GiftRegistryMembers.Where(x => x.GiftRegistryID == GRID)
                    .Where(x => x.MemberID == M.MemberID)
                    .FirstOrDefault();

                if(existingGRM == null)
                {
                    grm = new GiftRegistryMember
                    {
                        Member = M,
                        GiftRegistryID = GRID,
                        GiftRegistry = m1.GiftRegistries.Find(GRID),
                        MemberID = M.MemberID,
                        IsAdmin = false
                    };
                    m1.GiftRegistryMembers.Add(grm);

                }
            m1.SaveChanges();
            }
            else
            {
                M = new Member
                {
                    MemberEmail = poco.MemberEmail,
                    MemberName = poco.MemberName
                };

                m1.Members.Add(M);
                m1.SaveChanges();
                grm = new GiftRegistryMember();
                grm.Member = M; 
                grm.GiftRegistryID = GRID;
                grm.GiftRegistry = m1.GiftRegistries.Find(GRID);
                grm.MemberID = M.MemberID;
                grm.IsAdmin = false;
                m1.GiftRegistryMembers.Add(grm);
                m1.SaveChanges();
                
            }
        }
    }
}
