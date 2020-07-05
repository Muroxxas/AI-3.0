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
        public IBreeder CreateBreeder(IMutater mutater, ISolutionFactory solutionFactory)
        {
            return new Breeder(mutater, solutionFactory);
        }
        public IBreeder CreateBreeder( IMutater mutater, ISolutionFactory solutionFactory, int seed)
        {
            return new Breeder( mutater, solutionFactory, seed);
        }
        public IBreeder CreateBreeder(IMutater mutater, ISolutionFactory solutionFactory, Random rand)
        {
            return new Breeder(mutater, solutionFactory, rand);
        }

        public IMutater CreateMutater(double mutationRate)
        {
            return new Mutater(mutationRate);
        }
        public IMutater CreateMutater(double mutationRate, int seed)
        {
            return new Mutater(mutationRate, seed);
        }
        public IMutater CreateMutater(double mutationRate, Random rand)
        {
            return new Mutater(mutationRate, rand);
        }


        public IRouletteWheel CreateRouletteWheel(Solution[] generation)
        {
            return new TestingRouletteWheel(generation);
        }
        public IRouletteWheel CreateRouletteWheel(Solution[] generation, int seed)
        {
            return new TestingRouletteWheel(generation, seed);
        }
        public IRouletteWheel CreateRouletteWheel(Solution[] generation, Random rand)
        {
            return new TestingRouletteWheel(generation, rand);
        }

        public ISolutionUtils CreateSolutionUtils(City[] cities)
        {
            return new TestingSolutionUtils(cities);
        }

        public BreedingFactory() { }

    }
}
