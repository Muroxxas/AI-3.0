using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class Breeder : IBreeder
    {

        ISolutionUtils solutionUtils;
        IMutater mutater;
        IRouletteWheel rouletteWheel;
        ISolutionFactory solutionFactory;
        
        //facade for the private breed
        public Solution Breed()
        {

            Solution parent1 = solutionFactory.CreateSolution();
            Solution parent2 = solutionFactory.CreateSolution();

            while (parent1 == parent2)
            {
                parent1 = rouletteWheel.SelectParent();
                parent2 = rouletteWheel.SelectParent();
            }


            return Breed(parent1, parent2);
        }
        private Solution Breed(Solution Parent1, Solution Parent2)
        {
            string[] childSolution = new string[Parent1.path.Length];
            Random rand = new Random();
            int crossoverPoint = rand.Next(0, Parent1.path.Length);

            //up to the crossover point
            for( int i=0; i<crossoverPoint; i++)
            {
                childSolution[i] = Parent1.path[i];
            }
            //from crossover point to the end of the other parent.
            for (int j = crossoverPoint; j < Parent1.path.Length; j++)
            {
                childSolution[j] = Parent2.path[j];
            }

            Solution child = solutionFactory.CreateSolution(childSolution);
            mutater.Mutate(child);
            return child;
        }

        public Breeder(IRouletteWheel rouletteWheel, ISolutionUtils solutionUtils, IMutater mutater)
        {
            this.rouletteWheel = rouletteWheel;
            this.solutionUtils = solutionUtils;
            this.mutater = mutater;
        }

        public Breeder(IRouletteWheel rouletteWheel, ISolutionUtils solutionUtils, IMutater mutater, ISolutionFactory solutionFactory)
        {
            this.rouletteWheel = rouletteWheel;
            this.solutionUtils = solutionUtils;
            this.mutater = mutater;
            this.solutionFactory = solutionFactory;
        }
    }
}
