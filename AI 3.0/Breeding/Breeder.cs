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
            Solution Parent1 = rouletteWheel.SelectParent();
            Solution Parent2 = rouletteWheel.SelectParent();

            //Note : add some class that checks for and prevents incest.

            return Breed(Parent1, Parent2);
        }
        private Solution Breed(Solution Parent1, Solution Parent2)
        {
            Solution child;

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
