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
            int totalDistance = CalcTotalDistance(generation);
            int totalScore = CalcTotalScore(generation, totalDistance);
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
            bool[] cityAlreadyVisited = new bool[path.Length - 1];
            int slice = totalDistance / solution.distance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            //If ends dont match, punish.
            if (firstCityVisited != lastCityVisited)
            {
                slice = (int)Math.Round(slice * .7);
            }
            for(int slot =0; slot < path.Length; slot++)
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
                    //
                    if()
                }
            }

        }


        public SolutionUtils(City[] cities)
        {
            this.cities = cities;
        }
    }
