using System;

namespace Tamagotchi;

public class Kompis
{
    private int _hunger = 0;
    private int _boredom = 0;
    private List<string> _words = [];
    private bool _isAlive;
    public string Name;

    public void Feed()
    {
        Console.WriteLine("omnomnom");
        Console.ReadLine();
        _hunger -= 10;
    }
    public void Hi()
    {
        int OrdSlump = Random.Shared.Next(_words.Count);
        Console.WriteLine($"{Name}: {_words[OrdSlump]}");
        Console.ReadLine();
    }
    public void Teach(string word)
    {
        _words.Add(word);
        Tick();            
    }
    public void Tick()
    {
        _hunger += 5;
        _boredom += 5;
    }
    
    
    public void PrintStats()
    {
        Console.WriteLine($"Hunger:{_hunger}\nBoredom:{_boredom}");
        Console.ReadLine();
    }
   
   
    public bool GetAlive()
    {
        if (_hunger == 100 || _boredom == 100)
        {
            _isAlive = false;
        }
        else _isAlive = true;
        return _isAlive;
    }
    private void ReduceBoredom()
    {

    }


}
