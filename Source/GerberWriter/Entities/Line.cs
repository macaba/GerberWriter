using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public class Line : IEntity
    {
        public IAperture Aperture { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public string Validate()
        {
            string error = "";
            if (Start.X == End.X && Start.Y == End.Y)
            {
                error += "Line has zero length.\n";
            }
            return error;
        }

        public string Generate()
        {
            string gerber = "";
            gerber += Aperture.Generate();
            gerber += Interpolation.Linear;
            gerber += Start.Generate(Operation.Move);
            gerber += End.Generate(Operation.Draw);
            return gerber;
        }
    }
}
