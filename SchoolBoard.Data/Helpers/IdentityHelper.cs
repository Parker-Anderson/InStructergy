using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.Helpers
{
    public class IdentityHelper
    {
        public static void SeedIdentities(DbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string userName = "test@test.com";
            string password = "Test1!";
            ApplicationUser user = userManager.FindByName(userName);
            if(user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);
            
            }
        }
    }
}
