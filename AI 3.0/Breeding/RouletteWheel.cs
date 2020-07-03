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
        Random rand;

        public Solution SelectParent()
        {
            int selection = rand.Next(0, generation.Last().score);
            if(selection >= generation.Last().score)
            {
                return generation.Last();
            }
            else if (selection < generation.First().score)
            {
                return generation.First();
            }

            return BinarySearchRecursive(selection, min, max);

        }
        private Solution BinarySearchRecursive(double selection, int min, int max)
        {
            mid = (min + max) / 2;
            if (generation[mid].score <= selection && selection < generation[mid + 1].score)
            {
                //object found!
                return generation[mid];
            }
            else if (selection < generation[mid].score)
            {
                //Go down.
                return BinarySearchRecursive(selection, min, mid - 1);
            }
            else if (selection >= generation[mid + 1].score)
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

        public void SetRand(Random rand)
        {
            this.rand = rand;
        }
        
        public RouletteWheel(Solution[] generation)
        {
            this.generation = generation;
            this.min = 0;
            this.max = generation.Length - 1;
        }

    }
}
