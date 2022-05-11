string comando = " ";
do
{
    List<Formato> filas = new List<Formato>();
    Console.Clear();

    Console.Write("");
    comando = Console.ReadLine();

    string[] cadena = comando.Split();

    if ((cadena[0] + " " + cadena[1]) == "crear database")
    {
        CrearBD(cadena);
    }
    if ((cadena[0] + " " + cadena[1]) == "borrar database")
    {
        BorrarBD(cadena);
    }
    if ((cadena[0] + " " + cadena[1]) == "mostrar database")
    {
        MostrarBD();
    }
    if ((cadena[0] + " " + cadena[1]) == "usar database")
    {
        UsarBD(cadena);
    }
    
} while (comando != "cerrar database");
Console.Clear();

static void CrearBD(string[] cadena)//Método creación base de datos (carpeta).
{
    string path = Directory.GetCurrentDirectory() + @"\db\" + cadena[2];

    Console.Clear();
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
        Console.Write("Base de datos " + cadena[2] + " creada con éxito.");
        Console.ReadLine();
    }
}

static void BorrarBD(string[] cadena)//Método borrar base de datos.
{
    string path = Directory.GetCurrentDirectory() + @"\db\" + cadena[2];

    try
    {
        Directory.Delete(path);
        Console.Clear();
        Console.Write("Base de datos " + cadena[2] + " borrada con éxito.");
        Console.ReadKey();
    }
    catch (System.IO.DirectoryNotFoundException e)
    {
        Console.Clear();
        Console.Write("No existe la base de datos ingresada.");
        Console.ReadKey();
    }
}

static void MostrarBD()//Método mostrar base de datos.
{
    Console.Clear();

    string path = Directory.GetCurrentDirectory() + @"\db\";
    DirectoryInfo di = new DirectoryInfo(path);
    DirectoryInfo[] diArr = di.GetDirectories();

    foreach (DirectoryInfo dri in diArr)
        Console.WriteLine(dri.Name);

    Console.ReadKey();
}

static void UsarBD(string[] cadena)//Método usar base de datos.
{
    Console.Clear();

    string pathdb = Directory.GetCurrentDirectory() + @"\db\" + cadena[2] + @"\";

    Console.Write("");
    string opcion2 = Console.ReadLine();
    string[] cadena2 = opcion2.Split();

    if ((cadena2[0] + " " + cadena2[1]) == "crear tabla")
    {
        crearTabla(pathdb, cadena, cadena2, filas);
    }
    if ((cadena2[0] + " " + cadena2[1]) == "mostrar tablas")
    {

    }
    if ((cadena2[0] + " " + cadena2[1]) == "mostrar campo x tabla y")
    {

    }
    if ((cadena2[0] + " " + cadena2[1]) == "eliminar tabla")
    {

    }
}

static void crearTabla(string pathdb, string[] cadena, string[] cadena2)
{
    Console.Clear();

    if (true)
    {

    }
    else
    {

        //List<Formato> filas = new List<Formato>();
        WriteT.WriteToTXT(pathdb + cadena2[2] + ".txt", filas);
    }




    Console.Write("");
    string fila = Console.ReadLine();
    string[] contenido = fila.Split();

    filas.Add(new Formato(contenido[0], contenido[1], contenido[2]));
    WriteT.WriteToTXT(pathdb + cadena2[2] + ".txt", filas);
    Console.Clear();


    Console.Write("Datos guardados con éxito.");
    Console.ReadKey();
}
class Formato
{
    public string nombreT { get; set; }
    public string tipoT { get; set; }
    public string longT { get; set; }

    public override string ToString()
    {
        return String.Format("{0}|{1}|{2}", nombreT, tipoT, longT);
    }
    public Formato(string n, string t, string l)
    {
        this.nombreT = n;
        this.tipoT = t;
        this.longT = l;
    }
}
class WriteT
{
    public static void WriteToTXT(string pathdb, List<Formato> filas)
    {
        StreamWriter txtOut = new StreamWriter(
        new FileStream(pathdb, FileMode.Append, FileAccess.Write));
        foreach (Formato p in filas)
        {
            txtOut.WriteLine("{0}|{1}|{2}", p.nombreT, p.tipoT, p.longT);
        }
        txtOut.Close();
    }
    public static List<Formato> ReadFromTXT(string pathdb)
    {
        List<Formato> filas = new List<Formato>();
        StreamReader txtIn = new StreamReader(new FileStream(pathdb, FileMode.Open, FileAccess.Read));
        while (txtIn.Peek() != -1)
        {
            string line = txtIn.ReadLine();
            string[] Columnas = line.Split('|');

            Formato p = new Formato(Columnas[0], Columnas[1], Columnas[2]);
            filas.Add(p);
        }
        return filas;
    }
}