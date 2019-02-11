using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public class Arc : IEntity
    {
        public IAperture Aperture { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Point Centre { get; set; }

        public static Arc Calculate(IAperture aperture, Point centre, double radius, double arcHeadingDeg, double arcWidthDeg)
        {
            double arcHeadingRadians = arcHeadingDeg * (Math.PI / 180);
            double arcWidthRadians = arcWidthDeg * (Math.PI / 180);

            double startAngle = arcHeadingRadians + (arcWidthRadians / 2);
            double endAngle = arcHeadingRadians - (arcWidthRadians / 2);

            return new Arc()
            {
                Aperture = aperture,
                Start = new Point()
                {
                    X = centre.X + (radius * Math.Cos(startAngle)),
                    Y = centre.Y + (radius * Math.Sin(startAngle))
                },
                End = new Point()
                {
                    X = centre.X + (radius * Math.Cos(endAngle)),
                    Y = centre.Y + (radius * Math.Sin(endAngle))
                },
                Centre = centre
            };
        }

        public static string Draw(Point start, Point end, Point centre)
        {
            //return string.Format("X{0:####00000}Y{1:####00000}I{2:####00000}J{3:####00000}{4}*\n", end.X * 100000, end.Y * 100000, Math.Abs(centre.X - start.X) * -100000, Math.Abs(centre.Y - start.Y) * -100000, Operation.Draw);
            //return string.Format("X{0:####00000}Y{1:####00000}I{2:####00000}J{3:####00000}{4}*\n", end.X * 100000, end.Y * 100000, -start.X * 100000, -start.Y * 100000, Operation.Draw);
            return string.Format("X{0:####00000}Y{1:####00000}I{2:####00000}J{3:####00000}{4}*\n", end.X * 100000, end.Y * 100000, centre.X - start.X * 100000, centre.Y - start.Y * 100000, Operation.Draw);
        }

        public string Validate()
        {
            return "";
        }

        public string Generate()
        {
            string gerber = "";
            gerber += Aperture.Generate();
            gerber += QuadrantMode.Multi;
            gerber += Interpolation.CircularClockwise;
            gerber += Start.Generate(Operation.Move);
            gerber += Draw(Start, End, Centre);
            return gerber;
        }
    }
}
