using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using CodedHomes.Models;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializer :
        DropCreateDatabaseIfModelChanges<DataContext>
        //CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            string[] descriptions = new string[10] { 
                "Nice neighborhood with friendly neighbors.",
                "A truly beautiful home!",
                "In a cul-de-dac on a quiet street.",
                "Freeway accessible with a huge green lawn.",
                "Lots of storage and big bedrooms.",
                "Well-kept by previous owners.",
                "Includes pool, spa and basketball hoop.",
                "The back fence needs some work, but the house is in great condition.",
                "Includes a huge bonus room great for an office or playroom.",
                "Close to local magnet schools."
            };

            int count = 10;
            while ((count--) != 0)
            {
                Home home = new Home();
                home.StreetAddress = string.Format("12{0} Street St.", count);
                home.City = "Anytown";
                home.ZipCode = 90210;
                home.Bedrooms = ((count % 2) == 1) ? 4 : 3;
                home.Bathrooms = (home.Bedrooms - 2);
                home.SquareFeet = 3700 + count;
                home.Price = 275000 + (count * 1000);
                home.ImageName = string.Format("home-{0}.jpg", ((count % 2) == 1) ? 2 : 1);
                home.Description = descriptions[count];
                context.Homes.Add(home);
            }
            // */

            Role admin = new Role();
            admin.RoleName = "admin";
            context.Roles.Add(admin);

            Role mgr = new Role();
            mgr.RoleName = "manager";
            context.Roles.Add(mgr);

            Role usr = new Role();
            usr.RoleName = "user";
            context.Roles.Add(usr);

            base.Seed(context);
        }
    }
}
