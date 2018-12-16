using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Models
{
    public abstract class Tyre
    {
        protected Tyre(string name, double hardness)
        {
            this.Name = name;
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public string Name { get; }
        public double Hardness { get; }
        public double Degradation { get; private set; }

        public void CompleteLap()
        {
            this.Degradation -= this.Hardness;
            if (this.Degradation < 0)
            {
                throw new ArgumentException("tyre blown");
            }
        }

    }
}
