using System.Collections.Generic;

namespace CBHS.Datasource
{
    public interface IDataRepository
    {
        bool AddMember(Entity.Member member);

        List<Entity.Member> GetMembers();
    }
}