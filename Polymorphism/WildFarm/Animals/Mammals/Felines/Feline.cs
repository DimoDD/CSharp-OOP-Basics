using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            //to do validation
            get { return breed; }
            set { breed = value; }
        }

        public override string ToString()
        {
            return base.ToString()+$"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
