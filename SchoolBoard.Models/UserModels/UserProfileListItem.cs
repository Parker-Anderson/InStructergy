using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.UserModels
{
    public class UserProfileListItem
    {
        //Thin wrapper for collection of UserProfileModel
        public IEnumerable<UserProfileModel> Profiles { get; set; }
    }
}
