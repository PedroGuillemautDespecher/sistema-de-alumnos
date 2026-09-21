using sistema_de_alumnos_pedrodespecher;

// ============================================================
// Datos de partida
// ============================================================
Alumno alumno1 = new Alumno("Ana Pérez", "40111222", 1234);
alumno1.CargarNotas(8, 6);

Alumno alumno2 = new Alumno("Juan Gómez", "40333444", 5678);
alumno2.CargarNotas(4, 7);

Profesor profesor1 = new Profesor("Marta Díaz", "20555666", "Programación");
Preceptor preceptor1 = new Preceptor("Carlos Ruiz", "18777888", "Mañana");

List<Alumno> alumnos = new List<Alumno> { alumno1, alumno2 };

// ============================================================
// ETAPA 7 - Herencia
// alumno1.Nombre funciona aunque Alumno.cs ya no declara "Nombre":
// lo hereda de Persona. Si esto compila y lo imprime, la herencia anda.
// ============================================================
Console.WriteLine("--- Etapa 7: herencia ---");
Console.WriteLine("alumno1.Nombre (heredado de Persona) = " + alumno1.Nombre);
Console.WriteLine("alumno1.Documento (heredado de Persona) = " + alumno1.Documento);

// ============================================================
// ETAPA 8 - Polimorfismo
// Una lista de Persona con alumno, profesor y preceptor mezclados.
// El foreach llama siempre a Presentarse(), y cada objeto responde
// distinto segun su tipo REAL, no segun el tipo de la lista (Persona).
// ============================================================
Console.WriteLine();
Console.WriteLine("--- Etapa 8: polimorfismo ---");
List<Persona> personas = new List<Persona> { alumno1, profesor1, preceptor1 };

foreach (Persona persona in personas)
{
    Console.WriteLine(persona.Presentarse());
}

// ============================================================
// ETAPA 9 - Interfaces
// Alumno, Profesor y Materia no comparten clase base (Materia no es
// una Persona), pero los tres saben ExportarLinea().
// ============================================================
Console.WriteLine();
Console.WriteLine("--- Etapa 9: interfaces ---");
Materia materia1 = new Materia("PROG1", "Programación I", 128);
Materia materia2 = new Materia("BD1", "Bases de Datos I", 96);

List<IExportable> exportables = new List<IExportable> { alumno1, profesor1, materia1, materia2 };

foreach (IExportable item in exportables)
{
    Console.WriteLine(item.ExportarLinea());
}

// ============================================================
// ETAPA 9 - Al agregar "string ExportarEncabezado();" a IExportable
// (sin implementarlo en ninguna clase), el compilador tira 3 errores,
// uno por cada clase que implementa la interfaz:
//   Error CS0535: 'Materia' no implementa el miembro de interfaz
//   'IExportable.ExportarEncabezado()'
//   Error CS0535: 'Alumno' no implementa el miembro de interfaz
//   'IExportable.ExportarEncabezado()'
//   Error CS0535: 'Profesor' no implementa el miembro de interfaz
//   'IExportable.ExportarEncabezado()'
// Por que aparece: implementar una interfaz es una promesa. Si la
// interfaz agrega un metodo nuevo, automaticamente TODAS las clases que
// la implementan quedan en falta hasta que lo agreguen. Por eso se sacó
// el metodo de vuelta.
// ============================================================

// ============================================================
// ETAPA 6 - Muchos objetos: menu que funciona hasta elegir salir
// ============================================================
Console.WriteLine();
Console.WriteLine("--- Etapa 6: menu ---");

bool salir = false;
while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("1. Agregar alumno");
    Console.WriteLine("2. Listar alumnos");
    Console.WriteLine("3. Buscar alumno por legajo");
    Console.WriteLine("4. Promedio general del curso");
    Console.WriteLine("5. Cantidad de alumnos aprobados");
    Console.WriteLine("6. Salir");
    Console.Write("Elegí una opción: ");
    string opcion = Console.ReadLine()!; // "!" = confiamos en que no va a ser null

    switch (opcion)
    {
        case "1":
            AgregarAlumno(alumnos);
            break;
        case "2":
            ListarAlumnos(alumnos);
            break;
        case "3":
            BuscarPorLegajo(alumnos);
            break;
        case "4":
            MostrarPromedioGeneral(alumnos);
            break;
        case "5":
            MostrarAprobados(alumnos);
            break;
        case "6":
            salir = true;
            Console.WriteLine("Saliendo del sistema...");
            break;
        default:
            Console.WriteLine("Opción inválida. Intentá de nuevo.");
            break;
    }
}

// ------------------ funciones del menu ------------------

static void AgregarAlumno(List<Alumno> alumnos)
{
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine()!;
    Console.Write("Documento: ");
    string documento = Console.ReadLine()!;
    Console.Write("Legajo: ");
    int legajo = int.Parse(Console.ReadLine()!);
    Console.Write("Nota 1: ");
    double nota1 = double.Parse(Console.ReadLine()!);
    Console.Write("Nota 2: ");
    double nota2 = double.Parse(Console.ReadLine()!);

    Alumno nuevo = new Alumno(nombre, documento, legajo);
    if (nuevo.CargarNotas(nota1, nota2))
    {
        alumnos.Add(nuevo);
        Console.WriteLine("Alumno agregado.");
    }
    else
    {
        Console.WriteLine("Notas inválidas (tienen que estar entre 0 y 10). No se agregó el alumno.");
    }
}

static void ListarAlumnos(List<Alumno> alumnos)
{
    if (alumnos.Count == 0)
    {
        Console.WriteLine("No hay alumnos cargados.");
        return;
    }

    foreach (Alumno alumno in alumnos)
    {
        Console.WriteLine(alumno);
    }
}

static void BuscarPorLegajo(List<Alumno> alumnos)
{
    Console.Write("Legajo a buscar: ");
    int legajo = int.Parse(Console.ReadLine()!);

    foreach (Alumno alumno in alumnos)
    {
        if (alumno.Legajo == legajo)
        {
            Console.WriteLine(alumno);
            return;
        }
    }

    Console.WriteLine("No existe ningún alumno con legajo " + legajo);
}

static void MostrarPromedioGeneral(List<Alumno> alumnos)
{
    if (alumnos.Count == 0)
    {
        Console.WriteLine("Todavía no hay alumnos cargados.");
        return;
    }

    double suma = 0;
    foreach (Alumno alumno in alumnos)
    {
        suma += alumno.Promedio();
    }

    Console.WriteLine("Promedio general del curso: " + (suma / alumnos.Count));
}

static void MostrarAprobados(List<Alumno> alumnos)
{
    int aprobados = 0;
    foreach (Alumno alumno in alumnos)
    {
        if (alumno.EstaAprobado())
        {
            aprobados++;
        }
    }

    Console.WriteLine("Alumnos aprobados: " + aprobados + " de " + alumnos.Count);
}
