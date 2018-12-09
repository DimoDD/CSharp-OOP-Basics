using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double foodIncrease = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * foodIncrease;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
