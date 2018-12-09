using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }        

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            set { this.foodEaten = value; }
        }

        public abstract void ProduceSound();
        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
