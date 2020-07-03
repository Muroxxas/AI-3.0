using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_3._0.Data_Classes
{
    class Solution
    {

        public Guid id { get; set; }
        public String[] path { get; set; }

        public int distance { get; set; }

        public int score { get; set; }

        public Solution(String[] solution)
        {
            this.path = solution;
        }

        public Solution(string[] path, Guid id)
        {
            this.path = path;
            this.id = id;
        }

    }
}
