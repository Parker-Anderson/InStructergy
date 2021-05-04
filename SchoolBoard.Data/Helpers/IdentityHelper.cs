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
                    UserName = email,
                    FullName = name,
                    Email = email,
                    EmailConfirmed = true

                };
                IdentityResult userResult = userManager.Create(user, password);
            };
          
            string email1 = "robinson@email.com";
            string password1 = "Test1!";
            string name1 = "Mrs. Robinson";
            ApplicationUser user1 = userManager.FindByEmail(email1);

            if (user1 == null)
            {
                user1 = new ApplicationUser()
                {
                    UserName = email1,
                    FullName = name1,
                    Email = email1,
                    EmailConfirmed = true

                };
                IdentityResult userResult = userManager.Create(user1, password1);
            };
            
            string email2 = "Jones@email.com";
            string password2 = "Test1!";
            string name2 = "Mr. Jones";
            ApplicationUser user2 = userManager.FindByEmail(email2);

            if (user2 == null)
            {
                user2 = new ApplicationUser()
                {
                    UserName = email2,
                    FullName = name2,
                    Email = email2,
                    EmailConfirmed = true

                };
                IdentityResult userResult = userManager.Create(user2, password2);
            };
        
            string email3 = "smith@email.com";
            string password3 = "Test1!";
            string name3 = "Mr. Joyce";
            ApplicationUser user3 = userManager.FindByEmail(email3);

            if (user3 == null)
            {
                user3 = new ApplicationUser()
                {
                    UserName = email3,
                    FullName = name3,
                    Email = email3,
                    EmailConfirmed = true

                };
                IdentityResult userResult = userManager.Create(user3, password3);
            };

        }
    }
}
