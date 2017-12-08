using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

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

            return 0;
        }
    }
}