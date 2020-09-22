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
    public class FeedController : ControllerBase
    {
        private readonly MySQLContext _context;

        public FeedController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Feed --> DEVOLVE TODAS AS POLLS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollRO>>> GetPoll()
        {
            List<Poll> pesquisas = await _context.Poll.Include(b => b.Choice).ToListAsync();
            List<PollRO> polls = new List<PollRO>();
            foreach (Poll pesquisa in pesquisas)
            {
                PollRO temp = new PollRO
                {
                    pollId = pesquisa.Id,
                    title = pesquisa.Name,
                    description = pesquisa.Description,
                    choices = new List<ChoiceRO>(),
                    voted = false,
                    totalVotes = 0
                };
                foreach(Choice escolha in pesquisa.Choice)
                {
                    ChoiceRO choiceTemp = new ChoiceRO
                    {
                        id = escolha.Id,
                        text = escolha.Text,
                        votes = _context.VoterChoice.Where(x => x.ChoicesId == escolha.Id).Count()
                    };
                    temp.totalVotes += choiceTemp.votes;
                    temp.choices.Add(choiceTemp);
                }
                polls.Add(temp);
            }
            return polls;
        }

        // GET: api/Feed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PollRO>>> GetPoll(uint id)
        {
            List<Poll> pesquisas = await _context.Poll.Include(b => b.Choice).ToListAsync();
            List<PollRO> polls = new List<PollRO>();
            foreach (Poll pesquisa in pesquisas)
            {
                PollRO temp = new PollRO
                {
                    pollId = pesquisa.Id,
                    title = pesquisa.Name,
                    description = pesquisa.Description,
                    choices = new List<ChoiceRO>(),
                    voted = false,
                    totalVotes = 0
                };
                foreach (Choice escolha in pesquisa.Choice)
                {
                    ChoiceRO choiceTemp = new ChoiceRO
                    {
                        id = escolha.Id,
                        text = escolha.Text,
                        votes = _context.VoterChoice.Where(x => x.ChoicesId == escolha.Id).Count()
                    };
                    temp.voted = (_context.VoterChoice.Where(x => x.VotersId == id).Count() > 0);
                    temp.totalVotes += choiceTemp.votes;
                    temp.choices.Add(choiceTemp);
                }
                polls.Add(temp);
            }
            return polls;
        }
    }
}
