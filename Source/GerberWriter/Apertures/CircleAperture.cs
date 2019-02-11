using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public class CircleAperture : IAperture
    {
        public double Diameter { get; set; }
        public int Index { get; set; }
        private bool addedToFile = false;

        public string Validate()
        {
            //To do - check that a valid aperture exists
            string error = "";
            return error;
        }

        public string Generate()
        {
            var aperture = "";
            if (!addedToFile)
            {
                addedToFile = true;
                aperture += string.Format("%ADD{0}C,{1}*%\n", Index, Diameter);
            }
            aperture += string.Format("D{0}*\n", Index);
            return aperture;
        }
    }
}
