
using System.Data.SqlTypes;

string folderPath = @"";
string heroFile = "";
string villainFile = "";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath + villainFile));


//string[] heroes = {"Harry", "Luke", "Lara", "Scooby" };
//string[] villains = { "Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron" };
string[] weapons = { "gun", "sword", "plastic fork", "bow", "banana" };


string hero = GetRandomValueFromArray(heroes);
int heroHP = GetCharacterHP(hero);
int herostrike = heroHP;
string heroWeapon = GetRandomValueFromArray(weapons);
Console.WriteLine($"Today {hero} {heroHP} saves the day with a {heroWeapon}!");

string villain = GetRandomValueFromArray(villains);
string viWeapon = GetRandomValueFromArray(weapons);
int villainHP = GetCharacterHP(villain);
int villainstrike = villainHP;
Console.WriteLine($"Today {villain} {villainHP} tries to take over the world with a {viWeapon}!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainstrike);
    villainHP = villainHP - Hit(hero, herostrike);
}

Console.WriteLine($"Hero {hero} has {heroHP} HP");
Console.WriteLine($"Villain {villain} has {villainHP} HP");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Its a draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string charaterName)
{
    if (charaterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return charaterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");

    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");

    }
    return strike;
}