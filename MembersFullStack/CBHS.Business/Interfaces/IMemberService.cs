using CBHS.Entity;
using System.Collections.Generic;

namespace CBHS.Business.Interfaces
{
    public interface IMemberService
    {
        bool Add(Member Member);

        IList<Member> List();

        Member GetOldestMember();
    }
}