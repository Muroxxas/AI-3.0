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

        City[] cities;

        public void CalcFitness(Solution[] generation)
        {
           int totalDistance = CalcTotalDistance(generation);
           int totalScore = CalcTotalScore(generation,totalDistance); 
        }

        private int CalcTotalDistance(Solution[] generation)
        {
            int totalDistance = 0;
            foreach (Solution solution in generation)
            {
                totalDistance += calcDistance(solution);
            }
            return totalDistance;
        }
        private int calcDistance(Solution solution)
        {
            int runningTotal = 0;
            //Calculates the distance a single solution travels.
            for (int pathSlot = 1; pathSlot < solution.path.Length; pathSlot++)
            {
                string cityAName = solution.path[pathSlot - 1];
                string cityBName = solution.path[pathSlot];

                City cityA = cities.SingleOrDefault(city => city.name == cityAName);
                City cityB = cities.SingleOrDefault(city => city.name == cityBName);

                runningTotal += Pythagoreas(cityA, cityB);
            }
            solution.distance = runningTotal;
            return runningTotal;
        }
        private int Pythagoreas(City cityA, City cityB)
        {
            int X = Math.Abs(cityA.xCord - cityB.xCord);
            int Y = Math.Abs(cityA.yCord - cityB.yCord);

            int Z = (int)Math.Sqrt(((X * X) + (Y * Y)));
            return Z;

        }

        private int CalcTotalScore(Solution[] generation, int totalDistance)
        {
            int scoreRunningTotal = 0;

            foreach (Solution solution in generation)
            {
                scoreRunningTotal = CalcScore(solution, scoreRunningTotal, totalDistance);
            }
            return scoreRunningTotal;
        }
        private int CalcScore(Solution solution, int scoreRunningTotal, int totalDistance)
        {
            int score = scoreRunningTotal + CalcSlice(solution, totalDistance);
            solution.score = score;
            return score;
            
        }
        private int CalcSlice(Solution solution, int totalDistance)
        {
            string[] path = solution.path;
            bool[] cityAlreadyVisited = new bool[path.Length];
            int slice = totalDistance / solution.distance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            if (firstCityVisited != lastCityVisited)
            {
                slice = (int)Math.Round(slice * .3);
            }

            //calculate the final slice size.
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
                            slice = (int)Math.Round(slice * .6);
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
                            slice = (int)Math.Round(slice * .6);
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
                    //This is the salesman's first visit.
                    cityAlreadyVisited[cityInt] = true;
                }

            }
            return slice;
        }


        

        public SolutionUtils(City[] cities)
        {
            this.cities = cities;
        }
    }
}
