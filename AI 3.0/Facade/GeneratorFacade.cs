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


        }

        GeneratorFacade() { }
        
    }
}
