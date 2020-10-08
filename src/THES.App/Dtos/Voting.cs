using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THES.App.Dtos
{
    public class Voting
    {
        public int ElectionId { get; set; }
        public List<PublicVote> PublicVotes { get; set; }
        public List<JudgeVote> JudgeVotes { get; set; }

    }
    public class PublicVote
    {
        public int CandidateId { get; set; }
        public int Votes { get; set; }
    }

    public class JudgeVote
    {
        public int JudgeId { get; set; }
        public int CandidateId { get; set; }
        public int Category { get; set; }
        public int Order { get; set; }
    }
}
