using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THES.App.Models
{
    public class Election
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual IList<Candidate> Candidates { get; set; }


    }
}
