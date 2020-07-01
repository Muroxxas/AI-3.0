using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class SolutionUtils : ISolutionUtils
    {
        public double CalcScore(Solution solution, double totalDistance)
        {
            string[] path = solution.path;
            bool[] cityAlreadyVisited = new bool[path.Length];
            double Score = solution.distance / totalDistance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            if (firstCityVisited != lastCityVisited)
            {
                Score = Score * .3;
            }

            foreach (string city in path)
            {                
                int cityInt = Convert.ToInt32(city);                
                
                //check if the city is a dupe.
                if (cityAlreadyVisited[cityInt] == true)
                {
                    //potential duplicate of the first or last city on the path. Checking to confirm/deny.
                    if (city == firstCityVisited || city == lastCityVisited)
                    {
                        int first = Convert.ToInt32(firstCityVisited);
                        int last = Convert.ToInt32(lastCityVisited);

                        if (cityAlreadyVisited[first] == true)
                        {
                            //The first city in the full path has alreayd been visited. Dupe.
                            Score = Score * .6;
                        }
                        else
                        {
                            //The first city hasn't been marked down, so this must be the first iteration of the foreach loop. NOT a dupe.
                            cityAlreadyVisited[first] = true;
                        }

                        if (cityAlreadyVisited[last] == true)
                        {
                            /* The salesman has already visited what should have been the final city in the middle of the route.
                               Therefore, there is a dupe. */
                            Score = Score * .6;
                        }
                        else
                        {
                            //This may be the end of the path. Cannot confirm duplicity, but can mark city as visited.
                            cityAlreadyVisited[last] = true;
                        }

                    }
                } 
                else
                {
                    Score = Score * .6;
                }

            }

            return Score;
        }

        public double CalcTotalScore(Solution[] generation)
        {
            double totalScore=0;

            foreach(Solution solution in generation)
            {
                totalScore += solution.score;
            }
            return totalScore;
        }

        public double CalcRouletteEdge(double lowerEdge, double score, double totalScore)
        {
            double sliceSize = score / totalScore;
            double upperEdge = lowerEdge + sliceSize;

            return upperEdge;

        }
    }
}
