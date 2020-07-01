using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
namespace AI_3._0.Interfaces
{
    interface ISolutionUtils
    {

        double CalcScore(String[] solution);

        double CalcTotalScore(Solution[] generation);

        double CalcRouletteEdge(double lowerEdge, double score, double totalScore);
    }
}
