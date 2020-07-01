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
            //TBI
            return solution;
        }

        public Mutater(double mutationRate)
        {
            this.mutationRate = mutationRate;
        }
    }
}
