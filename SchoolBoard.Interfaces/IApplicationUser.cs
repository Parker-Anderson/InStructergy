using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAllUsers();

        Task SetProfileImage(string id, Uri uri);
        // TODO add Tasks for administrative functions here.
    }
}
