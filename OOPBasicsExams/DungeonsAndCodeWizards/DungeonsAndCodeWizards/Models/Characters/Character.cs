using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier ;


        private const double defaultRestHealMultiplier = 0.2;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;


            this.IsAlive = true;
            this.RestHealMultiplier = defaultRestHealMultiplier;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }        

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }       

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false; 
                }
                else
                {
                    this.health = value;
                }
            }
        }        

        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set { baseArmor = value; }
        }       

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return this.bag; }
            private set { this.bag = value; }
        }

        public Faction Faction
        {
            get { return this.faction; }
            private set { this.faction = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public virtual double RestHealMultiplier 
        {
            get { return restHealMultiplier ; }
            private set { restHealMultiplier  = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureIsAlive();
            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                var remainder = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= remainder;

                if (this.Health == 0)
                {
                    this.isAlive = false;
                }                
            }
        }

        public void Rest()
        {
            EnsureIsAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureIsAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureIsAlive();
            this.Bag.AddItem(item);
        }

        public void EnsureBothCharactersAreAlive(Character character)
        {
            if (!this.IsAlive || !character.isAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        private void EnsureIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
