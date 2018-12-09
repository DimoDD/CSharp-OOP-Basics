using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public Mammal(string name, double weight, string livingRegion) : this(name, weight)
        {
            this.livingRegion = livingRegion;
        }

        private string livingRegion;

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }       
    }
}
