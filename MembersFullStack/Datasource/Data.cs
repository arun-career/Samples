using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Datasource
{
    public static class Data
    {
        private static List<Member> members = new List<Member>();
        public static bool AddMember(Member member)
        {
            //member.MemberId = members.Count() + 1;
            try
            {
                //members.Add(member);
                using (var db = new CBHSDBContext())
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log the exception
                return false;
            }
        }
        public static List<Member> GetMembers()
        {
            var result = new List<Member>();

            using (var db = new CBHSDBContext())
            {
                var query = from m in db.Members
                            orderby m.MemberId
                            select m;
                result = query.ToList<Member>();
            }

            return result;
        }
    }
}
