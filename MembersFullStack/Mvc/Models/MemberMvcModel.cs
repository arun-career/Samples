using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBHS.Mvc.Models
{
    public class MemberMvcModel
    {        
        public int MemberId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Please input first name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input last name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth")]
        public string DateOfBirth { get; set; }

        public List<MemberListModel> MembersList { get; set; }

        public MemberListModel OldestMember { get; set; }
    }
}