using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDetails.DataStore
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDBAPIContext _memberDbContext;

        public MemberRepository(MemberDBAPIContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }
        public async Task<Member> AddMember(Member member)
        {
            var result = await _memberDbContext.Members.AddAsync(member);
            await _memberDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Member> DeleteMember(string memberId)
        {
            var result = await _memberDbContext.Members
                .FirstOrDefaultAsync(e => e.Id == memberId);
            if (result != null)
            {
                _memberDbContext.Members.Remove(result);
                await _memberDbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Member> GetMember(string memberId)
        {
            return await _memberDbContext.Members
                .FirstOrDefaultAsync(e => e.Id == memberId);
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberDbContext.Members.ToListAsync();
        }

        public async  Task<Member> UpdatMember(Member member)
        {
            var result = await _memberDbContext.Members
                .FirstOrDefaultAsync(e => e.Id == member.Id);

            if (result != null)
            {
                result.FirstName = member.FirstName;
                result.LastName = member.LastName;
                result.MiddleName = member.MiddleName;
                result.Age = member.Age;
                result.Gender = member.Gender;
                await _memberDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
