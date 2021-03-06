﻿namespace MuOnline.Models.Heroes
{
    using System;
    using System.Linq;

    using HeroContracts;

    using Inventories;
    using Inventories.Contracts;

    using Utilities;

    public abstract class Hero : IHero, IIdentifiable, IProgress
    {
        private string username;
        private int strength;
        private int agility;
        private int stamina;
        private int energy;
        private int experience;
        private int level;
        private int resets;
        private int totalAgilityPoints;
        private int totalEnergyPoints;
        private int totalStaminaPoints;

        protected Hero(string username, int strength, int agility, int stamina, int energy)
        {
            this.Username = username;
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
            this.Experience = 0;
            this.Level = 0;
            this.Resets = 0;

            this.Inventory = new Inventory();

            this.TotalAgilityPoints = GetTotalAgilityPoints();
            this.TotalStaminaPoints = GetTotalStaminaPoints();
        }

        public IInventory Inventory { get; }

        public bool IsAlive
            => this.TotalStaminaPoints > 0;

        public string Username
        {
            get { return this.username; }
            private set
            {
                Validator.ValidateStringIsNull(value, nameof(this.Username));

                this.username = value;
            }
        }

        public int Strength
        {
            get { return this.strength; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Strength));

                this.strength = value;
            }
        }

        public int Agility
        {
            get { return this.agility; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Agility));

                this.agility = value;
            }
        }

        public int Stamina
        {
            get { return this.stamina; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Stamina));

                this.stamina = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Energy));

                this.energy = value;
            }
        }

        public int Experience
        {
            get { return this.experience; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Experience));

                this.experience = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Level));

                this.level = value;
            }
        }

        public int Resets
        {
            get { return this.resets; }
            private set
            {
                Validator.ValidateIntLessThanZero(value, nameof(this.Resets));

                this.resets = value;
            }
        }

        public int TotalAttackPoints
            => this.Strength +
               this.Agility * 10 / 100 +
               this.Energy * 5 / 100 +
               this.Inventory.Items.Sum(x => x.Strength);


        public int TotalEnergyPoints
            => this.Energy +
               this.Inventory.Items.Sum(x => x.Energy);

        public int TotalAgilityPoints
        {
            get { return this.totalAgilityPoints; }
            private set
            {
                this.totalAgilityPoints = value;
            }
        }

        public int TotalStaminaPoints
        {
            get { return this.totalStaminaPoints; }
            private set
            {
                this.totalStaminaPoints = value;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }

            if (this.TotalAgilityPoints > 0)
            {
                this.TotalAgilityPoints -= damagePoints;
            }
            else
            {
                this.TotalStaminaPoints -= damagePoints;
            }
        }

        public void AddExperience(int experience)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }

            this.Experience += experience;

            if (this.Experience >= 9000)
            {
                AddLevel();
            }

            if (this.Level >= 400)
            {
                AddReset();
            }
        }

        private int GetTotalStaminaPoints()
        {
            return this.totalStaminaPoints = this.Stamina +
                this.Inventory.Items.Sum(x => x.Stamina);
        }

        private int GetTotalAgilityPoints()
        {
            return this.totalAgilityPoints = this.Agility +
                this.Inventory.Items.Sum(x => x.Agility);
        }

        private void AddReset()
        {
            throw new NotImplementedException();
        }

        private void AddLevel()
        {
            throw new NotImplementedException();
        }
    }
}
