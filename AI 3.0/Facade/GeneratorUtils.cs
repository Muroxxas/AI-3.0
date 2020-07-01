using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Breeding;
using AI_3._0.Factories;
using AI_3._0.Data_Classes;
namespace AI_3._0.Facade
{
    class GeneratorUtils
    {
        IAbstractFactory abstractFactory;
        IBreeder breeder;
        ICityFactory cityFactory;
        int population;
        int cityCount;
        int generations;
        double mutationRate;
        int seed;

        City[] cities;
        Solution[] generation;

        public void CreateCities() {

            City[] cities = new City[cityCount];
            StringBuilder sb = new StringBuilder(2);

            for (int city =0; city < cityCount; city++)
            {
                sb.Append("0");
                if (city < 10)
                {
                    sb.Append( city.ToString()) ;
                    City newCity = cityFactory.CreateCity(sb.ToString());
                    Cities[city] = newCity;
                    sb.Clear();
                } else
                {
                    sb.Clear();
                    sb.Append(city.ToString());
                    City newCity = cityFactory.CreateCity(sb.ToString());
                    Cities[city] = newCity;

                }
            }
            this.cities = cities;
        }
        public void CreateInitialGeneration()
        {
            Solution[] initialGeneration;



            this.generation = initialGeneration;
        }

        public GeneratorUtils(int population, int cityCount, int generations, double mutationRate, int seed)
        {
            this.population = population;
            this.cityCount = cityCount;
            this.generations = generations;
            this.mutationRate = mutationRate;
            this.seed = seed;

            this.abstractFactory = new AbstractFactory();

            this.cityFactory = abstractFactory.CreateCityFactory(this.seed);
            IBreedingFactory breedingFactory= abstractFactory.CreateBreedingFactory();

            IRouletteWheel rouletteWheel = breedingFactory.CreateRouletteWheel();
            ISolutionUtils solutionUtils = breedingFactory.CreateSolutionUtils();
            IMutater mutater = breedingFactory.CreateMutater();
            ISolutionFactory solutionFactory = abstractFactory.CreateSolutionFactory();

            this.breeder = new Breeder(rouletteWheel, solutionUtils, mutater, solutionFactory);
            
        }


    }
}
