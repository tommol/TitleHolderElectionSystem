using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THES.App.Dtos;
using THES.App.Models;

namespace THES.App.Services
{
    public class VotesCalculator : IVotesCalculator
    {
        public Results Calculate(Election election, Voting voting)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int,decimal> CalculatePublicPoints(int totalCandidates, List<PublicVote> publicVotes)
        {
            int maxPoints = CalculateTotalAvailablePoints(totalCandidates);
            List<(int,decimal, decimal)> factors = CalculateFactors(publicVotes, maxPoints);
            var result = new Dictionary<int, decimal>();
            foreach(var factor in factors)
            {
                result.Add(factor.Item1, factor.Item2);
            }
            var leftPoints = maxPoints - result.Sum(x => x.Value);
            var withAdditional = factors.OrderByDescending(x => x.Item3).Take((int)leftPoints).Select(x => x.Item1);
            foreach(var cand in withAdditional)
            {
                result[cand] += 1; 
            }
            return result;
        }

        private List<(int,decimal,decimal)>  CalculateFactors(List<PublicVote> publicVotes, int availablePoints)
        {
            decimal totalVotes = TotalVotes(publicVotes);
            return publicVotes
                .OrderBy(x => x.CandidateId)
                .Select(x => {
                    var f = (x.Votes * availablePoints) / totalVotes;
                    var i = Math.Floor(f);
                    return (x.CandidateId,i, f - i);
                }).ToList();
        }

        private decimal TotalVotes(List<PublicVote> publicVotes)
        {
            return publicVotes.Sum(x => x.Votes);
        }

        private static int CalculateTotalAvailablePoints(int totalCandidates)
        {
            int x = totalCandidates;
            int maxPoints = 0;
            while (x > 0)
            {
                maxPoints += x;
                x--;
            }
            maxPoints *= 4;
            return maxPoints;
        }
    }

    public interface IVotesCalculator
    {
        Results Calculate(Election election,Voting voting);
        Dictionary<int, decimal> CalculatePublicPoints(int totalCandidates, List<PublicVote> publicVotes);
    }

    public class Results
    {

    }
}
