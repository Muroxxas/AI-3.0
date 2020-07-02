using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface IBreeder
    {
        //breed a single set of parents, returning a child object.
        Solution Breed();

        //set the breeder's Solution Utility object.
        void SetSolutionUtils(ISolutionUtils solutionUtils);

        //set the breeder's roulette wheel object.
        void SetRouletteWheel(IRouletteWheel rouletteWheel);

        //Facade to invoke the CalcFitness function of the SolutionUtils object the breeder has. To be used once per generation.
        void CalcFitness(Solution[] generation);

    }
}
