using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class RouletteWheel : IRouletteWheel
    {
        Solution[] generation;

        public Solution SelectParent()
        {
            Random rand = new Random();
            int i = rand.Next(0, generation.Length);
            Solution parent = generation[i];
            return parent;
        }


        public RouletteWheel() { }
        public RouletteWheel(Solution[] generation)
        {
            this.generation = generation;
        }

    }
}
