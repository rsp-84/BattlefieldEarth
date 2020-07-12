using System;

namespace BattlefieldEarthLibrary
{
    public class Country
    {
        //Fields
        private int _population;
        private int _missileDefense;

        //Properties
        public int MaxPopulation { get; set; }
        public string CountryName { get; set; }
        public Government Gov { get; set; }
        public int MilBonusStrength { get; set; }
        public Military CountryMil { get; set; }

        public int Population
        {
            get { return _population; }
            set
            {
                if (value <= MaxPopulation)
                {
                    _population = value;
                }
                else
                {
                    _population = MaxPopulation;
                }
            }
        }

        public int MissileDefense
        {
            get { return _missileDefense; }
            set
            {
                if (_missileDefense >= 0 && _missileDefense <= 100)
                {
                    _missileDefense = value;
                }
                else if (_missileDefense > 100)
                {
                    _missileDefense = 100;
                }
                else
                {
                    _missileDefense = 0;
                }
            }
        }

        //Ctors
        public Country(int maxPopulation, int population, string countryName, int militaryReadiness, int missileDefense, Government gov, Military countryMil)
        {
            MaxPopulation = maxPopulation;
            Population = population;
            CountryName = countryName;
            MissileDefense = missileDefense;
            Gov = gov;
            CountryMil = countryMil;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("::: The Country of {0} as of {1:d} :::\n\n{2}\n" +
                "Population: {3:n0}\n\n" +
                "{4}",
                CountryName,
                DateTime.Now,
                Gov,
                Population,
                CountryMil
                );
        }

        public int[] CalcDamage()
        {
            Random rand = new Random();

            //poploss, spies lost, troops lost, turrets list, tanks lost
            int[] damages = 
            {
                rand.Next(1, 301),
                rand.Next(1, 301),
                rand.Next(1, 301),
                rand.Next(1, 301),
                rand.Next(1, 301)
            };

            return damages;
        }
    }
}
