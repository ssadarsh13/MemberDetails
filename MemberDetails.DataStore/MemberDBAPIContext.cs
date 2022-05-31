using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDetails.DataStore
{
    public class MemberDBAPIContext : DbContext
    {
        public MemberDBAPIContext(DbContextOptions<MemberDBAPIContext> options)
            : base(options)
        { 
        }

        public DbSet<Member> Members { get; set; }

       
    }
}
