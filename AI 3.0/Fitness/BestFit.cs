using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Fitness
{
    class BestFit : IBestFit
    {
        FitnessObject[] bestFitArray;

        //Finds and returns the solution with the highest fitness in a given generation.
        public Solution FindBestFit(Solution[] generation)
        {
            //create array of fitness objects
            bestFitArray = new FitnessObject[generation.Length];

            //set up ends of the bestFitArray, to avoid overflowing.
            int firstFitness = generation.First().score;
            bestFitArray[0] = new FitnessObject(0, firstFitness);
           int lastFitness = generation.Last().score - generation[generation.Count() - 2].score;
            bestFitArray[generation.Count()-1] = new FitnessObject(generation.Length - 1, lastFitness);

            //Fill the BestFitArray, then sort it by each item's fitness score.
            FillBestFitArray(generation);
            IEnumerable<FitnessObject> bestFitSorted = bestFitArray.OrderBy(item => item.fitness);


            //Use the BestFitArray to determine which solution in the generation is the best fit. Then, return that solution.
            int slotOfBestFitObject = bestFitSorted.Last().generationSlot;
            return generation[slotOfBestFitObject];

        }

        private void FillBestFitArray(Solution[] generation)
        {
            for(int slot=1; slot <= generation.Length-2; slot++)
            {
                int fitness = generation[slot + 1].score - generation[slot].score;
                bestFitArray[slot] = new FitnessObject(slot, fitness);
            }

        }

        public BestFit() {}
    }
}
