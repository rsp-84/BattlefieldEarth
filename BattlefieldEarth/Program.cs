﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattlefieldEarthLibrary;

namespace BattlefieldEarth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battlefield Earth!";
            #region Logo
            string logo = @"                                         |
                  |                      |
                  |                    -/_\-
                -/_\-   ______________(/ . \)______________
   ____________(/ . \)_____________    \___/     <>
   <>           \___/      <>    <>

      ||
      <>
                            ||
                            <>
                                        |
                                       ||            BIG
        _____               __         <>      (^)))^ BOOM!
  BOOM!/((  )\       BOOM!((  )))            (     ( )
 ---- (__()__))          (() ) ))           (  (  (   )
     ||  |||____|------    \  (/   ___     (__\     /__)
      |__|||  |     |---|---|||___|   |___-----|||||
  |  ||.  |   |       |     |||                |||||
      |__|||  |     |---|---|||___|   |___-----|||||
  |  ||.  |   |       |     |||                |||||  
 __________________________________________________________

";
            Console.WriteLine(logo);
            #endregion
            Console.WriteLine("Command your country's military to attack and defend against your enemies.\n");

            //1. create a country
            Country playerCountry = new Country(5000, 10000, "Cobra Empire", 100, 70, 
                new Government(GovernmentType.Democracy), 
                new Military(2000, 5000, 10000, 5000, 2000, 10)
                );

            //2. create a loop for the country location
            bool exit = false;
            do
            {
                //3. create a room - write a () to get a room description
                Console.WriteLine($"Your opponent: {FindCountry()}");

                //4. create an opponent 
                Country npcCountry = new Country(500, 250, "Dreadful Crayon", 100, 10,
                    new Government(GovernmentType.Dictatorship),
                    new Military(500, 1000, 2000, 3000, 500, 1)
                    );
                Country npcCountry2 = new Country(1000, 900, "Furious Balcony", 100, 20,
                    new Government(GovernmentType.Fascism),
                    new Military(1000, 5000, 10000, 5000, 2000, 3)
                    );
                Country npcCountry3 = new Country(2000, 1900, "Hordes of Darg", 100, 30,
                    new Government(GovernmentType.Monarchy),
                    new Military(1500, 10000, 10000, 7000, 3000, 7)
                    );
                Country npcCountry4 = new Country(5000, 4999, "Pointless Planet", 100, 40,
                    new Government(GovernmentType.Republic),
                    new Military(2000, 15000, 10000, 9000, 5000, 10)
                    );

                Country[] npcCountries = { npcCountry, npcCountry2, npcCountry3, npcCountry4 };

                //pick a random country
                Random rand = new Random();
                int randomNbr = rand.Next(npcCountries.Length);
                Country enemyNpcCountry = npcCountries[randomNbr];

                //5 create a loop for the menu
                bool reload = false;
                do
                {
                    //6 create a menu of options that tells the player what they can do
                    #region MENU
                    Console.WriteLine("\nWhat is your next move?\n" +
                        "V) Visit Country Advisor\n" +
                        "W) War Room\n" +
                        "S) Spy on Enemy\n" +
                        "R) Retreat\n" +
                        "X) Exit");

                    //7 Catch the users input
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //8 Clear the console after the user input to clean up the screen
                    Console.Clear();

                    //9 Build out a switch for userChoice
                    switch (userChoice)
                    {
                        case ConsoleKey.V:
                            //TODO 10. View status of your country, Format it and stuff
                            Console.WriteLine(playerCountry);
                            break;
                        case ConsoleKey.W:
                            //TODO 14. Engage battle sequence
                            //TODO 15. Handle if the player wins
                            break;
                        case ConsoleKey.S:
                            Console.WriteLine("~~~ Spy Room ~~~");
                            //TODO 15. Need to add in spy mechanic based on # of spies success or fail.
                            Console.WriteLine(enemyNpcCountry);
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Retreat!");
                            //TODO 12. Handle running away and getting a new room
                            //TODO 13. Monster gets a free attack
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("You no longer wish to play this country");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Sorry I don't understand your command, try again.");
                            break;
                    }
                    #endregion

                } while (!exit && !reload); //while exit is NOT true AND reload is NOT true keep looping
            } while (!exit);
        }

        private static string FindCountry()
        {
            string[] countries = {
                "Russia",
                "China",
                "Australia",
                "England",
                "Germany",
                "France",
                "Sweden",
                "Brazil",
                "Canada",
                "Mexico"
            };

            Random rand = new Random();

            int indexNbr = rand.Next(countries.Length);

            string room = countries[indexNbr];

            return room;
        }
    }
}
