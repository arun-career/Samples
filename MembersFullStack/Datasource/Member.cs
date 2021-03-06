namespace CBHS.Datasource
{
    using System.ComponentModel.DataAnnotations;

    public partial class Member
    {
        public int MemberId { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string DateOfBirth { get; set; }
    }
}
