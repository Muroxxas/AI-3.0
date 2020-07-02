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
           double totalScore = CalcTotalScore(generation, totalDistance);
           CalcAllEdges(generation, totalScore);     
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
        private double CalcTotalDistance(Solution[] generation)
        {
            double totalDistance = 0;
            foreach (Solution solution in generation)
            {
                calcDistance(solution);
                totalDistance += solution.distance;
            }
            return totalDistance;
        }
        private void CalcScore(Solution solution, double totalDistance)
        {
            string[] path = solution.path;
            bool[] cityAlreadyVisited = new bool[path.Length];
            double grossScore = solution.distance / totalDistance;
            string firstCityVisited = path.First();
            string lastCityVisited = path.Last();

            if (firstCityVisited != lastCityVisited)
            {
                grossScore = grossScore * .3;
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
                            grossScore = grossScore * .6;
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
                            grossScore = grossScore * .6;
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

            solution.score = grossScore;
        }
        private double CalcTotalScore(Solution[] generation, double totalDistance)
        {
            double totalScore = 0;

            foreach (Solution solution in generation)
            {
                CalcScore(solution, totalDistance);
                totalScore += solution.score;
            }
            return totalScore;
        }
        private void CalcRouletteEdge(Solution previousSolution, Solution currentSolution, double totalScore)
        {
            double sliceSize = currentSolution.score / totalScore;
            currentSolution.rouletteEdge = previousSolution.rouletteEdge + sliceSize;

        }
        private void CalcAllEdges(Solution[] generation, double totalScore)
        {
            generation.First().rouletteEdge = 0;
            for(int generationSlot =1; generationSlot < generation.Length; generationSlot++)
            {
                CalcRouletteEdge(generation[generationSlot - 1], generation[generationSlot], totalScore);
            }

        }
        private double Pythagoreas(City cityA, City cityB)
        {
            double X = (double)Math.Abs(cityA.xCord - cityB.xCord);
            double Y = (double)Math.Abs(cityA.yCord - cityB.yCord);

            double Z = Math.Sqrt(((X * X) + (Y * Y)));
            return Z;

        }
        

        public SolutionUtils(City[] cities)
        {
            this.cities = cities;
        }
    }
}
