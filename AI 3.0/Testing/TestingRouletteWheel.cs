using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Testing
{
    class TestingRouletteWheel : IRouletteWheel
    {
        Solution[] generation;
        Random rand;

        public Solution SelectParent()
        {
            double selection = GetRandomDouble(0, generation.Last().score);
            if (selection >= generation.Last().score)
            {
                //BUG - the final object of the generation can never be selected as a parent.
                return generation.Last();
            }
            else if (selection < generation.First().score)
            {
                return generation.First();
            }
            int startMin = 0;
            int startMax = generation.Length-1;
            return BinarySearchRecursive(selection, startMin, startMax);

        }
        private Solution BinarySearchRecursive(double selection, int loopMin, int loopMax)
        {
            int mid = (loopMin + loopMax) / 2;
            double midScore = generation[mid].score;
            double nextScore = generation[mid + 1].score;


            if (generation[mid].score <= selection && selection < generation[mid + 1].score)
            {
                //object found!
                return generation[mid];
            }
            else if (selection < generation[mid].score)
            {
                //Go down.
                return BinarySearchRecursive(selection, loopMin, mid - 1);
            }
            else if (selection >= generation[mid + 1].score)
            {
                //Go up.
                return BinarySearchRecursive(selection, mid + 1, loopMax);
            }
            else
            {
                //Something has gone wrong!
                Console.Write("Something has failed in the Binary search!");
                string[] fake = new string[1];
                return new Solution(fake);
            }

        }
        private double GetRandomDouble(double minimum, double maximum)
        {
            double i = rand.NextDouble() * (maximum - minimum) + minimum;
            return i;
        }

        public void SetRand(Random rand)
        {
            this.rand = rand;
        }

        public TestingRouletteWheel(Solution[] generation)
        {
            this.generation = generation;
        }

    }
}
