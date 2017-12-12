using System.ComponentModel;

namespace CBHS.Web.Models
{
    public class MemberWebModel
    {
        [DisplayName("Member Id")]
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }
    }
}