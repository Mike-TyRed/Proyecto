Console.Clear();

int opcion = 0;
do                                                  //Sistema
{
    Console.WriteLine("----Menu de acciones-----");
    Console.WriteLine("[1] Crear nueva B.D");
    Console.WriteLine("[2] Borrar B.D existente");
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
            CrearBD();
            break;

        case 2:                                     //Borrar base de datos
            BorrarBD();
            break;

        case 3:                                     //Mostrar bases de datos
            MostrarBD();
            break;

        case 4:                                     //Usar base de datos
            UsarBD();
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

static void CrearBD()                               //Método creación base de datos (carpeta)
{
    Console.Write("Ingresa el nombre de la base de datos: ");
    string name = Console.ReadLine();

    string path = Directory.GetCurrentDirectory() + @"\" + name;

    Console.Clear();
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
        Console.Write("Base de datos " + name + " creada");
        Console.ReadLine();
    }
}

static void BorrarBD(){                             //Método borrar base de datos

}

static void MostrarBD(){                            //Método mostrar base de datos

}

static void UsarBD(){                               //Método usar base de datos

}