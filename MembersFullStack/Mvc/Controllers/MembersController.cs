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
            if (ViewBag.Members!=null)
            {
                ViewBag.Members = new List<IMember>();
            }
            return View();
        }

        public ActionResult Add(FormCollection collection)
        {
            IMember memberMvc = new Member
            {
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                Email = collection["Email"],
                DateOfBirth = collection["DateOfBirth"]
            };

            var membersController = new CBHS.Webapi.Controllers.MembersController(memberMvc);
            membersController.Add(memberMvc);

            var listOfMembers = membersController.List();

            ViewBag.Members = listOfMembers;
            ViewBag.oldestMember = listOfMembers.OrderBy(m => Convert.ToDateTime(m.DateOfBirth)).FirstOrDefault();

            return View("Index");
        }
    }
}