﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MCPETRIE-ST10263164-PROG6221POE3
namespace PROG6221POE3
{
    internal class Instruction
    {
        public int stepNumber { get; set; }
        public string step { get; set; }

        public Instruction(int stepNumber, string step)
        {
            this.stepNumber = stepNumber;
            this.step = step;
        }

    }
}
