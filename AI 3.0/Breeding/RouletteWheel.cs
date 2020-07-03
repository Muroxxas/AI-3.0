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
        int min;
        int max;
        int mid;
        public Solution SelectParent()
        {
            Random rand = new Random();
            double selection = rand.NextDouble();
            if(selection >= generation.Last().rouletteEdge)
            {
                return generation.Last();
            }
            return BinarySearchRecursive(selection, min, max);

        }

        private Solution BinarySearchRecursive(double selection, int min, int max)
        {
            mid = (min + max) / 2;
            if (generation[mid].rouletteEdge <= selection && selection < generation[mid + 1].rouletteEdge)
            {
                //parent found!
                return generation[mid];
            }
            else if (selection < generation[mid].rouletteEdge)
            {
                //Go down.
                return BinarySearchRecursive(selection, min, mid - 1);
            }
            else if (selection >= generation[mid + 1].rouletteEdge)
            {
                //Go up.
                return BinarySearchRecursive(selection, mid + 1, max);
            }
            else
            {
                //Something has gone wrong!
                Console.Write("Something has failed in the Binary search!");
                string[] fake = new string[1];
                return new Solution(fake);
            }

        }
        public RouletteWheel(Solution[] generation)
        {
            this.generation = generation;
            this.min = 0;
            this.max = generation.Length - 1;
        }

    }
}
