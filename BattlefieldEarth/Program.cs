using System;
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

            //create a country
            Country playerCountry = new Country(10000, 2000, "Cobra Empire", 100, 70, 
                new Government(GovernmentType.Democracy), 
                new Military(2000, 5000, 10000, 5000, 2000, 10)
                );

            int defeated = 0;

            //create a loop for the country location
            bool exit = false;
            do
            {
                //create a country
                Console.WriteLine($"Your opponent: {FindCountry()}");

                //Create an opponent 
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

                //Create a loop for the menu
                bool reload = false;
                do
                {
                    //Create a menu of options that tells the player what they can do
                    #region MENU
                    Console.WriteLine("\nWhat is your next move?\n" +
                        "V) Visit Country Advisor\n" +
                        "A) Attack\n" +
                        "S) Spy on Enemy\n" +
                        "R) Retreat\n" +
                        "X) Exit");

                    //Catch the users input
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //Clear the console after the user input to clean up the screen
                    Console.Clear();

                    //Build out a switch for userChoice
                    switch (userChoice)
                    {
                        case ConsoleKey.V:
                            // View status of your country
                            Console.WriteLine(playerCountry);
                            break;
                        case ConsoleKey.A:
                            //Engage battle sequence
                            //Handle if the player wins
                            Battle.WarSequence(playerCountry, enemyNpcCountry);
                            if (enemyNpcCountry.Population <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n{enemyNpcCountry.CountryName} has been defeated! They have no more civilans!\n");
                                Console.ResetColor();
                                reload = true;
                                defeated++;
                            }
                            break;
                        case ConsoleKey.S:
                            Console.WriteLine("~~~ Spy Room ~~~");
                            Console.WriteLine(enemyNpcCountry);
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Retreat!");
                            //Retreat and getting a new Country
                            //Civilans flee due to retreat
                            int civsFlee = rand.Next(50, 101);
                            playerCountry.Population -= civsFlee;
                            Console.WriteLine($"{civsFlee} Civilians Flee your country!");
                            reload = true;
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

                    //Check playerCountry for population
                    if (playerCountry.Population <= 0)
                    {
                        Console.WriteLine($"{playerCountry.CountryName} has been conquered!\n");
                        exit = true;
                    }

                } while (!exit && !reload);

            } while (!exit);

            Console.WriteLine("{0} {1}",
                defeated < 1 ? "You didn't defeat anyone!" : "",
                defeated > 1 ? $"You defeated {defeated} countries!" : ""
                );
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
