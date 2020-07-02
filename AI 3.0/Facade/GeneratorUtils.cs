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
    class GeneratorUtils : IGeneratorUtils
    {
        IAbstractFactory abstractFactory;
        IBreeder breeder;
        ICityFactory cityFactory;
        ISolutionFactory solutionFactory;
        IBreedingFactory breedingFactory;

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
            CreateCities();
            breeder.SetSolutionUtils( breedingFactory.CreateSolutionUtils(cities) );

            Solution[] initialGeneration = new Solution[population];
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            string[] path = new string[population + 1];


            //Create object
            for (int i =0; i < population; i++)
            {
                path = new string[cityCount + 1];
                // create path string
                for (int location =0; location <= cityCount; location++)
                {
                    int cityVisited = rand.Next(0, cityCount);
                    if (cityVisited < 10)
                    {
                        sb.Append($"0{cityVisited.ToString()}");
                        path[location]= sb.ToString();
                        sb.Clear();
                    }
                    else {
                        sb.Append(cityVisited.ToString());
                        path[location] = sb.ToString();
                        sb.Clear();
                    }

                    
                }
                Solution solutionObj = solutionFactory.CreateSolution(path);
                initialGeneration[i] = solutionObj;
            }

            this.generation = initialGeneration;
        }

        public void Generate()
        {

            IRouletteWheel rouletteWheel = breedingFactory.CreateRouletteWheel(generation);
            breeder.SetRouletteWheel(rouletteWheel);
            breeder.CalcFitness(generation);

            Solution[] newGeneration = new Solution[population];


            for (int i =0; i <= population; i++)
            {
                Console.WriteLine($"child {i} created!");
                newGeneration[i] = breeder.Breed();
            }
            generation = newGeneration;

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
            this.breedingFactory= abstractFactory.CreateBreedingFactory();
            ISolutionFactory solutionFactory = abstractFactory.CreateSolutionFactory();

            IMutater mutater = breedingFactory.CreateMutater(mutationRate);
            this.solutionFactory = solutionFactory;

            this.breeder = breedingFactory.CreateBreeder( mutater, solutionFactory);
            
        }

    }
}
