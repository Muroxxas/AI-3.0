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
        ISolutionFactory solutionFactory;

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
                if (city < 10)
                {
                    sb.Append( $"0{city.ToString()}") ;
                    City newCity = cityFactory.CreateCity(sb.ToString());
                    cities[city] = newCity;
                    sb.Clear();
                } else
                {
                    sb.Append(city.ToString());
                    City newCity = cityFactory.CreateCity(sb.ToString());
                    cities[city] = newCity;
                    sb.Clear();

                }
            }
            this.cities = cities;
        }
        public void CreateInitialGeneration()
        {
            Solution[] initialGeneration = new Solution[population];
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            string[] solution = new string[population + 1];

            for (int i =0; i < population; i++)
            {
                //create pseudorandom solution object, append to initialGeneration
                for (int city =0; city <= cityCount; city++)
                {
                    solution = new string[cityCount + 1];
                    int cityVisited = rand.Next(0, cityCount);
                    if (cityVisited < 10)
                    {
                        sb.Append($"0{city.ToString()}");
                        solution[city] = sb.ToString();
                        sb.Clear();
                    }
                    else {
                        sb.Append(city.ToString());
                        solution[city] = sb.ToString();
                        sb.Clear();
                    }

                    Solution solutionObj = solutionFactory.CreateSolution(solution);
                    initialGeneration[i] = solutionObj;
                }
            }

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
            this.solutionFactory = solutionFactory;

            this.breeder = new Breeder(rouletteWheel, solutionUtils, mutater, solutionFactory);
            
        }


    }
}
