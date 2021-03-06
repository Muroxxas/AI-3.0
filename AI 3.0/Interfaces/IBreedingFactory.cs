﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface IBreedingFactory
    {
        IBreeder CreateBreeder( IMutater mutater, ISolutionFactory solutionFactory);
        IMutater CreateMutater(double mutationRate);
        IRouletteWheel CreateRouletteWheel(Solution[] generation);
        ISolutionUtils CreateSolutionUtils(City[] cities);


    }
}
