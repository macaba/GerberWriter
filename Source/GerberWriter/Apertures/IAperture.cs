using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter.Entities
{
    public interface IAperture
    {
        string Validate();
        string Generate();
    }
}
