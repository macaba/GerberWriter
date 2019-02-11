using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter
{
    public interface IEntity
    {
        string Validate();
        string Generate();
    }
}
