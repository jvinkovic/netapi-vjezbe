// objekt i itd.

public interface IKlima{
    bool KlimaUpaljena {get;set;}

    bool UpaliKlimu();
}

public abstract class Vozilo {
    public int Kilometri {get;set;}
    public string Boja {get;set;}

    public bool Upali() {        
        return true;
    }

    public bool OtvoriGepek();
}

public class Auto : Vozilo, IKlima {
    public bool KlimaUpaljena {get;set;}

    public bool UpaliKlimu() {
        KlimaUpaljena = true;

        return true;
    }
}

public class Kamion : Vozilo, IKlima {
    public int Nosivost{get;set;}
    public bool KlimaUpaljena {get;set;}
    public bool ProzorOtvoren {get;set;}

    public bool UpaliKlimu() {
        KlimaUpaljena = true;
        ProzorOtvoren = true;

        return true;
    }
}

var auto = new Auto();
((IKlima)auto).UpaliKlimu()