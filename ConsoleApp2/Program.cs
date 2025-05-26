using System;

Console.WriteLine("Pašreizējais datums un laiks: " + myConsole.tagad);

int skaitlis = myConsole.NolasitKaInt();
myConsole.Izvadit("Jūsu ievadītais skaitlis: " + skaitlis);

myConsole.NomainitFonaKrasu();
myConsole.NomainitBurtuKrasu();
myConsole.Izvadit("Fona un burtu krāsa nomainīta.");

myConsole.FormatetVardu("Ivars Zars");

string parole = myConsole.IzveidotParoli(10);
myConsole.Izvadit("Ģenerētā parole: " + parole);

string sifrets = myConsole.SifretTekstu("Hello, World!");
myConsole.Izvadit("Šifrēts teksts: " + sifrets);

string atsifrets = myConsole.AtsifretTekstu(sifrets);
myConsole.Izvadit("Atšifrēts teksts: " + atsifrets);


public class myConsole
{
    public static string tagad = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Assign current date and time

    public static int NolasitKaInt()
    {
        Console.Write("Ievadiet veselo skaitli: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("Konvertācija bija neveiksmīga.");
            return 0;
        }
    }

    public static void Izvadit(string text)
    {
        Console.WriteLine(text);
    }

    public static void NomainitFonaKrasu()
    {
        Random rand = new Random();
        Console.BackgroundColor = (ConsoleColor)rand.Next(0, 16);
        Console.Clear(); // Apply the background color change
    }

    public static void NomainitBurtuKrasu()
    {
        Random rand = new Random();
        Console.ForegroundColor = (ConsoleColor)rand.Next(0, 16);
    }

    public static void FormatetVardu(string vards_uzvards)
    {
        string[] parts = vards_uzvards.Split(' ');
        if (parts.Length == 2)
        {
            string formatted = $"{parts[0][0]}. {parts[1]}";
            Console.WriteLine(formatted);
        }
        else
        {
            Console.WriteLine("Nepareizs formāts.");
        }
    }

    public static string IzveidotParoli(int garums)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random rand = new Random();
        char[] password = new char[garums];
        for (int i = 0; i < garums; i++)
        {
            password[i] = chars[rand.Next(chars.Length)];
        }
        return new string(password);
    }

    public static string SifretTekstu(string teksts)
    {
        char[] chars = teksts.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i]++;
        }
        return new string(chars);
    }

    public static string AtsifretTekstu(string teksts)
    {
        char[] chars = teksts.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i]--;
        }
        return new string(chars);
    }
}



using System;

class Prece
{
    public string Nosaukums { get; set; }
    public double IepirksanasCena { get; set; }

    public void Izvadit()
    {
        Console.WriteLine($"Nosaukums: {Nosaukums}, Iepirkšanas cena: {IepirksanasCena}");
    }
}

class PartikasPrece : Prece
{
    public string DerigumaTermins { get; set; }
    public bool IrAlergisks { get; set; }
    public string Mervieniba { get; set; }
    public double PardosanasCena { get; private set; }

    public PartikasPrece()
    {
        PardosanasCena = IepirksanasCena + (IepirksanasCena * 0.30);
    }

    public void Registret()
    {
        Console.Write("Ievadiet nosaukumu: ");
        Nosaukums = Console.ReadLine();
        Console.Write("Ievadiet iepirkšanas cenu: ");
        IepirksanasCena = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ievadiet derīguma termiņu: ");
        DerigumaTermins = Console.ReadLine();
        Console.Write("Vai ir alerģisks (true/false): ");
        IrAlergisks = Convert.ToBoolean(Console.ReadLine());
        Console.Write("Ievadiet mērvienību: ");
        Mervieniba = Console.ReadLine();
        PardosanasCena = IepirksanasCena + (IepirksanasCena * 0.30);
    }

    public new void Izvadit()
    {
        base.Izvadit();
        Console.WriteLine($"Derīguma termiņš: {DerigumaTermins}, Ir alerģisks: {IrAlergisks}, Mērvienība: {Mervieniba}, Pārdošanas cena: {PardosanasCena}");
    }
}

class SaimniecibasPrece : Prece
{
    public string Materials { get; set; }
    public bool IrBistama { get; set; }
    public double PardosanasCena { get; private set; }

    public SaimniecibasPrece()
    {
        PardosanasCena = IepirksanasCena + (IepirksanasCena * 0.50);
    }

    public void Registret()
    {
        Console.Write("Ievadiet nosaukumu: ");
        Nosaukums = Console.ReadLine();
        Console.Write("Ievadiet iepirkšanas cenu: ");
        IepirksanasCena = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ievadiet materiālu: ");
        Materials = Console.ReadLine();
        Console.Write("Vai ir bīstama (true/false): ");
        IrBistama = Convert.ToBoolean(Console.ReadLine());
        PardosanasCena = IepirksanasCena + (IepirksanasCena * 0.50);
    }

    public new void Izvadit()
    {
        base.Izvadit();
        Console.WriteLine($"Materiāls: {Materials}, Ir bīstama: {IrBistama}, Pārdošanas cena: {PardosanasCena}");
    }
}

class Veikals
{
    public string Nosaukums { get; set; }
    public int PartikasPrecuSkaits { get; set; }
    public int SaimniecibasPrecuSkaits { get; set; }
    public PartikasPrece[] PartikasPreces { get; set; }
    public SaimniecibasPrece[] SaimniecibasPreces { get; set; }

    public void Registret()
    {
        Console.Write("Ievadiet veikala nosaukumu: ");
        Nosaukums = Console.ReadLine();
        Console.Write("Ievadiet pārtikas preču skaitu: ");
        PartikasPrecuSkaits = Convert.ToInt32(Console.ReadLine());
        PartikasPreces = new PartikasPrece[PartikasPrecuSkaits];
        for (int i = 0; i < PartikasPrecuSkaits; i++)
        {
            PartikasPreces[i] = new PartikasPrece();
            PartikasPreces[i].Registret();
        }

        Console.Write("Ievadiet saimniecības preču skaitu: ");
        SaimniecibasPrecuSkaits = Convert.ToInt32(Console.ReadLine());
        SaimniecibasPreces = new SaimniecibasPrece[SaimniecibasPrecuSkaits];
        for (int i = 0; i < SaimniecibasPrecuSkaits; i++)
        {
            SaimniecibasPreces[i] = new SaimniecibasPrece();
            SaimniecibasPreces[i].Registret();
        }
    }

    public void Izvadit()
    {
        Console.WriteLine($"Veikala nosaukums: {Nosaukums}");
        Console.WriteLine("Pārtikas preces:");
        foreach (var prece in PartikasPreces)
        {
            prece.Izvadit();
        }
        Console.WriteLine("Saimniecības preces:");
        foreach (var prece in SaimniecibasPreces)
        {
            prece.Izvadit();
        }
    }

    public void VeiklaTips()
    {
        if (PartikasPrecuSkaits > 0 && SaimniecibasPrecuSkaits > 0)
        {
            Console.WriteLine("Veikals ir lielveikals.");
        }
        else if (PartikasPrecuSkaits > 0)
        {
            Console.WriteLine("Veikals ir pārtikas veikals.");
        }
        else if (SaimniecibasPrecuSkaits > 0)
        {
            Console.WriteLine("Veikals ir saimniecības veikals.");
        }
    }

    public void AtlasitArpusTemina()
    {
        Console.WriteLine("Preces ar beigušos derīguma termiņu:");
        foreach (var prece in PartikasPreces)
        {
            if (DateTime.TryParse(prece.DerigumaTermins, out DateTime derigumaTermins) && derigumaTermins <= DateTime.Now)
            {
                prece.Izvadit();
            }
        }
    }

    public void AtlasitBistamus()
    {
        Console.WriteLine("Bīstamās saimniecības preces:");
        foreach (var prece in SaimniecibasPreces)
        {
            if (prece.IrBistama)
            {
                prece.Izvadit();
            }
        }
    }
}

// Demonstrācija
Veikals veikals = new Veikals();
veikals.Registret();
veikals.Izvadit();
veikals.VeiklaTips();
veikals.AtlasitArpusTemina();
veikals.AtlasitBistamus();

// 14
using System;
using System.IO;

class StudijuKurss
{
    public string Nosaukums;
    public int Kreditpunkti;
    public bool IrObligats;

    public double EKreditpunkti
    {
        get { return Kreditpunkti * 1.5; }
    }

    public void ReadData()
    {
        Console.Write("Ievadi kursa nosaukumu: ");
        Nosaukums = Console.ReadLine();

        Console.Write("Ievadi kredītpunktus (int): ");
        Kreditpunkti = int.Parse(Console.ReadLine());

        Console.Write("Vai kurss ir obligāts? (true/false): ");
        IrObligats = bool.Parse(Console.ReadLine());
    }

    public void PrintData()
    {
        Console.WriteLine($"Nosaukums: {Nosaukums}; KP: {Kreditpunkti}; EKP: {EKreditpunkti}; Obligāts: {IrObligats}");
    }
}

class Program
{
    static void FillArray(StudijuKurss[] kurss)
    {
        for (int i = 0; i < kurss.Length; i++)
        {
            kurss[i] = new StudijuKurss();
            Console.WriteLine($"\nKursa {i + 1}:");
            kurss[i].ReadData();
        }
    }

    static void PrintArray(StudijuKurss[] kurss)
    {
        foreach (var k in kurss)
        {
            k.PrintData();
        }
    }

    static void PrintArrayToFile(StudijuKurss[] kurss)
    {
        using (StreamWriter sw = new StreamWriter("kursi.txt"))
        {
            foreach (var k in kurss)
            {
                sw.WriteLine($"{k.Nosaukums};{k.Kreditpunkti};{k.EKreditpunkti};{k.IrObligats}");
            }
        }
    }

    static StudijuKurss[] ReadArrayFromFile()
    {
        string[] lines = File.ReadAllLines("kursi.txt");
        StudijuKurss[] kursi = new StudijuKurss[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            kursi[i] = new StudijuKurss
            {
                Nosaukums = parts[0],
                Kreditpunkti = int.Parse(parts[1]),
                IrObligats = bool.Parse(parts[3])
            };
        }

        return kursi;
    }

    static void Main()
    {
        Console.Write("Cik kursus ievadīsi? ");
        int n = int.Parse(Console.ReadLine());

        StudijuKurss[] kursi1 = new StudijuKurss[n];
        FillArray(kursi1);
        PrintArrayToFile(kursi1);

        StudijuKurss[] kursi2 = ReadArrayFromFile();
        Console.WriteLine("\nNolasītie kursi no faila:");
        PrintArray(kursi2);

        // 2. Uzdevums – izņēmumi
        Console.WriteLine("\n--- IZŅĒMUMU DEMONSTRĀCIJA ---");

        try
        {
            int x = 10, y = 0;
            Console.WriteLine(x / y);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Dalīšana ar 0: {e.GetType()} - {e.Message}");
        }

        try
        {
            int skaitlis = int.Parse("abc");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Nepareiza konvertēšana: {e.GetType()} - {e.Message}");
        }

        try
        {
            string saturs = File.ReadAllText("neeksistējošs_fails.txt");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Fails nav atrasts: {e.GetType()} - {e.Message}");
        }

        try
        {
            int[] masivs = new int[2];
            Console.WriteLine(masivs[5]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Masīva indekss ārpus robežām: {e.GetType()} - {e.Message}");
        }

        try
        {
            string teksts = "abc";
            Console.WriteLine(teksts[10]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Simbolrindas indekss ārpus robežām: {e.GetType()} - {e.Message}");
        }
    }
}
