using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AI_3._0.Interfaces;
namespace AI_3._0.Factories
{
    class AbstractFactory : IAbstractFactory
    {

        public ICityFactory CreateCityFactory(int seed)
        {

            return new CityFactory(seed);
        }

        public ISolutionFactory CreateSolutionFactory()
        {
            return new SolutionFactory();
        }
        public IBreedingFactory CreateBreedingFactory()
        {
            return new BreedingFactory();
        }
    }
}
