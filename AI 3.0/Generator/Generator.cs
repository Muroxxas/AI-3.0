using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Factories;
using AI_3._0.Data_Classes;
using AI_3._0.Fitness;
namespace AI_3._0.Facade
{
    class Generator : IGenerator
    {
        IAbstractFactory abstractFactory;
        ICityFactory cityFactory;
        ISolutionFactory solutionFactory;
        IBreedingFactory breedingFactory;
        ISolutionUtils solutionUtils;

        IBreeder breeder;
        IBestFit bestFit;
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
            InitialGenerationSetup();

            Solution[] initialGeneration = new Solution[population];
            Random rand = new Random();

            for (int i =0; i < population; i++)
            {
                initialGeneration[i] = CreateRandomSolution(rand);
            }

            this.generation = initialGeneration;
        }
        public void Generate()
        {

            SuccessiveGenerationSetup();

            Solution[] newGeneration = new Solution[population];


            for (int i =0; i < population; i++)
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


        private void InitialGenerationSetup()
        {
            CreateCities();
            solutionUtils = breedingFactory.CreateSolutionUtils(cities);
            breeder.SetSolutionUtils(solutionUtils);

        }
        private void SuccessiveGenerationSetup()
        {
            IRouletteWheel rouletteWheel = breedingFactory.CreateRouletteWheel(generation, solutionUtils);
            breeder.SetRouletteWheel(rouletteWheel);
            breeder.CalcFitness(generation);
        }


        private string[] CreateRandomPath(Random rand)
        {
            string[] path = new string[population + 1];

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
        private Solution CreateRandomSolution (Random rand)
        {
            string[] path = CreateRandomPath(rand);
            return solutionFactory.CreateSolution(path);
        }
        public Generator(int population, int cityCount, int generations, double mutationRate, int seed)
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
            this.bestFit = new BestFit();

            this.breeder = breedingFactory.CreateBreeder( mutater, solutionFactory);
            
        }

    }
}
