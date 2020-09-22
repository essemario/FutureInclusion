using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureInclusion.Web.ResponseObjects
{
    public class PollRO
    {
        public uint pollId;
        public string title;
        public string description;
        public bool voted;
        public List<ChoiceRO> choices;
        public int totalVotes;
    }
}
