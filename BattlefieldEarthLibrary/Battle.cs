using System;

namespace BattlefieldEarthLibrary
{   //Class to store methods for attacks
    public class Battle
    {
        public static void WarSequence(Country playerCountry, Country enemyNpcCountry)
        {
            //playerCountry attacks first
            Attack(playerCountry, enemyNpcCountry);
            System.Threading.Thread.Sleep(30);

            //npcCountry attacks
            if (enemyNpcCountry.Population > 0)
            {
                Attack(enemyNpcCountry, playerCountry);
            }

        }

        public static void Attack(Country attacker, Country defender)
        {
            //Random possibiliy of a failed attack
            Random rand = new Random();
            int randAttack = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);

            if (randAttack >= 75 && attacker.CountryMil.Missiles > 0)
            {
                int successfulMissileAttack = rand.Next(101);

                if (successfulMissileAttack <= attacker.MissileDefense)
                {
                    defender.Population -= 100;

                    //Attack Result Message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"A missile was launched by {attacker.CountryName}! 100 Civilains were lost!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"A missile was launched by {attacker.CountryName} and was blocked by {defender.CountryName}'s misile defense!\n");
                }
            }
            else if (randAttack > 10)
            {
                //The attack was successful
                int[] damages = attacker.CalcDamage();

                //Assign damage
                defender.Population -= damages[0];
                defender.CountryMil.Spies -= damages[1];
                defender.CountryMil.Troops -= damages[2];
                defender.CountryMil.Turrets -= damages[3];
                defender.CountryMil.Tanks -= damages[4];

                //Attack Result Message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} successfully attacked!\nThe defender lost:\n" +
                    "{1} Civilains\n" +
                    "{2} Spies\n" +
                    "{3} Troops\n" +
                    "{4} Turrets\n" +
                    "{5} Tanks\n",
                    attacker.CountryName,
                    damages[0],
                    damages[1],
                    damages[2],
                    damages[3],
                    damages[4]
                    );
                Console.ResetColor();
            }
            else
            {
                attacker.Population -= 20;
                Console.WriteLine($"{attacker.CountryName} was unable to launch a successful attack! 20 Civilians flee!\n");
            }
        }
    }
}
