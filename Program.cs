Console.Clear();

int opcion = 0;
do                                                  //Sistema
{
    Console.WriteLine("----Menu de acciones-----");
    Console.WriteLine("[1] Crear nueva B.D");
    Console.WriteLine("[2] Borar B.D existente");
    Console.WriteLine("[3] Muestra todas las B.D");
    Console.WriteLine("[4] Usar B.D existente");
    Console.WriteLine("[5] Finalizar programa");

    Console.WriteLine();

    Console.Write("Ingrese una opción: ");
    opcion = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcion)
    {
        case 1:                                     //Crear base de datos
        break;

        case 2:                                     //Borrar base de datos
        break;

        case 3:                                     //Mostrar bases de datos
        break;

        case 4:                                     //Usar base de datos
        break;

        case 5:                                     //Finalizar programa
        break;
        
        default:
            Console.Clear();
            Console.WriteLine("Opción no válida");
            Console.WriteLine();
        break;
    }
} while (opcion != 5);

