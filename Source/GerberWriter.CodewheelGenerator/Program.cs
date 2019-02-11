using GerberWriter.Entities;
using GerberWriter.Generators;
using System;
using System.IO;

namespace GerberWriter.CodeWheelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            GerberWriter writer = new GerberWriter();

            CircleAperture aperture = new CircleAperture()
            {
                Index = 10,
                Diameter = 0.01
            };

            Point centre = new Point() { X = -20, Y = -20 };

            for (int i = 0; i < 1800; i++)
            {
                ArcFill arcFill = new ArcFill(aperture, centre, 0.1, i * 0.2, 97.5, 100);
                writer.AddEntity(arcFill);
            }

            var validationErrors = writer.Validate();
            if (!string.IsNullOrWhiteSpace(validationErrors))
            {
                Console.WriteLine("Validation errors:");
                Console.Write(validationErrors);
            }

            File.WriteAllText("Codewheel.ger", writer.Generate());

            Console.WriteLine("Complete.");
            Console.ReadKey();
        }
    }
}
