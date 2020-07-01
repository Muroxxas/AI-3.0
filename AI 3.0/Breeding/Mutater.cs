using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class Mutater : IMutater
    {
        double mutationRate;

        public Solution Mutate(Solution solution)
        {
            Random rand = new Random();
            if (rand.NextDouble() <= mutationRate)
            {

                int mutatePoint1 = rand.Next(0,solution.path.Length);
                int mutatePoint2 = rand.Next(1, solution.path.Length + 1);
                string[] mutatedPath = new string[solution.path.Length];
                string[] reversedPath = solution.path;
                reversedPath.Reverse();

                for (int iterator =0; iterator < mutatePoint1; iterator++)
                {
                    //Fill normally.
                    mutatedPath[iterator] = solution.path[iterator];

                }
                for (int iterator = mutatePoint1; iterator < mutatePoint2; iterator++)
                {
                    //fill in reverse.
                    mutatedPath[iterator] = reversedPath[iterator];
                }
                for (int iterator = mutatePoint2; iterator < solution.path.Length;) 
                {
                    //fill normally.
                    mutatedPath[iterator] = solution.path[iterator];
                }
                solution.path = mutatedPath;
            }
            return solution;
        }

        public Mutater() { }
        public Mutater(double mutationRate)
        {
            this.mutationRate = mutationRate;
        }
    }
}
