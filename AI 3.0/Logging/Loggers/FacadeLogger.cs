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
    class FacadeLogger : IFacadeLogger
    {
        public void logGenNumber(StreamWriter writer, int genNumber)
        {
            writer.WriteLine($"Generation {genNumber} ---------------");
        }
    }
}
