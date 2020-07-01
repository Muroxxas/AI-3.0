using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Factories
{
    class SolutionFactory : ISolutionFactory
    {

        public Solution CreateSolution(string[] solution)
        {
            return new Solution(solution);
        }

        public Solution CreateSolution()
        {
            return new Solution();
        }
    }
}
