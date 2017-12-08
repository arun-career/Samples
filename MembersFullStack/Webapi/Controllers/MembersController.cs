using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CBHS.Webapi.Controllers
{
    using CBHS.Business.Interfaces;
    using CBHS.Datasource;

    public class MembersController : ApiController
    {

        #region Properties

        private IMember Member { get; set; }
        
        #endregion

        public MembersController(IMember member)
        {
            Member = member;
        }

        //POST: Member
        [HttpPost]
        [Route("members")]
        public int Add(IMember member)
        {
            //throw new NotImplementedException();
            //Data.AddMember(member);

            var databaseMember = new Member()
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                DateOfBirth = member.DateOfBirth
            };

            var memberId = Data.AddMember(databaseMember);

            return memberId;
        }

        [HttpPost]
        [Route("Members")]
        public List<IMember>  List()
        {
            var listOfDataMembers = Data.GetMembers();

            var listOfMembers = listOfDataMembers.ConvertAll(m => new Business.Member
                                        {
                                        MemberId = m.MemberId,
                                        FirstName =m.FirstName,
                                        LastName = m.LastName,
                                        Email = m.Email,
                                        DateOfBirth = m.DateOfBirth
                                        });

            return listOfMembers.ToList<IMember>();
        }
    }
}