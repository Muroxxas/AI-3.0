using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_3._0.Data_Classes
{
    class City
    {
        public int xCord { get; set; }

        public int yCord { get; set; }

        public string name { get; set; }

        public City(int xCord, int yCord, string name)
        {
            this.xCord = xCord;
            this.yCord = yCord;
            this.name = name;
        }
    }
}
