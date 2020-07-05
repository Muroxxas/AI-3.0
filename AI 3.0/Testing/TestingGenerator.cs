using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Factories;
using AI_3._0.Data_Classes;
using AI_3._0.Fitness;
namespace AI_3._0.Testing
{
    class TestingGenerator : IGenerator
    {
        IAbstractFactory abstractFactory;
        ICityFactory cityFactory;
        ISolutionFactory solutionFactory;
        IBreedingFactory breedingFactory;

        IBreeder breeder;
        IBestFit bestFit;
        int population;
        int cityCount;
        int generations;
        double mutationRate;
        int seed;
        Random rand;

        City[] cities;
        Solution[] generation;

        public void CreateCities()
        {

            City[] cities = new City[cityCount];
            StringBuilder sb = new StringBuilder(2);

            for (int city = 0; city < cityCount; city++)
            {
                if (city < 10)
                {
                    sb.Append($"0{city.ToString()}");
                    City newCity = cityFactory.CreateCity(sb.ToString());
                    cities[city] = newCity;
                    sb.Clear();
                }
                else
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
            CreateCities();
            breeder.SetSolutionUtils(breedingFactory.CreateSolutionUtils(cities));

            Solution[] initialGeneration = new Solution[population];
            StringBuilder sb = new StringBuilder();

            //Create object
            for (int i = 0; i < population; i++)
            {
                Solution solutionObj = CreateRandomSolution(rand);
                initialGeneration[i] = solutionObj;
            }

            this.generation = initialGeneration;
        }
        public void Generate()
        {

            IRouletteWheel rouletteWheel = breedingFactory.CreateRouletteWheel(generation, rand);
            breeder.SetRouletteWheel(rouletteWheel);
            breeder.CalcFitness(generation);

            Solution[] newGeneration = new Solution[population];


            for (int i = 0; i < population; i++)
            {

                newGeneration[i] = breeder.Breed();

            }
            generation = newGeneration;

        }
        public void CalcFitness()
        {
            //used for setting the fitness of the final generation, after the facade's generation loop finishes.
            breeder.CalcFitness(generation);
        }
        public Solution FindBestFit()
        {
            return bestFit.FindBestFit(generation);
        }

        private Solution CreateRandomSolution(Random rand)
        {
            string[] path = CreateRandomPath(rand);
            return solutionFactory.CreateSolution(path);
        }
        private string[] CreateRandomPath(Random rand)
        {
            string[] path = new string[cityCount + 1];
            StringBuilder sb = new StringBuilder();
            for (int location = 0; location <= cityCount; location++)
            {
                int cityVisited = rand.Next(0, cityCount);
                if (cityVisited < 10)
                {
                    sb.Append($"0{cityVisited.ToString()}");
                    path[location] = sb.ToString();
                    sb.Clear();
                }
                else
                {
                    sb.Append(cityVisited.ToString());
                    path[location] = sb.ToString();
                    sb.Clear();
                }
            }
            return path;
        }

        public TestingGenerator(int population, int cityCount, int generations, double mutationRate, int seed)
        {
            this.population = population;
            this.cityCount = cityCount;
            this.generations = generations;
            this.mutationRate = mutationRate;
            this.seed = seed;
            this.rand = new Random(seed);

            this.abstractFactory = new AbstractFactory();
            this.cityFactory = abstractFactory.CreateCityFactory(rand);
            this.breedingFactory = abstractFactory.CreateBreedingFactory();
            ISolutionFactory solutionFactory = abstractFactory.CreateSolutionFactory();

            IMutater mutater = breedingFactory.CreateMutater(mutationRate, rand);
            this.solutionFactory = solutionFactory;
            this.bestFit = new BestFit();

            this.breeder = breedingFactory.CreateBreeder(mutater, solutionFactory, rand);

        }

    }
}
