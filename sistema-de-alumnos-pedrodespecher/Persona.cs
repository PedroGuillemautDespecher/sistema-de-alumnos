namespace sistema_de_alumnos_pedrodespecher;

// ETAPA 7 - Lo que comparten Alumno y Profesor: nombre y documento.
public class Persona
{
    public string Nombre { get; set; }
    public string Documento { get; set; }

    public Persona(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    // ETAPA 8 - Polimorfismo
    // Al sacar la palabra "virtual" de aca, el compilador tira 3 errores,
    // uno por cada clase que intenta hacerle override:
    //   Error CS0506: 'Alumno.Presentarse()': no se puede invalidar el
    //   miembro heredado 'Persona.Presentarse()' porque no esta marcado
    //   como virtual, abstracto o reemplazo. (mismo error en Profesor y Preceptor)
    // Por que aparece: "override" le pide permiso a la clase padre para
    // reemplazar el metodo, y ese permiso lo da unicamente "virtual".
    // Sin virtual, Presentarse() queda fijo en Persona y nadie lo puede tocar.
    public virtual string Presentarse()
    {
        return "Hola, soy " + Nombre + ".";
    }
}
