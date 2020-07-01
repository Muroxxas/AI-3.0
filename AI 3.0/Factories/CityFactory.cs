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
        public City CreateCity(string name)
        {
            int xCord=0;
            int yCord=0;
            // generate random values based off a seed given in main.

            return new City(xCord, yCord, name);
        }
    }
}
