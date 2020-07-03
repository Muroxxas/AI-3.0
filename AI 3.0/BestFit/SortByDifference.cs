using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.BestFit
{
    class SortByDifference : IComparer<FitnessObject>
    {
        int IComparer<FitnessObject>.Compare(FitnessObject x, FitnessObject y)
        {
            if(x.fitness > y.fitness)
            {
                return 1;
            }
            else if (x.fitness < y.fitness)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
