public class Auto
{
    public string Gyarto { get; set; }
    public string Tipus { get; set; }
    public string Meghajtas { get; set; }
    public string Uzemanyag { get; set; }
    public int Ar { get; set; }

    public Auto(string sor)
    {
        var v = sor.Split(';');

        this.Gyarto = v[0];
        this.Tipus = v[1];
        this.Uzemanyag = v[2];
        this.Meghajtas = v[3];
        this.Ar = int.Parse(v[4]);
    }

    public override string ToString()
    {
        return $"{Gyarto} / {Tipus} / Üzemanyag: {Uzemanyag} / Meghajtás: {Meghajtas} / Ár: {Ar} Ft";
    }
}
