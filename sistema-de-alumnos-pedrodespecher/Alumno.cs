namespace sistema_de_alumnos_pedrodespecher;

// ETAPA 7 - Alumno hereda de Persona (": Persona") y ya no declara Nombre
// por su cuenta: ahora lo hereda.
// ETAPA 9 - Ademas de heredar de Persona, implementa IExportable.
// Sintaxis: la clase base va primero, despues las interfaces.
public class Alumno : Persona, IExportable
{
    public int Legajo { get; private set; }
    public double Nota1 { get; private set; }
    public double Nota2 { get; private set; }

    // ETAPA 7 - El constructor ahora recibe tambien el documento, y se lo
    // pasa a Persona con "base(...)" antes de ocuparse de lo propio (Legajo).
    public Alumno(string nombre, string documento, int legajo) : base(nombre, documento)
    {
        Legajo = legajo;
    }

    // ETAPA 5 - Unica puerta de entrada para las notas
    public bool CargarNotas(double nota1, double nota2)
    {
        if (nota1 < 0 || nota1 > 10 || nota2 < 0 || nota2 > 10)
        {
            return false;
        }

        Nota1 = nota1;
        Nota2 = nota2;
        return true;
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

    // ETAPA 8 - Su propia version de Presentarse, que menciona el legajo
    public override string Presentarse()
    {
        return "Hola, soy " + Nombre + ", alumno con legajo " + Legajo + ".";
    }

    // ETAPA 9 - Datos separados por punto y coma
    public string ExportarLinea()
    {
        return "ALUMNO;" + Legajo + ";" + Nombre + ";" + Promedio();
    }
}
