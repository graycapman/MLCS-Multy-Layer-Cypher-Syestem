using MLCS.Utilities;
using MLCS.Layers;
using MLCS.Core;
using System.Runtime.CompilerServices;
while (true)
{
System.Console.WriteLine("======================================");
System.Console.WriteLine("MLCS | Multy Layer Cypher System");
System.Console.WriteLine("======================================");
System.Console.WriteLine("1-Simple");
System.Console.WriteLine("2-Advance");
System.Console.WriteLine("3-Exit");
Console.ForegroundColor = ConsoleColor.DarkGray;
System.Console.WriteLine("MADE BY GREYCAPMAN");
Console.ResetColor();
System.Console.WriteLine("======================================");
string Choice = Console.ReadLine() ?? "";
    switch (Choice)
{
        case "1":
            RunSimpleMode();
                break;
        case "2":
            RunAdvanceMode();
                break;

        case "3":
            Environment.Exit(0);
                break;

        default:
            System.Console.WriteLine("wrong input");
                break;
}
}
void RunSimpleMode()

{
    System.Console.WriteLine("1-Enrypt");
    System.Console.WriteLine("2-decypt");
    string Choicesimple = Console.ReadLine() ?? "";
    switch (Choicesimple)
    {
        case "1":
        System.Console.WriteLine("enter the text");
            string text = Console.ReadLine() ?? "";
            System.Console.WriteLine("pls enter the seed (and remember it)");
            int TextSeed = Convert.ToInt32(Console.ReadLine());
            var seed = new List<int> {TextSeed};
            var Engine = new Engine(seed);
            string Encrypted = Engine.Encrypt(text);
            System.Console.WriteLine("Encypting is done : ");
            Console.ForegroundColor =ConsoleColor.Yellow;
            System.Console.WriteLine(Encrypted);
            Console.ResetColor();
             break;

        case "2":
        System.Console.WriteLine("enter the code");
            string code = Console.ReadLine() ?? "";
            System.Console.WriteLine("whats the seed");
            int CodeSeed = Convert.ToInt32(Console.ReadLine());
            var _seed = new List<int> {CodeSeed};
            var _Engine = new Engine(_seed);
            string Decrypted = _Engine.Decrypt(code);
            System.Console.WriteLine("Decrypting is done : ");
            Console.ForegroundColor =ConsoleColor.Yellow;
            System.Console.WriteLine(Decrypted);
            Console.ResetColor();
             break;
        default:
            System.Console.WriteLine("wrong input");
                break;
    }

}
void RunAdvanceMode()

        {
    System.Console.WriteLine("1-Enrypt");
    System.Console.WriteLine("2-decypt");
    string ChoiceAdvance = Console.ReadLine() ?? "";
    switch (ChoiceAdvance)
    {
        case "1":
        System.Console.WriteLine("enter the text");
            string text = Console.ReadLine() ?? "";
            var TextVal = Validation.Validatetext(text);
            if (!TextVal)
            {
                System.Console.WriteLine("type the text");
                return;
            }
            System.Console.WriteLine("pls enter the seed(s) (and remember it)");
            System.Console.WriteLine("seeds format : XXXX-YYYY-ZZZZ-...-NNNN");
            string TextSeed = Console.ReadLine() ?? "";
            var seeds = SeedParser.Parse(TextSeed);
            var engine = new Engine(seeds);
            string Encrypted = engine.Encrypt(text);
            System.Console.WriteLine("encrypting is done: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(Encrypted);
            Console.ResetColor();
             break;

        case "2":
        System.Console.WriteLine("enter the code");
            string code = Console.ReadLine() ?? "";
            System.Console.WriteLine("whats the seed(s)");
            string CodeSeed = Console.ReadLine() ?? "";
            var _seed = SeedParser.Parse(CodeSeed);
            var _engine = new Engine(_seed);
            string Decrypted = _engine.Decrypt(code);
            System.Console.WriteLine("decrypting is done: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(Decrypted);
            Console.ResetColor();
             break;
             default:
            System.Console.WriteLine("wrong input");
                break;
    }
        
    }
    
