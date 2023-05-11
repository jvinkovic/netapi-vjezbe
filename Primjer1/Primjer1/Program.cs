using Primjer1;

Console.WriteLine("Hello, World!");

var auto = new Auto();
auto.Boja = "Plava";

Console.WriteLine(auto.Boja);

var kamion = new Kamion();
kamion.Boja = "Siva";
kamion.ImaPrikolicu = true;

try
{
    auto.Vozi(50);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine(auto.Kilometri);

var autoSKlimom = new SkupiAuto();
autoSKlimom.UpaliKlimu();

var vozila = new List<Vozilo>();
var vozilaArr = new Vozilo[5];

vozila.Add(auto);
vozila.Add(autoSKlimom);
vozila.Add(kamion);

Console.WriteLine(vozila.Count);
