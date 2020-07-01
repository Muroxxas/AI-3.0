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
        Random fixRand;
        public City CreateCity(string name)
        {
            int xCord=fixRand.Next(0,999);
            int yCord=fixRand.Next(0,999);

            return new City(xCord, yCord, name);
        }

        public CityFactory(int seed)
        {
            fixRand = new Random(seed);
        }
    }
}
