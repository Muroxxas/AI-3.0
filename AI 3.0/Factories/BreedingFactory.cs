using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Breeding;
using AI_3._0.Data_Classes;
using AI_3._0.Testing;
namespace AI_3._0.Factories
{
    class BreedingFactory : IBreedingFactory
    {

        public IBreeder CreateBreeder( IMutater mutater, ISolutionFactory solutionFactory)
        {
            return new Breeder( mutater, solutionFactory);
        }
        public IMutater CreateMutater(double mutationRate)
        {
            return new Mutater(mutationRate);
        }
        public IRouletteWheel CreateRouletteWheel(Solution[] generation, ISolutionUtils solutionUtils)
        {
            return new TestingRouletteWheel(generation, solutionUtils);
        }
        public ISolutionUtils CreateSolutionUtils(City[] cities)
        {
            return new TestingSolutionUtils(cities);
        }

        public BreedingFactory() { }

    }
}
