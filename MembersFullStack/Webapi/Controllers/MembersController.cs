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
        public bool Add(IMember member)
        {
            //throw new NotImplementedException();
        
            return Member.Add(member);
        }

        [HttpPost]
        [Route("Members")]
        public IList<IMember>  List()
        {
            var listOfMembers = Member.List(); ;

            return listOfMembers;
        }
    }
}