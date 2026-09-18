using System;
using System.Dynamic;

namespace Tamagotchi;

public class Kompis
{
    public int Hunger { get; set; }

    public int Boredom {get; set;}
    private List<string> _words = [];
    private bool _isAlive;
    public string Name { get; set; }


    public void Feed()
    {
        Console.WriteLine("omnomnom");
        Console.ReadLine();
        if (Hunger < 100)
        {
            Hunger -= 10;
        }
        else Console.WriteLine($"{Name}: Jag är mätt brä");
    }
    public void Hi()
    {
        if (_words.Count == 0)
        {
            Console.WriteLine($"{Name} kan inte prata för du har inte lärt den något att säga\nDu är självisk och kommer dö ensam");
            Console.ReadLine();
        }
        else {
        int OrdSlump = Random.Shared.Next(_words.Count);
        Console.WriteLine($"{Name}: {_words[OrdSlump]}");
        Console.ReadLine();
        ReduceBoredom();
        }
    }
    public void Teach(string word)
    {
        _words.Add(word);
        Tick();
        if (Boredom < 100)
        {
            Boredom -= 10;
        }
        else Console.WriteLine($"{Name}: Jag har redan kul brä");


    }
    public void Tick()
    {
        Hunger += 5;
        Boredom += 5;
    }


    public void PrintStats()
    {
        Console.WriteLine($"Hunger:{Hunger}\nBoredom:{Boredom}");
        Console.ReadLine();
    }


    public bool GetAlive()
    {
        if (Hunger == 100 || Boredom == 100)
        {
            _isAlive = false;
        }
        else _isAlive = true;
        return _isAlive;
    }
    private void ReduceBoredom()
    {
        
        Boredom -= 10;
        if (Boredom <= 0)
        {
            Console.WriteLine($"{Name} är tillfredställd, BETE DIG!");
            Console.ReadLine();
        }
    }


}
