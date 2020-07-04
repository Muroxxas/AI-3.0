using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Interfaces;
using AI_3._0.Data_Classes;
namespace AI_3._0.Breeding
{
    class Mutater : IMutater
    {
        double mutationRate;
        Random rand;

        // Mutate using the Reverse Sequence Mutation methodology.
        public void Mutate(Solution solution)
        {
            if (rand.NextDouble() <= mutationRate)
            {
                Console.WriteLine("Rolled to mutate!");
                int m1 = rand.Next(0,solution.path.Length-1);
                int m2 = rand.Next(m1 + 1, solution.path.Length);

                string[] unmutatedPath = solution.path;
                string[] mutatedPath = new string[solution.path.Length];
                string[] reversedChunk = CreateReversedChunk(unmutatedPath, m1, m2);

               

                for (int i =0; i < m1; i++)
                {
                    //Fill normally.
                    mutatedPath[i] = unmutatedPath[i];

                }
                int revSlot = 0;
                for (int i = m1; i <= m2; i++)
                {
                    //fill with reversed chunk.
                    mutatedPath[i] = reversedChunk[revSlot];
                    revSlot++;
                }
                for (int i = m2+1; i < unmutatedPath.Length; i++) 
                {
                    //fill normally.
                    mutatedPath[i] = solution.path[i];
                }
                solution.path = mutatedPath;
            }
        }

        private string[] CreateReversedChunk ( string[] unmutatedPath, int m1, int m2)
        {
            string[] reversedChunk = new string[(m2 - m1) + 1];
            int reversedSlot = 0;
            for (int i=m1; i<=m2; i++)
            {
                reversedChunk[reversedSlot] = unmutatedPath[i];
                reversedSlot++;
            }
            Array.Reverse(reversedChunk);
            return reversedChunk;
        }
        public Mutater() { }
        public Mutater(double mutationRate)
        {
            this.mutationRate = mutationRate;
            this.rand = new Random();
        }
    }
}
