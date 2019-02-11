using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public static class Interpolation
    {
        public const string Linear = "G01*\n";
        public const string CircularClockwise = "G02*\n";
        public const string CircularCounterClockwise = "G03*\n";
    }
}
