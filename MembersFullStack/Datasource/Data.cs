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
        public static int AddMember(Member member)
        {
            member.MemberId = members.Count() + 1;
            try
            {
                members.Add(member);
            }
            catch (Exception ex)
            {
                //Log the exception
                return 0;
            }

            return member.MemberId;
        }
        public static List<Member> GetMembers()
        {
            return members;
        }
    }
}
