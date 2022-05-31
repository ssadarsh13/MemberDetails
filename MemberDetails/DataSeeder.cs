using MemberDetails.DataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberDetails
{
    public static class DataSeeder
    {
        public static void SeedMembers(MemberDBAPIContext context)
        {
            if (!context.Members.Any())
            {
                var members = new List<Member>
            {
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Adarsh" ,LastName="S S", Age=32,Gender="Male"},
               
            };
                context.AddRange(members);
                context.SaveChanges();
            }
        }

        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetService<MemberDBAPIContext>();

                SeedMembers(context);
            }
            return host;
        }
    }
}
