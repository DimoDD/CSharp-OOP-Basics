using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Models
{
    public class UltrasoftTyre : Tyre
    {
        public UltrasoftTyre(double hardness) : base("Ultrasoft", hardness)
        {
        }

        public double Grip { get; set; }
    }
}
