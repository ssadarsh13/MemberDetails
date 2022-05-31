using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDetails.DataStore
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMember(string memberId);
        Task<Member> AddMember(Member member);
        Task<Member> UpdatMember(Member member);
        Task<Member> DeleteMember(string memberId);
    }
}
