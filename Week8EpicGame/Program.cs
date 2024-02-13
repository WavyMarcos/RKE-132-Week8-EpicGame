//string[] heroes = { "Officer K.", "Scooby-Doo", "Lara Croft", "Hank Schrader", "Gandalf" };
//string[] villains = { "Gus Fring", "Niander Wallace", "Saul Goodman", "Oppenheimer" };
string folderPath = @"C:\Users\marco\Documents\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));


string[] weaponry = { "AK-47", "Nuclear Bomb", "Tactical banana", "Coke and mentos", "MOAB", "Droid blaster" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weaponry);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;

Console.WriteLine($"Today {hero} ({heroHP}HP) with {heroWeapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weaponry);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;

Console.WriteLine($"Today {villain} ({villainHP}HP) with {villainWeapon} tries to take over the world!");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");
if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine("Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rand = new Random();
    int randomIndex = rand.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length <10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}
static int Hit(string characterName, int characterHP)
{
    Random rand = new Random();
    int strike = rand.Next(0, characterHP);
    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");

    }
    else if (strike == characterHP - 1)  
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;

}