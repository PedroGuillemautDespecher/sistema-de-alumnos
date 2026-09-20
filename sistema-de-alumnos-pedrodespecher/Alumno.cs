namespace sistema_de_alumnos_pedrodespecher;

public class Alumno
{
    public string Nombre { get; set; }
    public int Legajo { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }

    // ETAPA 2 - Constructor
    public Alumno(string nombre, int legajo, double nota1, double nota2)
    {
        Nombre = nombre;
        Legajo = legajo;
        Nota1 = nota1;
        Nota2 = nota2;
    }

    // ETAPA 3 - Metodos
    public double Promedio()
    {
        return (Nota1 + Nota2) / 2;
    }

    public bool EstaAprobado()
    {
        return Promedio() >= 6;
    }

    public void SubirNota()
    {
        Nota1 = Math.Min(Nota1 + 1, 10);
        Nota2 = Math.Min(Nota2 + 1, 10);
    }

    // ETAPA 4 - ToString
   
    public override string ToString()
    {
        return Legajo + " - " + Nombre + " (promedio: " + Promedio() + ")";
    }
}
