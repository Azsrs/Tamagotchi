using System;

namespace Tamagotchi;

public class Kompis
{
    public int Hunger { get; set; }

    private int _boredom = 0;
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
        int OrdSlump = Random.Shared.Next(_words.Count);
        Console.WriteLine($"{Name}: {_words[OrdSlump]}");
        Console.ReadLine();
        ReduceBoredom();
    }
    public void Teach(string word)
    {
        _words.Add(word);
        Tick();
        if (_boredom < 100)
        {
            _boredom -= 10;
        }
        else Console.WriteLine($"{Name}: Jag har redan kul brä");


    }
    public void Tick()
    {
        Hunger += 5;
        _boredom += 5;
    }


    public void PrintStats()
    {
        Console.WriteLine($"Hunger:{Hunger}\nBoredom:{_boredom}");
        Console.ReadLine();
    }


    public bool GetAlive()
    {
        if (Hunger == 100 || _boredom == 100)
        {
            _isAlive = false;
        }
        else _isAlive = true;
        return _isAlive;
    }
    private void ReduceBoredom()
    {
        _boredom -= 10;
    }


}
