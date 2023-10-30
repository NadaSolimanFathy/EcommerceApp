using Core.Context;
using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class AppIdentityContextSeed
    {
        
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)

        {
            var nada = userManager.Users;
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Nada ",
                   Email = "nada@gmail.com",
                    UserName = "Nada Soliman",
                    Address = new Address
                    {
                        FirstName = "nada",
                        LastName = "soliman",
                        State = "Giza",
                        City = "6october",
                        Street = "10",
                        ZipCode = "29666"
                    }

                };  
                await userManager.CreateAsync(user,"Password123#");    
               
            }
        }
    }
}
