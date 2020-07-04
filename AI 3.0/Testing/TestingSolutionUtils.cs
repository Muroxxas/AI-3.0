using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class TestingSolutionUtils : ISolutionUtils
    {

        City[] cities;

        public void CalcFitness(Solution[] generation)
        {
            double totalDistance = CalcTotalDistance(generation);
            double totalScore = CalcTotalScore(generation, totalDistance);
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
        private double CalcSlice(Solution solution, double  totalDistance)
        {
            string[] path = solution.path;
            bool[] cityAlreadyVisited = new bool[path.Length - 1];
            double slice = totalDistance / solution.distance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            //If ends dont match, punish.
            if (firstCityVisited != lastCityVisited)
            {
                slice = slice * .7;
            }

            //Loop through and search for duplicates.
            for (int slot = 0; slot < path.Length; slot++)
            {
                string city = path[slot];
                int cityInt = Int32.Parse(city);

                //City has NOT appeared before.
                if (cityAlreadyVisited[cityInt] == false)
                {
                    cityAlreadyVisited[cityInt] = true;
                }

                //city HAS appeared before.
                else
                {
                    //if we found a city that matches the name of the first city in the path
                    if (city == path.First())
                    {
                        //check if we are currently pointed towards the final object in the path.
                        if (slot == path.Length - 1)
                        {
                            //We're currently pointed at the final location in the solution object. Therefore, path.Last == path.First, as intended. Not a dupe.
                        }
                        else
                        {
                            //We are NOT currently pointed at the final location in the solution object. Therefore, we are currently pointed at a dupe of path.First.
                            slice = slice * .7;
                        }
                    }

                    //Found a city that matches path.Last, but does NOT match first.
                    else if (city == path.Last())
                    {
                        //check if we are currently pointed towards the final object in the path.
                        if (slot == path.Length - 1)
                        {
                            // We are currently inspecting the last object, so we cannot confirm if cityVisited[slot] was set to true by first or by a dupe. Do nothing.
                        }
                        else
                        {
                            // we are NOT currently inspecting the last object. Therefore, the last object's cityVisited could only have been set to true by a dupe.
                            slice = slice * .7;
                        }

                    }

                    //Found a location that is not the starting or end point.
                    else
                    {
                        //We've already visited here. Dupe.
                        slice = slice * .7;
                    }
                }
            }

            return slice;
        }


        public TestingSolutionUtils(City[] cities)
        {
            this.cities = cities;
        }
    }
}
