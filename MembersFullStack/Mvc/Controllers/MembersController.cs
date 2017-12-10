using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBHS.Mvc.Controllers
{
    using System.Configuration;
    using System.Net;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Models;

    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            var url = ConfigurationManager.AppSettings["apiUrl"];

            var client = new WebClient();

            var json = client.DownloadString($"{url}/members");

            var listOfMembers = JsonConvert.DeserializeObject<List<MemberMvcModel>>(json);

            //var membersController = new CBHS.Webapi.Controllers.MembersController(memberMvc);
            //var listOfMembers = membersController.List();

            //ViewBag.Members = listOfMembers;
            ViewBag.oldestMember = listOfMembers.OrderBy(m => Convert.ToDateTime(m.DateOfBirth)).FirstOrDefault();

            return View(listOfMembers);
        }

        public ActionResult Add(FormCollection collection)
        {
            var memberModelMvc = new MemberMvcModel()
            {
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                Email = collection["Email"],
                DateOfBirth = collection["DateOfBirth"]
            };



            //var membersController = new CBHS.Webapi.Controllers.MembersController(memberMvc);
            //membersController.Add(memberMvc);
            var url = ConfigurationManager.AppSettings["apiUrl"];

            var client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //.Add("Accept: application/json");
            //client.Headers.Add("ContentType: application/json");
            
            var jsonStringMvcModel = JsonConvert.SerializeObject(memberModelMvc);

            var json = client.UploadString($"{url}/members", jsonStringMvcModel);

            return RedirectToAction("Index");
        }        
    }
}