namespace sistema_de_alumnos_pedrodespecher;

// ETAPA 9 - Materia no hereda de Persona: no es una persona.
public class Materia : IExportable
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public int Horas { get; private set; }

    public Materia(string codigo, string nombre, int horas)
    {
        Codigo = codigo;
        Nombre = nombre;
        Horas = horas;
    }

    public string ExportarLinea()
    {
        return "MATERIA;" + Codigo + ";" + Nombre + ";" + Horas;
    }
}
