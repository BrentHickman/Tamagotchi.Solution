using System.Collections.Generic;

namespace Pet.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public int Id { get; }
    public int Food;
    public int Happy;
    public int Energy;
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

    public static void Eat()
    {
      Food = Food + 4;
      Happy = Happy + 1;
      Energy = Energy -1;
    }

    public static void Play()
    {
      Food = Food - 1;
      Happy = Happy + 4;
      Energy = Energy - 2;
    }
    public static void Rest()
    {
      Food = Food - 2;
      Happy = Happy + 1;
      Energy = Energy + 3;
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
