using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBHS.Mvc.Controllers
{
    using CBHS.Business.Interfaces;
    using CBHS.Business;
    using CBHS.Webapi.Controllers;

    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            GetMembersInfo();
            return View();
        }

        public ActionResult Add(FormCollection collection)
        {
            var memberMvc = new Member
            {
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                Email = collection["Email"],
                DateOfBirth = collection["DateOfBirth"]
            };

            var membersController = new CBHS.Webapi.Controllers.MembersController(memberMvc);
            membersController.Add(memberMvc);

            GetMembersInfo();

            return View("Index");
        }

        private void GetMembersInfo()
        {
            var memberMvc = new Member();

            var membersController = new CBHS.Webapi.Controllers.MembersController(memberMvc);
            var listOfMembers = membersController.List();

            ViewBag.Members = listOfMembers;
            ViewBag.oldestMember = listOfMembers.OrderBy(m => Convert.ToDateTime(m.DateOfBirth)).FirstOrDefault();
        }
    }
}