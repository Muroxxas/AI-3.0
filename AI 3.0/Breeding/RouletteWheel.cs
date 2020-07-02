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
            //parent value is a placeholer until for loop finds the real parent.
            Solution parent = generation[1];
            Random rand = new Random();
            double rouletteSelection = rand.NextDouble();

            if (rouletteSelection > generation.Last().rouletteEdge)
            {
                parent = generation.Last();
            }
            else {
                for (int x = 0; x < generation.Length - 1; x++)
                {
                    //if selection falls between x and x+1's roulette edges, then the object at x has been selected as a parent.
                    if  (generation[x].rouletteEdge <= rouletteSelection && generation[x + 1].rouletteEdge > rouletteSelection)
                    {
                        parent = generation[x];
                        break;
                    }
                }
            }
            return parent;
        }


        public RouletteWheel() { }
        public RouletteWheel(Solution[] generation)
        {
            this.generation = generation;
        }

    }
}
