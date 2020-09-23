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
    public class PerfilPoliticoController : ControllerBase
    {
        private readonly MySQLContext _context;

        public PerfilPoliticoController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/PerfilPolitico
        [HttpGet("{id}")]
        public async Task<ActionResult<PoliticProfileRO>> GetUser(uint id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            User user = await _context.User.Include(m => m.Mandate).FirstOrDefaultAsync(i => i.Id == id);
            int followersCount = _context.MandateVoter.Where(x => x.MandatesId == user.MandateId).Count();

            PoliticProfileRO polProfile = new PoliticProfileRO
            {
                id = user.Id,
                name = user.Name + " " + user.LastName,
                mandateName = user.Mandate.Title,
                followers = followersCount
            };
            return polProfile;
        }

        private bool UserExists(uint id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
