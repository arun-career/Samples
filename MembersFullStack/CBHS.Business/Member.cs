using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Business
{
    using Interfaces;
    using Datasource;

    public class Member : IMember
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public bool Add(IMember Member)
        {
            var databaseMember = new CBHS.Datasource.Member
            {
                FirstName = Member.FirstName,
                LastName = Member.LastName,
                Email = Member.Email,
                DateOfBirth = Member.DateOfBirth
            };

            return Data.AddMember(databaseMember);
        }

        public IList<IMember> List()
        {
            var listOfDataMembers = Data.GetMembers();

            var listOfMembers = listOfDataMembers.ConvertAll(m => new Member
            {
                MemberId = m.MemberId,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                DateOfBirth = m.DateOfBirth
            });

            return listOfMembers.ToList<IMember>();
        }
    }
}
