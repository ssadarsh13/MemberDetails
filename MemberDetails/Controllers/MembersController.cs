using MemberDetails.DataStore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberrepository ;
        public MembersController(IMemberRepository memberrepository)
        {
            _memberrepository = memberrepository;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = await _memberrepository.GetMembers();
            return Ok(members);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(string id)
        {
            var member = await _memberrepository.GetMember(id);
            return Ok(member);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult<Member>> Post([FromBody] Member member)
        {
            member.Id = Guid.NewGuid().ToString();
            var memberAdded = await _memberrepository.AddMember(member);
            return Ok(memberAdded);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> Put(string id, [FromBody] Member member)
        {
            member.Id = id;
            var memberAdded = await _memberrepository.UpdatMember(member);
            return Ok(memberAdded);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> Delete(string id)
        {
            var member =  await _memberrepository.DeleteMember(id);
            return Ok(member);
        }
    }
}
