namespace Primjer1;

public abstract class Vozilo
{
    public bool Upaljen { get; set; }
    public int Kilometri { get; private set; }

    public string Boja { get; set; }

    public void Vozi(int kilometri)
    {
        if (Upaljen)
        {
            Kilometri += kilometri;
        }
        else
        {
            throw new Exception("Upali vozilo prvo!");
        }
    }

    public bool Upali()
    {
        Upaljen = true;
        return true;
    }

    public bool Ugasi()
    {
        Upaljen = false;
        return false;
    }
}
