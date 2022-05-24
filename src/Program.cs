string comando = "";
do
{
    Console.Clear();
    List<FormatoEst> filas = new List<FormatoEst>();
    //List<Tabla> filass = new List<Tabla>();

    Console.Write("");
    comando = Console.ReadLine();
    string[] cadena = comando.Split();
    Console.Clear();

    if ((cadena[0] + " " + cadena[1]) == "crear base")
    {
        CrearBD(cadena);
    }
    if ((cadena[0] + " " + cadena[1]) == "borrar base")
    {
        BorrarBD(cadena);
    }
    if ((cadena[0] + " " + cadena[1]) == "mostrar bases")
    {
        MostrarBD();
    }
    if ((cadena[0] + " " + cadena[1]) == "usar base")
    {
        Console.Write("Usando db: " + cadena[2]);
        Console.ReadKey();
        Console.Clear();

        string path = Directory.GetCurrentDirectory() + @"\db\" + cadena[2] + @"\";

        Console.Write("");
        string opcion2 = Console.ReadLine();
        string[] cadena2 = opcion2.Split();
        string c0,
            c1,
            c2;

        do
        {
            if ((cadena2[0] + " " + cadena2[1]) == "crear tabla")
            {
                if (File.Exists(cadena[2]))
                {
                    Console.Write("Ya existe una tabla con el nombre ingresado.");
                    Console.ReadKey();
                }
                else
                {
                    string pathest = path + cadena2[2] + ".est";
                    string pathdat = path + cadena2[2] + ".dat";
                    WriteEst.WriteToEst(pathest, filas); //Crea el archivo de estructura del contenido de la tabla
                    WriteEst.WriteToEst(pathdat, filas);

                    Console.Write(" ");
                    string comando3 = Console.ReadLine();
                    string[] cd = comando3.Split();

                    do
                    {
                        c0 = cd[0];
                        c1 = cd[1];
                        c2 = cd[2];

                        filas.Add(new FormatoEst(c0, c1, c2));

                        Console.Write(" ");
                        comando3 = Console.ReadLine();
                        cd = comando3.Split();
                    } while (comando3 != ";");
                    WriteEst.WriteToEst(pathest, filas);
                }
                Console.Clear();
                Console.Write("Tabla creada exitosamente.");
                Console.ReadKey();
            }

            if ((cadena2[0] + " " + cadena2[1]) == "mostrar tablas")
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] files = di.GetFiles("*.est");
                string str = "";
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                }
                Console.ReadKey();
            }

            if ((cadena2[0] + " " + cadena2[1]) == "eliminar tabla")
            {
                string pathe = path + cadena2[2] + ".est";
                string pathd = path + cadena2[2] + ".dat";

                File.Delete(pathe);
                File.Delete(pathd);
            }

            if ((cadena2[0] + " " + cadena2[1]) == "borrar campo" /*nombre tabla*/) { }

            if ((cadena2[0] + " " + cadena2[1]) == "agrega campo" /*nombre tabla*/)
            {
                string pathtbl = path + cadena2[2] + ".est";
                Console.Write("");
                string campo = Console.ReadLine();
                string[] cd = campo.Split();

                c0 = cd[0];
                c1 = cd[1];
                c2 = cd[2];

                filas.Add(new FormatoEst(c0, c1, c2));
                WriteEst.WriteToEst(pathtbl, filas);
            }

            if ((cadena2[0] + " " + cadena2[1]) == "inserta en" /*nombre tabla*/)
            {
                string pathdat = path + cadena2[2] + ".dat";
                string campo = "";
                do
                {
                    Console.Write("");
                    campo = Console.ReadLine();
                    string[] cd = campo.Split();
                    using (StreamWriter sw = new StreamWriter(pathdat, true))
                    {
                        if (campo != ";")
                        {
                            for (int i = 0; i < cd.Length; i++)
                            {
                                string l = cd[i];
                                sw.Write(l + "|");
                            }
                            sw.WriteLine();
                        }
                    }
                } while (campo != ";");
            }

            if ((cadena2[0] + " " + cadena2[1]) == "elimina en" /*nombre tabla donde nombre campo = dato*/) { }
            if ((cadena2[0] + " " + cadena2[1]) == "modifica en" /*(nombre tabla) (nombre campo) = dato*/) { }
            if ((cadena2[0] + " " + cadena2[1]) == "lista *" /*de nombre tabla*/)
            {
                string pathdat = path + cadena2[2] + ".dat";
                using (StreamReader sr = new StreamReader(pathdat))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        Console.WriteLine(s);
                    } while (s != null);
                    Console.ReadKey();
                }
            }

            if ((cadena2[0] + " " + cadena2[1]) == "lista campo1, campoN, de nombre tabla") { }
            if ((cadena2[0] + " " + cadena2[1])== "lista * de nombre tabla donde nombre campo = dato") { }
            if ((cadena2[0] + " " + cadena2[1]) == "lista campo1, campoN de nombre tabla") { }
            Console.Clear();
            Console.Write("");
            opcion2 = Console.ReadLine();
            cadena2 = opcion2.Split();
        } while (opcion2 != "cerrar base");
    }
} while (comando != "cerrar programa");
Console.Clear();

static void CrearBD(string[] cadena) //Método creación base de datos (carpeta).
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

static void BorrarBD(string[] cadena) //Método borrar base de datos.
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

static void MostrarBD() //Método mostrar base de datos.
{
    Console.Clear();

    string path = Directory.GetCurrentDirectory() + @"\db\";
    DirectoryInfo di = new DirectoryInfo(path);
    DirectoryInfo[] diArr = di.GetDirectories();

    foreach (DirectoryInfo dri in diArr)
        Console.WriteLine(dri.Name);

    Console.ReadKey();
}

class FormatoEst
{
    public string nombreT { get; set; }
    public string tipoT { get; set; }
    public string longT { get; set; }

    public override string ToString()
    {
        return String.Format("|{0}|{1}|{2}|", nombreT, tipoT, longT);
    }

    public FormatoEst(string n, string t, string l)
    {
        this.nombreT = n;
        this.tipoT = t;
        this.longT = l;
    }
}

class WriteEst
{
    public static void WriteToEst(string pathdb, List<FormatoEst> filas)
    {
        StreamWriter txtOut = new StreamWriter(
            new FileStream(pathdb, FileMode.Append, FileAccess.Write)
        );
        foreach (FormatoEst p in filas)
        {
            txtOut.WriteLine("|{0}|{1}|{2}|", p.nombreT, p.tipoT, p.longT);
        }
        txtOut.Close();
    }

    public static List<FormatoEst> ReadFromEst(string pathdb)
    {
        List<FormatoEst> filas = new List<FormatoEst>();
        StreamReader txtIn = new StreamReader(
            new FileStream(pathdb, FileMode.Open, FileAccess.Read)
        );
        while (txtIn.Peek() != -1)
        {
            string line = txtIn.ReadLine();
            string[] Columnas = line.Split('|');

            FormatoEst p = new FormatoEst(Columnas[0], Columnas[1], Columnas[2]);
            filas.Add(p);
        }
        return filas;
    }
}
