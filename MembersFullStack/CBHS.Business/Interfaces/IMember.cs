using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBHS.Business.Interfaces
{
    public interface IMember
    {
        int MemberId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string DateOfBirth { get; set; }

        int Add(IMember Member);
    }
}
