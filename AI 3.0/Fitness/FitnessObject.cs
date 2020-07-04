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
        public double fitness { get; set; }

        public FitnessObject(int generationSlot, double fitness)
        {
            this.generationSlot = generationSlot;
            this.fitness = fitness;
        }


        int IComparable.CompareTo(object obj)
        {
            FitnessObject f = (FitnessObject)obj;
            return string.Compare(this.fitness.ToString(), f.fitness.ToString());
        }
    }
}
