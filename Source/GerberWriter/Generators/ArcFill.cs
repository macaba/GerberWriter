using GerberWriter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Generators
{
    public class ArcFill : IEntity
    {
        public IAperture Aperture { get; private set; }
        public Arc InsideArc { get; private set; }
        public Arc OutsideArc { get; private set; }

        public ArcFill(IAperture aperture, Point centre, double arcWidthDegrees, double arcHeadingDegrees, double radialInsideDistance, double radialOutsideDistance)
        {
            Aperture = aperture;
            InsideArc = Arc.Calculate(aperture, centre, radialInsideDistance, arcHeadingDegrees, arcWidthDegrees);
            OutsideArc = Arc.Calculate(aperture, centre, radialOutsideDistance, arcHeadingDegrees, arcWidthDegrees);
        }

        public string Validate() { return ""; }

        public string Generate()
        {
            string gerber = "";
            gerber += Aperture.Generate();
            gerber += Region.Enable;
            gerber += QuadrantMode.Multi;
            gerber += OutsideArc.Start.Generate(Operation.Move);

            gerber += Interpolation.CircularClockwise;
            gerber += Arc.Draw(OutsideArc.Start, OutsideArc.End, OutsideArc.Centre);

            gerber += Interpolation.Linear;
            gerber += InsideArc.End.Generate(Operation.Draw);

            gerber += Interpolation.CircularCounterClockwise;
            gerber += Arc.Draw(InsideArc.End, InsideArc.Start, InsideArc.Centre);

            gerber += Interpolation.Linear;
            gerber += OutsideArc.Start.Generate(Operation.Draw);

            gerber += Region.Disable;
            return gerber;
        }
    }
}
