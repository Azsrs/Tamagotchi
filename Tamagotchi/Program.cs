
using Tamagotchi;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;

Kompis tamagotchi = new Kompis();

string LaddaSave = AskIfLoad();

TakeAnswerForLoad(LaddaSave);

tamagotchi.Name = "";
while (tamagotchi.Name == "")
{
    Console.WriteLine("Tjena polarn! vad ska din kompis heta?");
    tamagotchi.Name = Console.ReadLine();
}


string t = JsonSerializer.Serialize(tamagotchi);

MakeSave();



while (tamagotchi.GetAlive())
{
    bool ParseWorks = false;
    int DoSomethingInt = 1;

    //Ta emot spelarval och neka felaktiga svar
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

//Om tamagochin är död, visa död meddelande och stäng
if (!tamagotchi.GetAlive())
{
    Console.WriteLine($"{tamagotchi.Name} är död och det är ditt fel");
    Console.ReadLine();
}

static string AskIfLoad()
{
    Console.WriteLine("Vill du ladda en save bror? [Y/N]");
    string LaddaSave = Console.ReadLine().ToLower();
    while (LaddaSave != "y" && LaddaSave != "n")
    {
        Console.WriteLine("Vill du ladda en save bror? [Y/N]");
        LaddaSave = Console.ReadLine().ToLower();
    }
    return LaddaSave;
}

static void TakeAnswerForLoad(string LaddaSave)
{
    if (LaddaSave == "y")
    {
        if (File.Exists(@"save.txt"))
        {
            //LADDA SAVE HÄR 
        }
        else
        {
            Console.WriteLine("DU HAR INGEN SAVE PAJAS!!! VI BÖRJAR OM FRÅN BÖRJAN");
            Console.ReadLine();
        }
    }
    if (LaddaSave == "n") { }
}

void MakeSave()
{
    if (!Directory.Exists(@"Savegames"))
    {
        Directory.CreateDirectory(@"Savegames");
    }
    if (File.Exists(@"Savegames\Save.txt"))
    {
        YesOrNo("Du har redan en vän... vill du byta ut den?",
        () =>
        {
            
        }
        ,
        () => { Console.WriteLine("okej skit i då"); }
        );

    }
    var a = File.Create(@"Savegames\Save.txt");
    a.Close();
    string SaveSerialized = JsonSerializer.Serialize<Kompis>(tamagotchi);
    File.WriteAllText(@"Savegames\Save.txt", SaveSerialized);

}


static void YesOrNo(string question, Action yes, Action no)
{
    Console.WriteLine(question);
    string svar = Console.ReadLine().ToLower();

    while (svar != "y" && svar != "n")
    {
        Console.WriteLine(question);
        svar = Console.ReadLine();
    }
    if (svar == "y")
    {
        yes();
    }
    else
    {
        no();
    }
}

