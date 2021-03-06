﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface IGenerator
    {
        void CreateCities();
        void CreateInitialGeneration();
        void Generate();
        void CalcFitness();
        Solution FindBestFit();

    }
}
