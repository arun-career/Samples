namespace CBHS.Datasource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
