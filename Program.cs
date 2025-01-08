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
        new Plant {Species = "Cactus", LightNeeded = "full sun", AskingPrice = 5, City = "Somerset", ZIP = 42503, Sold = false},
        new Plant {Species = "Bamboo", LightNeeded = "some sun", AskingPrice = 7, City = "Richmond", ZIP = 42507, Sold = true},
        new Plant {Species = "SugarCane", LightNeeded = "a lot sun", AskingPrice = 7, City = "Richmond", ZIP = 42507, Sold = false},
        new Plant {Species = "Fern", LightNeeded = "little sun", AskingPrice = 10, City = "Florence", ZIP = 41005, Sold = true},
        new Plant {Species = "DripLeaf", LightNeeded = "no sun", AskingPrice = 7, City = "Somerset", ZIP = 42503, Sold = false},
      };

      Console.WriteLine("Want Some Plants?");

      foreach (var plant in plants)
      {
        Console.WriteLine($"Species: {plant.Species} | Light Needed: {plant.LightNeeded} | Asking Price: {plant.AskingPrice}, {plant.Sold} | Location: {plant.City},{plant.ZIP}");
      }
    }

  }
}
