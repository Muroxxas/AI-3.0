using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_3._0.Interfaces
{
    interface IAbstractFactory
    {
        ICityFactory CreateCityFactory(int seed);
        ISolutionFactory CreateSolutionFactory();

        IBreedingFactory CreateBreedingFactory();
    }
}
