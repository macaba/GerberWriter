using GerberWriter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public class Polyline : IEntity
    {
        public IAperture Aperture { get; set; }
        public List<Point> Points { get; set; }

        public Polyline()
        {
            Points = new List<Point>();
        }

        public void AddPoint(double x, double y)
        {
            Points.Add(new Point() { X = x, Y = y });
        }

        public string Validate()
        {
            //To do - check that a valid aperture exists
            string error = "";
            return error;
        }

        public string Generate()
        {
            string gerber = "";
            if (Points.Count > 1)
            {
                gerber += Aperture.Generate();
                gerber += Interpolation.Linear;
                gerber += Points[0].Generate(Operation.Move);
                for (int i = 1; i < Points.Count; i++)
                {
                    gerber += Points[i].Generate(Operation.Draw);
                }
            }
            return gerber;
        }
    }
}
