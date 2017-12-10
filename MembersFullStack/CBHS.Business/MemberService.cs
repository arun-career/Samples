using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Business
{
    using Interfaces;
    using Entity;

    public class MemberService : IMemberService
    {
        private readonly Datasource.IDataRepository _repository;

        public MemberService(Datasource.IDataRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Member Member)
        {
            return _repository.AddMember(Member);
        }

        public IList<Member> List()
        {
            var listOfDataMembers = _repository.GetMembers();

            var listOfMembers = listOfDataMembers.ConvertAll(m => new Member
            {
                MemberId = m.MemberId,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                DateOfBirth = m.DateOfBirth
            });

            return listOfMembers.ToList<Member>();
        }
    }
}