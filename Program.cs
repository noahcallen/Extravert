using System;
using System.Collections.Generic;

namespace Plant
{
    class Program
    {
      
        public static void Main()
        {
            List<Plant> plants = new List<Plant>
            {
                new Plant {Species = "Cactus", LightNeeded = "full sun", AskingPrice = 5, City = "Somerset", ZIP = 42503, Sold = false, AvailableUntil = new DateTime(2025, 08, 10)},
                new Plant {Species = "Bamboo", LightNeeded = "some sun", AskingPrice = 7, City = "Richmond", ZIP = 42507, Sold = true, AvailableUntil = new DateTime(2025, 09, 10)},
                new Plant {Species = "SugarCane", LightNeeded = "a lot sun", AskingPrice = 7, City = "Richmond", ZIP = 42507, Sold = false, AvailableUntil = new DateTime(2025, 07, 10)},
                new Plant {Species = "Fern", LightNeeded = "little sun", AskingPrice = 10, City = "Florence", ZIP = 41005, Sold = true, AvailableUntil = new DateTime(2025, 06, 10)},
                new Plant {Species = "DripLeaf", LightNeeded = "no sun", AskingPrice = 7, City = "Somerset", ZIP = 42503, Sold = false, AvailableUntil = new DateTime(2025, 05, 10)},
            };

            string userChoice;

            Random random = new Random();

            do
            {
                Console.WriteLine("Want Some Plants?");
                Console.WriteLine("Select one of the following options:");
                Console.WriteLine("\n a. Display all plants \n b. Add a plant to be adopted \n c. Adopt a plant \n d. Delist a plant \n e. Plant of the day \n f. Quit \n g. Search by Light Needed");

                Console.Write("Enter your choice: ");
                userChoice = Console.ReadLine();
                Console.WriteLine("=====================================");

                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine("All Plants:");
                        foreach (var plant in plants)
                        {
                            Console.WriteLine($"- {plant.Species}");
                        }
                        break;

                    case "b":
                        Console.Write("Enter Plant's Name: ");
                        string species = Console.ReadLine();

                        Console.Write("Enter Plant's needed amount of light: ");
                        string lightNeeded = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        if (!int.TryParse(Console.ReadLine(), out int askingPrice))
                        {
                            Console.WriteLine("Invalid price! Please enter a number.");
                            break;
                        }

                        Console.Write("Enter Location: ");
                        string city = Console.ReadLine();

                        Console.Write("Enter ZIP code: ");
                        if (!int.TryParse(Console.ReadLine(), out int zip))
                        {
                            Console.WriteLine("Invalid ZIP code! Please enter a number.");
                            break;
                        }
                        Console.Write("Enter the date that this plant is available until (yyyy/mm/dd): ");
                         if (!DateTime.TryParse(Console.ReadLine(), out DateTime availableUntil))
                        {
                            Console.WriteLine("Invalid price! Please enter a number.");
                            break;
                        }

                        plants.Add(new Plant
                        {
                            Species = species,
                            LightNeeded = lightNeeded,
                            AskingPrice = askingPrice,
                            City = city,
                            ZIP = zip,
                            Sold = false,
                            AvailableUntil = availableUntil
                        });

                        Console.WriteLine($"Successfully added {species} to the list!");
                        break;

                    case "c":
                        Console.WriteLine("Which Plant would you like to adopt?");
                        
                        bool plantsAvailable = false;

                        foreach (var plant in plants)
                        {
                          if (!plant.Sold)
                          {
                            Console.WriteLine($"- {plant.Species} for ${plant.AskingPrice}");
                            plantsAvailable = true;
                          }
                        }

                        if (!plantsAvailable)
                        {
                            Console.WriteLine("Sorry, no plants are currently available for adoption.");
                        }

                        Console.Write("Enter Plant Name: ");
                        string adopt = Console.ReadLine();

                        bool plantFound = false;

                        foreach (var plant in plants)
                        {
                            if (!plant.Sold && plant.Species.Equals(adopt))
                            {
                                plant.Sold = true;
                                Console.WriteLine($"You have successfully adopted the {plant.Species}!");
                                plantFound = true;
                                break;
                            }
                        }

                        break;

                    case "d":
                        foreach (var plant in plants)
                        {
                            Console.WriteLine($"- {plant.Species}");
                        }
                        Console.Write("Type the name of the plant you want to remove: ");
                        string remove = Console.ReadLine();

                        // Use a for loop to safely remove an item from the list
                        bool item = false;

                        for (int i = 0; i < plants.Count; i++)
                        {
                            if (plants[i].Species.Equals(remove))
                            {
                                plants.RemoveAt(i); // Remove the plant at index i
                                item = true;
                                Console.WriteLine($"{remove} has been removed from the list.");
                                break; // Exit the loop after removing the plant
                            }
                        }

                        if (!item)
                        {
                            Console.WriteLine($"No plant with the name \"{remove}\" was found.");
                        }
                        break;

                    case "e":
                        int randomInteger = random.Next(plants.Count);
                        Plant randomPlant = plants[randomInteger];
                        Console.WriteLine($"The Plant of the day is : {randomPlant.Species}");
                        
                        break;

                    case "f":
                        Console.WriteLine("Fine... Didn't want to give you a plant anyway >:/ !");
                        break;

                    case "g":
                Console.WriteLine("5. full sun | 4. a lot of sun | 3. some sun | 2. little sun | 1. no sun");
                Console.WriteLine("What Light Level Plants are you wanting to see?");
                Console.Write("Write your choice here: ");
                string lightChoice = Console.ReadLine();

                

                for (int i = 0; i < plants.Count; i++)
                {
                    // Case-insensitive comparison
                    if (plants[i].LightNeeded.Equals(lightChoice))
                    {
                        Console.WriteLine(plants[i].Species);
                        
                    }
                }

                // If no plants are found
                

                break;
  
                    default:
                        Console.WriteLine("Oops! Dumbass! You did not pick a valid option!");
                        break;
                }

                Console.WriteLine(); // Adds a blank line for readability

            } while (userChoice != "f"); // Continue looping until user enters "f"
        }
    }
}
