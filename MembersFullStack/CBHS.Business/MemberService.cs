using System.Collections.Generic;

namespace CBHS.Business
{
    using Interfaces;
    using Entity;
    using System.Linq;
    using System;

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

            return listOfDataMembers;
        }

        public Member GetOldestMember()
        {
            return _repository.GetMembers().OrderBy(m => Convert.ToDateTime(m.DateOfBirth)).FirstOrDefault();
        }
    }
}