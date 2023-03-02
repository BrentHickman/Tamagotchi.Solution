using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int Food { get; set; }
    public int Happy{ get; set; }
    public int Energy { get; set; }
    private static List<Pet> _instances = new List<Pet> { };

    public Pet(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Food = 5;
      Happy = 5;
      Energy = 5;
    }

    public static void Eat(int passedInId)
    {
      Pet petToFeed = Pet.Find(passedInId);
      petToFeed.Food = petToFeed.Food + 4;
      petToFeed.Happy = petToFeed.Happy + 1;
      petToFeed.Energy = petToFeed.Energy -1;
    }

    public static void Play(int passedInId)
    {
      Pet petToPlay = Pet.Find(passedInId);
      petToPlay.Food = petToPlay.Food - 1;
      petToPlay.Happy = petToPlay.Happy + 4;
      petToPlay.Energy = petToPlay.Energy - 2;
    }
    public static void Rest(int passedInId)
    {
      Pet petToRest = Pet.Find(passedInId);
      petToRest.Food = petToRest.Food - 2;
      petToRest.Happy = petToRest.Happy + 1;
      petToRest.Energy = petToRest.Energy + 3;
    }

    public static void EndDay()
    {
      foreach (Pet tamagotchi in _instances)
      {
        tamagotchi.Food = tamagotchi.Food - 2;
        tamagotchi.Happy = tamagotchi.Happy - 1;
        tamagotchi.Energy = tamagotchi.Energy - 1;
      }
    }

    public static void DeathCheck()
    {
      foreach (Pet tamagotchi in _instances)
      {
        if(tamagotchi.Food < 0 || tamagotchi.Happy < 0 || tamagotchi.Energy < 0)
        {
          tamagotchi.Name = tamagotchi.Name + " is Dead!";
        }
      }
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
