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
            string email = "smith@email.com";
            string password = "Test1!";
            string name = "Mrs. Smith";
            ApplicationUser user = userManager.FindByEmail(email);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = name,
                    Name = name,
                    Email = email,
                    EmailConfirmed = true

                };
                IdentityResult userResult = userManager.Create(user, password);
            };

        }
    }
}
