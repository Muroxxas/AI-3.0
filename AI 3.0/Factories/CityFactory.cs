using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_3._0.Data_Classes;
using AI_3._0.Interfaces;
namespace AI_3._0.Factories
{
    class CityFactory : ICityFactory
    {
        Random rand;

        public City CreateCity(string name)
        {
            int xCord=rand.Next(0,1000);
            int yCord=rand.Next(0,1000);

            return new City(xCord, yCord, name);
        }
        public CityFactory(int seed)
        {
            this.rand = new Random(seed);
        }
        public CityFactory(Random rand)
        {
            this.rand = rand;
        }

    }
}
