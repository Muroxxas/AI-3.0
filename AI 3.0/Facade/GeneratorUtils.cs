using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Breeding;
using AI_3._0.Factories
namespace AI_3._0.Facade
{
    class GeneratorUtils
    {
        IAbstractFactory abstractFactory;
        IBreeder breeder;
        int population;
        int cityCount;
        int generations;
        double mutationRate;


        public GeneratorUtils(int population, int cityCount, int generations, double mutationRate)
        {
            this.population = population;
            this.cityCount = cityCount;
            this.generations = generations;
            this.mutationRate = mutationRate;

            this.abstractFactory = new AbstractFactory();
            IBreedingFactory breedingFactory= abstractFactory.CreateBreedingFactory();

            IRouletteWheel rouletteWheel = breedingFactory.CreateRouletteWheel();
            ISolutionUtils solutionUtils = breedingFactory.CreateSolutionUtils();
            IMutater mutater = breedingFactory.CreateMutater();
            ISolutionFactory solutionFactory = abstractFactory.CreateSolutionFactory();

            this.breeder = new Breeder(rouletteWheel, solutionUtils, mutater, solutionFactory);
        }


    }
}
