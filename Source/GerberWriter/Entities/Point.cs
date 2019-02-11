using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public string Generate(string gerberOperation)
        {
            return string.Format("X{0:####00000}Y{1:####00000}{2}*\n", X * 100000, Y * 100000, gerberOperation);
        }
    }
}