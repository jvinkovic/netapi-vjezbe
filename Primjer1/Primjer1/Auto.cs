namespace Primjer1;

public class Auto : Vozilo
{
}

public class SkupiAuto : Auto, IKlima
{
    public bool KlimaUpaljena { get; set; }

    public void UpaliKlimu()
    {
        KlimaUpaljena = true;
    }
}
