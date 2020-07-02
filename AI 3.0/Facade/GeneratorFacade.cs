using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Facade;
namespace AI_3._0.Facade
{
    class GeneratorFacade
    {



        public void Generate(int population, int generations, int cityCount, double mutationRate, int seed)
        {
            GeneratorUtils generatorUtils = new GeneratorUtils(population, cityCount, generations, mutationRate, seed);

            generatorUtils.CreateInitialGeneration();

            for(int i=1; i <= generations; i++)
            {
                Console.WriteLine($"Generation {i} created!");
                generatorUtils.Generate();
            }

            Console.WriteLine($"Generation complete!");
        }


        public GeneratorFacade() { }
        
    }
}
