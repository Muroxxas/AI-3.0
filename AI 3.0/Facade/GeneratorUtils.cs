using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Breeding;
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
            this.breeder = new Breeder();
        }


    }
}
