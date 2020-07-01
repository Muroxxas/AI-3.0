﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_3._0.Data_Classes
{
    class Solution
    {
        public String[] solution { get; set; }

        public double distance { get; set; }

        public double score { get; set; }

        public double rouletteEdge { get; set; }

        public Solution(String[] solution)
        {
            this.solution = solution;
        } 

    }
}
