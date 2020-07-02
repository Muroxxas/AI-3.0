using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Facade;
namespace AI_3._0.UI
{
    class Ui
    {
        GeneratorFacade generator = new GeneratorFacade();

        int population;
        int cityCount;
        int generations;
        double mutationRate;
        int seed;


        public void Run()
        {

            bool confirm = false;
            while (confirm == false)
            {
                Console.WriteLine("Please Enter the number of cities the salesman will visit");
                cityCount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter the number of solutions per generation");
                population = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the total number of generations to create");
                generations = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter, in decimal format, the mutation rate.");
                mutationRate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter a seed value");
                seed = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine($"The salesman will visit {cityCount} cities.");
                Console.WriteLine($"The location of these cities will be generated with the seed value {seed}.");
                Console.WriteLine($"There will be {population} solutions generated, and {generations} generations overall. ");
                Console.WriteLine($"This will cause a total of {population * generations} solution objects to be created.");
                Console.WriteLine($"{mutationRate * 100}% of solution objects generated after the initial generation will be mutated.");

                Console.WriteLine();
                Console.WriteLine($"Do you wish to proceed? [Y/N]");
                if(Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                {
                    confirm = true;
                }
            }
            generator.Generate(population, cityCount, generations, mutationRate, seed);
        }
        

        public Ui() { }
    }
}
