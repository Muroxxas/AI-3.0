using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
using System.IO;
namespace AI_3._0.Logging.LoggingInterfaces
{
    interface IFacadeLogger
    {
        void logGenNumber(StreamWriter writer, int genNumber);
    }
}
