namespace sistema_de_alumnos_pedrodespecher;

public class Preceptor : Persona
{
    public string Turno { get; private set; }

    public Preceptor(string nombre, string documento, string turno) : base(nombre, documento)
    {
        Turno = turno;
    }

    public override string Presentarse()
    {
        return "Hola, soy " + Nombre + " y soy preceptor del turno " + Turno + ".";
    }
}
