using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Business
{
    using Interfaces;

    public class Member : IMember
    {
        public int MemberId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public int Add(IMember Member)
        {
            return 0;
        }
    }
}
