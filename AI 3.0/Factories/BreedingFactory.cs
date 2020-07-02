using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Breeding;
using AI_3._0.Data_Classes;
namespace AI_3._0.Factories
{
    class BreedingFactory : IBreedingFactory
    {

        public IBreeder CreateBreeder(ISolutionUtils solutionUtils, IMutater mutater, ISolutionFactory solutionFactory)
        {
            return new Breeder(solutionUtils, mutater, solutionFactory);
        }
        public IMutater CreateMutater(double mutationRate)
        {
            return new Mutater(mutationRate);
        }
        public IRouletteWheel CreateRouletteWheel()
        {
            return new RouletteWheel();
        }
        public IRouletteWheel CreateRouletteWheel(Solution[] generation)
        {
            return new RouletteWheel(generation);
        }
        public ISolutionUtils CreateSolutionUtils()
        {
            return new SolutionUtils();
        }

        public BreedingFactory() { }

    }
}
