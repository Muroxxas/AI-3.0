using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface IBreedingFactory
    {
        IBreeder CreateBreeder(IMutater mutater, ISolutionFactory solutionFactory);
        IBreeder CreateBreeder( IMutater mutater, ISolutionFactory solutionFactory, int seed);
        IBreeder CreateBreeder(IMutater mutater, ISolutionFactory solutionFactory, Random rand);

        IMutater CreateMutater(double mutationRate);
        IMutater CreateMutater(double mutationRate, int seed);
        IMutater CreateMutater(double mutationRate, Random rand);

        IRouletteWheel CreateRouletteWheel(Solution[] generation);
        IRouletteWheel CreateRouletteWheel(Solution[] generation, int seed);
        IRouletteWheel CreateRouletteWheel(Solution[] generation, Random rand);


        ISolutionUtils CreateSolutionUtils(City[] cities);


    }
}
