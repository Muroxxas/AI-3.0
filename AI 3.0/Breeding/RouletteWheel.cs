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
            int Binarycount = 0;
            Console.WriteLine("New search!");
            return BinarySearchRecursive(selection, min, max, Binarycount);

        }
        private Solution BinarySearchRecursive(double selection, int min, int max, int Binarycount)
        {
            Binarycount += 1;
            if(Binarycount > 9)
            {
                Console.WriteLine("Problem with Binary search detected!");
                Console.ReadLine();
            }

            mid = (min + max) / 2;
            Console.WriteLine($"Min : {min} Max : {max} mid : {mid} selection : {selection} ");
            if (generation[mid].score <= selection && selection < generation[mid + 1].score)
            {
                //parent found!
                return generation[mid];
            }
            else if (selection < generation[mid].score)
            {
                //Go down.
                return BinarySearchRecursive(selection, min, mid - 1, Binarycount);
            }
            else if (selection >= generation[mid + 1].score)
            {
                //Go up.
                return BinarySearchRecursive(selection, mid + 1, max, Binarycount);
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
