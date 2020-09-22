using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FutureInclusion.DataAccessLayer.Models;
using FutureInclusion.Web.ResponseObjects;

namespace FutureInclusion.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilPessoalController : ControllerBase
    {
        private readonly MySQLContext _context;

        public PerfilPessoalController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/PerfilPessoal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalProfileRO>> GetVoter(uint id)
        {
            if (!VoterExists(id))
            {
                return NotFound();
            }

            Voter voter = await _context.Voter.Include(v => v.MandateVoter).Include(x => x.VoterChoice).FirstOrDefaultAsync(i => i.Id == id);

            PersonalProfileRO newProfile = new PersonalProfileRO
            {
                id = voter.Id,
                fullName = voter.Name + " " + voter.LastName,
                answers = voter.VoterChoice.Count(),
                following = voter.MandateVoter.Count()
            };

            return newProfile;
        }


        private bool VoterExists(uint id)
        {
            return _context.Voter.Any(e => e.Id == id);
        }
    }
}
