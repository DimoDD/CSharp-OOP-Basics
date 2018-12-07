using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.AllAnimals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0 )
                {
                    throw new Exception("Invalid input!");
                }
                
                this.age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }
                
                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Scream");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
