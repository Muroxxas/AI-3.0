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
           double totalDistance = CalcTotalDistance(generation);
           double totalScore = CalcTotalScore(generation,totalDistance); 
        }

        private double CalcTotalDistance(Solution[] generation)
        {
            double totalDistance = 0;
            foreach (Solution solution in generation)
            {
                totalDistance += calcDistance(solution);
            }
            return totalDistance;
        }
        private double calcDistance(Solution solution)
        {
            double runningTotal = 0;
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
        private double Pythagoreas(City cityA, City cityB)
        {
            double X = Math.Abs(cityA.xCord - cityB.xCord);
            double Y = Math.Abs(cityA.yCord - cityB.yCord);

            double Z = (int)Math.Sqrt(((X * X) + (Y * Y)));
            return Z;

        }

        private double CalcTotalScore(Solution[] generation, double totalDistance)
        {
            double scoreRunningTotal = 0;

            foreach (Solution solution in generation)
            {
                scoreRunningTotal = CalcScore(solution, scoreRunningTotal, totalDistance);
            }
            return scoreRunningTotal;
        }
        private double CalcScore(Solution solution, double scoreRunningTotal, double totalDistance)
        {
            double score = scoreRunningTotal + CalcSlice(solution, totalDistance);
            solution.score = score;
            return score;
            
        }
        private double CalcSlice(Solution solution, double totalDistance)
        {
            string[] path = solution.path;
            bool[] cityAlreadyVisited = new bool[path.Length-1];
            double slice = totalDistance / solution.distance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            //If end's don't match, punish.
            if (firstCityVisited != lastCityVisited)
            {
                slice = slice * .8;
            }

            //calculate the final slice size.
            foreach (string city in path)
            {
                int cityInt = Convert.ToInt32(city);

                //check if the city is a dupe.
                if (cityAlreadyVisited[cityInt] == true)
                {
                    //potential duplicate of the first city on the path. Checking to confirm/deny.
                    if (city == firstCityVisited)
                    {
                        int first = Convert.ToInt32(firstCityVisited);
                        

                        if (cityAlreadyVisited[first] == true)
                        {
                            //The first city in the full path has alreayd been visited. Dupe.
                            slice = slice * .9;
                        }
                        else
                        {
                            //The first city hasn't been marked down, so this must be the first iteration of the foreach loop. NOT a dupe.
                            cityAlreadyVisited[first] = true;
                        }
                    }
                    //potential dupe of the last city on the path. Checking to confirm/deny.
                    else if (city == lastCityVisited)
                    {
                        int last = Convert.ToInt32(lastCityVisited);
                        if (cityAlreadyVisited[last] == true)
                        {
                            /* The salesman has already visited what should have been the final city in the middle of the route.
                               Therefore, there is a dupe. */
                            slice = slice * .9;
                        }
                        else
                        {
                            //This may be the end of the path. Cannot confirm duplicity, but can mark city as visited.
                            cityAlreadyVisited[last] = true;
                        }
                    }     
                    //for all other cities, it's guaranteed to be a dupe.
                    else {
                        slice = slice * .6;
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
