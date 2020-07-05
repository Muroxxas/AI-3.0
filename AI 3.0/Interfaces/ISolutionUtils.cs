using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface ISolutionUtils
    {

        void CalcFitness(Solution[] generation);
        double GetTotalDistance(Solution[] generation);
        double GetSlice(Solution solution, double totalDistance);
    }
}
