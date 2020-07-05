using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Facade;
using AI_3._0.Data_Classes;
using AI_3._0.Interfaces;
namespace AI_3._0.Testing
{
    class TestingFacade : IFacade
    {

        IGenerator generator;

        public void Generate(int population, int generations, int cityCount, double mutationRate, int seed)
        {
            generator = new TestingGenerator(population, cityCount, generations, mutationRate, seed);

            generator.CreateInitialGeneration();

            for (int i = 1; i <= generations; i++)
            {
                Console.WriteLine($"Generation {i} created!");
                generator.Generate();
            }
            generator.CalcFitness();
            Console.ReadLine();
        }

        public Solution GetBestFit()
        {

            return generator.FindBestFit();
        }

        public TestingFacade() { }

    }
}
