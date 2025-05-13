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
