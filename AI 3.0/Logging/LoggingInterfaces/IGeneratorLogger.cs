using AI_3._0.Data_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AI_3._0.Logging.LoggingInterfaces
{
    interface IGeneratorLogger
    {

        void logBestFitSolution(StreamWriter writer, Solution solution);
    }
}
