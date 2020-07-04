using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Fitness;
namespace AI_3._0.Data_Classes
{
    class FitnessObject : IComparable
    {
        public int generationSlot { get; set; } 
        public int fitness { get; set; }

        public FitnessObject(int generationSlot, int fitness)
        {
            this.generationSlot = generationSlot;
            this.fitness = fitness;
        }

        //Nexted class to do ascending sort on fitness.
        private class SortFitnessAscending : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                FitnessObject f1 = (FitnessObject)a;
                FitnessObject f2 = (FitnessObject)b;

                if (f1.fitness > f2.fitness)
                {
                    return 1;
                }
                else if (f1.fitness <  f2.fitness)
                {
                    return -1;

                }
                else
                {
                    return 0;
                }
            }
        }

        int IComparable.CompareTo(object obj)
        {
            FitnessObject f = (FitnessObject)obj;
            return string.Compare(this.fitness.ToString(), f.fitness.ToString());
        }
    }
}
