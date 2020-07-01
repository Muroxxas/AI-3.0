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
            string[] childSolution = new string[Parent1.solution.Length];

            Random rand = new Random();
            int crossoverPoint = rand.Next(0, Parent1.solution.Length);

            //up to and including the crossoverpoint
            for( int i=0; i<=crossoverPoint; i++)
            {
                childSolution[i] = Parent1.solution[i];
            }

            //from crossover point to the end of the other parent.
            for (int j = crossoverPoint+1; j <=Parent1.solution.Length; j++)
            {
                childSolution[j] = Parent2.solution[j];
            }

            Solution child = solutionFactory.CreateSolution(childSolution);

            //TBI

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
