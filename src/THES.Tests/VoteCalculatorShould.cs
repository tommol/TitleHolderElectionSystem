using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using THES.App.Dtos;
using THES.App.Services;
using Xunit;

namespace THES.Tests
{
    public class VoteCalculatorShould
    {
        private readonly IVotesCalculator calculator;
        public VoteCalculatorShould()
        {
            calculator = new VotesCalculator();
        }
        [Fact]
        public void Test1()
        {
            var result = calculator.CalculatePublicPoints(4, new List<PublicVote>()
            {
                new PublicVote(){ CandidateId = 1, Votes = 58},
                new PublicVote(){CandidateId =2, Votes=42},
                new PublicVote(){CandidateId =3, Votes =52},
                new PublicVote(){CandidateId = 4, Votes=48}
            });

            result.Sum(x => x.Value).Should().Be(40);
           

        }
    }
}
