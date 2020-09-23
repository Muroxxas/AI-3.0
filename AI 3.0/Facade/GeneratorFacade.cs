using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Facade;
using AI_3._0.Data_Classes;
using AI_3._0.Logging.Loggers;
using AI_3._0.Logging.LoggingInterfaces;
using AI_3._0.Interfaces;
using System.IO;


namespace AI_3._0.Facade
{
    class GeneratorFacade
    {

        Generator generator;
        StreamWriter writer;
        IFacadeLogger logger;

        public void Generate(int population, int generations, int cityCount, double mutationRate, int seed)
        {
            generator = new Generator(population, cityCount, generations, mutationRate, seed);

            generator.SetWriter(writer);
            generator.CreateInitialGeneration();

            using (writer)
            {
                for (int i = 1; i <= generations; i++)
                {

                    Console.WriteLine($"Generation {i} created!");
                    logger.logGenNumber(writer, i);
                    generator.Generate();

                }
                generator.CalcFitness();
            }
            Console.ReadLine();
        }

        public Solution GetBestFit()
        {

            return generator.FindBestFit();
        }

        public GeneratorFacade() 
        {
            this.logger = new FacadeLogger();
            DateTime dateAndTime = DateTime.Now;
            string date_str = dateAndTime.ToString("ddMMyyyy HHmmss") + ".txt";
            this.writer = new StreamWriter($"LOG {date_str}");
        }

    }
}
