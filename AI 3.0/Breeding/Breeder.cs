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
        
        //facade for the private breed
        public Solution Breed()
        {
            Solution Parent1 = rouletteWheel.SelectParent();
            Solution Parent2 = rouletteWheel.SelectParent();

            return Breed(Parent1, Parent2);

            //Note : add some class that checks for and prevents incest.
        }
        private Solution Breed(Solution Parent1, Solution Parent2)
        {
            Solution child;


            return child;
        }
    }
}
