using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CBHS.Mvc.Controllers
{
    using System.Configuration;
    using System.Net;
    using Newtonsoft.Json;
    using Models;
    using System.Threading.Tasks;

    public class MembersController : Controller
    {
        // GET: Members
        public async Task<ActionResult> Index()
        {
            var url = ConfigurationManager.AppSettings["apiUrl"];

            var client = new WebClient();

            var jsonMembers = await client.DownloadStringTaskAsync($"{url}/members");

            var membersList = JsonConvert.DeserializeObject<List<MemberListModel>>(jsonMembers);

            var jsonOldest = await client.DownloadStringTaskAsync($"{url}/members/oldest");

            var oldestMember = JsonConvert.DeserializeObject<MemberListModel>(jsonOldest);

            if (oldestMember != null)
            {
                oldestMember.Age = (DateTime.Today - Convert.ToDateTime(oldestMember.DateOfBirth)).Days / 365;
            }

            var memberModelMvc = new MemberMvcModel()
            {
                MembersList = membersList,

                OldestMember = oldestMember
            };

            return View("Index", memberModelMvc);
        }

        [HttpPost]
        public ActionResult Add(MemberMvcModel memberMvcModel)
        {
            if (ModelState.IsValid)
            {
                var memberModelMvc = new MemberMvcModel()
                {
                    FirstName = memberMvcModel.FirstName,
                    LastName = memberMvcModel.LastName,
                    Email = memberMvcModel.Email,
                    DateOfBirth = memberMvcModel.DateOfBirth
                };

                var url = ConfigurationManager.AppSettings["apiUrl"];

                var client = new WebClient();

                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var jsonStringMvcModel = JsonConvert.SerializeObject(memberModelMvc);

                var json = client.UploadString($"{url}/members", jsonStringMvcModel);

            }

            return RedirectToAction("Index");
        }
    }
}