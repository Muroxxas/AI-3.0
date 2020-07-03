using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.BestFit;
namespace AI_3._0.Data_Classes
{
    class FitnessObject
    {
        public int generationSlot { get; set; } 
        public int fitness { get; set; }

        public FitnessObject(int generationSlot, int fitness)
        {
            this.generationSlot = generationSlot;
            this.fitness = fitness;
        }
    }
}
