
using System.ComponentModel.DataAnnotations;

namespace CBHS.Webapi.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [StringLength(10)]
        public string DateOfBirth { get; set; }
    }
}