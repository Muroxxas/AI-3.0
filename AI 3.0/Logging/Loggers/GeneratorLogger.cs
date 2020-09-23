using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AI_3._0.Data_Classes;
using AI_3._0.Logging.LoggingInterfaces;
namespace AI_3._0.Logging.Loggers
{
    class GeneratorLogger : IGeneratorLogger
    {
        public void logBestFitSolution(StreamWriter writer, Solution solution)
        {
            writer.WriteLine($"ID : {solution.id}");
            writer.WriteLine($"Distance : {solution.distance}");
            string path = string.Join(" ", solution.path);
            writer.WriteLine($"Path : {path}");
        }
    }
}
