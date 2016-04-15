using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benford.Models
{
    public class BenfordResult
    {
        public static readonly double[] Theoretical = new double[] { 0.301, 0.176, 0.125, 0.097, 0.079, 0.067, 0.058, 0.051, 0.046 };

        public string Name { get; set; }
        public double[] Actual { get; set; }
    }
}
