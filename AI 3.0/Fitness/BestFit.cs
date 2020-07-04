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

        public Solution FindBestFit(Solution[] generation)
        {
            bestFitArray = new FitnessObject[generation.Length];

            //set up ends of the bestFitArray, to avoid overflowing.
            double firstFitness = generation.First().score;
            bestFitArray[0] = new FitnessObject(0, firstFitness);
            double lastFitness = generation.Last().score - generation[generation.Count() - 2].score;
            bestFitArray[generation.Count()-1] = new FitnessObject(generation.Length - 1, lastFitness);

            FillBestFitArray(generation);
            IEnumerable<FitnessObject> bestFitSorted = bestFitArray.OrderBy(item => item.fitness);

            foreach(FitnessObject obj in bestFitSorted)
            {
                Console.WriteLine("Fitness : {0}   generationSlot : {1}", obj.fitness, obj.generationSlot);
            }
            int slotOfBestFitObject = bestFitSorted.Last().generationSlot;
            return generation[slotOfBestFitObject];

        }

        private void FillBestFitArray(Solution[] generation)
        {
            for(int slot=1; slot <= generation.Length-2; slot++)
            {
                double fitness = generation[slot + 1].score - generation[slot].score;
                bestFitArray[slot] = new FitnessObject(slot, fitness);
            }

        }

        public BestFit() {}
    }
}
