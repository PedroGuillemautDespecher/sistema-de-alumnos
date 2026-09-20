using sistema_de_alumnos_pedrodespecher;

// ETAPA 2: ahora cada alumno se crea en UNA sola linea
Alumno alumno1 = new Alumno("Ana Pérez", 1234, 8, 6);
Alumno alumno2 = new Alumno("Juan Gómez", 5678, 4, 7);
Alumno alumno3 = new Alumno("Lucía Fernández", 9012, 9.5, 10);

// ETAPA 2 - punto 3: probar new Alumno() sin datos.
// Al descomentar la linea de abajo, el compilador tira:
//   Error CS7036: No se ha dado ningun argumento que corresponda al parametro
//   requerido 'nombre' de 'Alumno.Alumno(string, int, double, double)'
// Por que aparece: al escribir un constructor propio, C# deja de regalar el
// constructor vacio que venia por defecto. Desde ahora un Alumno no puede
// nacer sin sus datos, que es justamente lo que buscabamos.
// Alumno vacio = new Alumno();

// ETAPA 3: cada objeto calcula con SUS propias notas
Console.WriteLine("--- Promedios (Etapa 3) ---");
Console.WriteLine(alumno1.Nombre + " -> promedio " + alumno1.Promedio() + " | aprobado: " + alumno1.EstaAprobado());
Console.WriteLine(alumno2.Nombre + " -> promedio " + alumno2.Promedio() + " | aprobado: " + alumno2.EstaAprobado());

Console.WriteLine();
Console.WriteLine("--- SubirNota() ---");
Console.WriteLine("Antes:   " + alumno2.Nombre + " tiene " + alumno2.Nota1 + " y " + alumno2.Nota2);
alumno2.SubirNota();
Console.WriteLine("Despues: " + alumno2.Nombre + " tiene " + alumno2.Nota1 + " y " + alumno2.Nota2 + " -> aprobado: " + alumno2.EstaAprobado());

Console.WriteLine("Antes:   " + alumno3.Nombre + " tiene " + alumno3.Nota1 + " y " + alumno3.Nota2);
alumno3.SubirNota();
Console.WriteLine("Despues: " + alumno3.Nombre + " tiene " + alumno3.Nota1 + " y " + alumno3.Nota2 + " (ninguna paso de 10)");

// ETAPA 4: ToString
Console.WriteLine();
Console.WriteLine("--- ToString (Etapa 4) ---");
Console.WriteLine(alumno1);
Console.WriteLine(alumno2);
Console.WriteLine(alumno3);
