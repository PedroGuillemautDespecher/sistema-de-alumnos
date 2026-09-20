using sistema_de_alumnos_pedrodespecher;

// Punto 2: creo dos alumnos con new y les cargo los datos
Alumno alumno1 = new Alumno();
alumno1.Nombre = "Ana Pérez";
alumno1.Legajo = 1234;
alumno1.Nota1 = 8;
alumno1.Nota2 = 6.5;

Alumno alumno2 = new Alumno();
alumno2.Nombre = "Juan Gómez";
alumno2.Legajo = 5678;
alumno2.Nota1 = 4;
alumno2.Nota2 = 7;

Console.WriteLine("--- Datos iniciales ---");
Console.WriteLine(alumno1.Nombre + " - " + alumno1.Legajo);
Console.WriteLine(alumno2.Nombre + " - " + alumno2.Legajo);

// Punto 3: cambio el nombre del primero y vuelvo a mostrar los dos
alumno1.Nombre = "Ana Gómez";

Console.WriteLine();
Console.WriteLine("--- Despues de cambiarle el nombre al primero ---");
Console.WriteLine(alumno1.Nombre + " - " + alumno1.Legajo);
Console.WriteLine(alumno2.Nombre + " - " + alumno2.Legajo);
