using Tamagotchi;

Kompis tamagotchi = new Kompis();

tamagotchi.Name = "";
while (tamagotchi.Name == ""){
Console.WriteLine("Tjena polarn! vad ska din kompis heta?");
tamagotchi.Name = Console.ReadLine();
}

while (tamagotchi.GetAlive())
{
    bool ParseWorks = false;
    int DoSomethingInt = 1;


    while (!ParseWorks || DoSomethingInt > 5 && DoSomethingInt < 1)
    {
        Console.WriteLine("Vad vill du?\n1.Stats\n2.Mata\n3.Lär ord\n4.Tala\n5.Ingenting\n(svara i siffror)");
        string DoSomething = Console.ReadLine();
        ParseWorks = int.TryParse(DoSomething, out DoSomethingInt);
    }
    if (DoSomethingInt == 1)
    {
        tamagotchi.PrintStats();
        tamagotchi.Tick();
    }
    if (DoSomethingInt == 2)
    {
        tamagotchi.Feed();
        tamagotchi.Tick();
    }
    if (DoSomethingInt == 3)
    {
        Console.WriteLine("Vad vill du lära din homie för ord?");
        string OrdLära = Console.ReadLine();
        tamagotchi.Teach(OrdLära);
        tamagotchi.Tick();
    }
    if (DoSomethingInt == 4)
    {
        tamagotchi.Hi();
    }
    if (DoSomethingInt == 5)
    {
        tamagotchi.Tick();
    }
    tamagotchi.GetAlive();
    
}






























































































