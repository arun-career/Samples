using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CBHS.Web
{
    using System.Configuration;
    using Models;
    using Newtonsoft.Json;
    
    public partial class Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["apiUrl"];

            var client = new WebClient();

            var json = client.DownloadString($"{url}/members");

            var listOfMembers = JsonConvert.DeserializeObject<List<MemberWebModel>>(json);

            MembersGrid.DataSource = listOfMembers;
            MembersGrid.DataBind();

            var jsonOldest = client.DownloadString($"{url}/members/oldest");

            var oldestMember = JsonConvert.DeserializeObject<MemberWebModel>(jsonOldest);

            if (oldestMember != null)
            {
                oldestMemberLabel.Text = ((DateTime.Today - Convert.ToDateTime(oldestMember.DateOfBirth)).Days / 365).ToString() +
                                            ", " + oldestMember.FirstName + " " + oldestMember.LastName.ToString();
            }

            oldestMemberTable.Visible = true;

        }

        protected void addMember_Click(object sender, EventArgs e)
        {
            var memberModelWeb = new MemberWebModel()
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value,
                Email = Email.Value,
                DateOfBirth = DateOfBirth.Value
            };

            var url = ConfigurationManager.AppSettings["apiUrl"];

            var client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            var jsonStringMvcModel = JsonConvert.SerializeObject(memberModelWeb);

            var json = client.UploadString($"{url}/members", jsonStringMvcModel);
        }
    }
}