string comando = "";
do
{
    Console.Clear();
    List<FormatoEst> filas = new List<FormatoEst>();

    Console.Write("");
    comando = Console.ReadLine();
    string[] cadena = comando.Split();
    Console.Clear();

    //1.- Crea nombre base;         1pt
    if ((cadena[0] + " " + cadena[1]) == "crear base")
    {
        CrearBD(cadena);
    }
    
    //2.- Borra base nombre base;   1pt
    if ((cadena[0] + " " + cadena[1]) == "borrar base")
    {
        BorrarBD(cadena);
    }
    
    //3.- Muestra bases;            1pt
    if ((cadena[0] + " " + cadena[1]) == "mostrar bases")
    {
        MostrarBD();
    }
    
    //4.- Usa base nombre base;     1pt
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
            //5.- Crear tabla nombre tabla; 3pts
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

            //6.- Muestra tablas;           1pt
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

            //7.- Borra tabla nombre tabla; 1pt
            if ((cadena2[0] + " " + cadena2[1]) == "eliminar tabla")
            {
                string pathe = path + cadena2[2] + ".est";
                string pathd = path + cadena2[2] + ".dat";

                File.Delete(pathe);
                File.Delete(pathd);
            }

            //8.- Borra (campo) (nombre tabla, nombre campo    2pts
            if ((cadena2[0] + " " + cadena2[1]) == "borrar campo" /*nombre tabla*/)
            {
                /* string pathdat = path + cadena2[2] + ".dat";
                string pathtemp = path + cadena2[2] + "temp.dat";
                StreamReader lectura;
                StreamWriter escribir;
                string cd,
                    campo;
                bool encontrado;
                encontrado = false;
                int saltos = 0;
                //int cp = 0;
                string pathest = path + cadena2[3] + ".est";//Contar las filas
                using (StreamReader sr = new StreamReader(pathest))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        if (s == "|")
                        {
                            saltos++;
                        }
                    } while (s != null);
                }

                string[] campos = new string[saltos];
                char[] separador = {'|'};
                try 
                {
                    lectura = File.OpenText(pathdat);
                    escribir = File.CreateText(pathtemp);
                    campo = cadena2[6];
                    cd = lectura.ReadLine();
                    while (cadena != null)
                    {
                        campos=cd.Split(separador);
                        if (campos[0].Trim().Equals(campo))
                        {
                            encontrado=true;
                        }
                        else
                        {
                            escribir.WriteLine(cd);
                        }
                        cd = lectura.ReadLine();
                    }
                    if (encontrado==false)
                    {
                        Console.WriteLine("Campo no encontrado.");
                        Console.ReadKey();
                    }
                    lectura.Close();
                    escribir.Close();
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("!Error¡" + fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("!Error¡" + e.Message);
                }
                Console.ReadKey(true); */
            }

            //9.- Agrega campo nombre tabla;    2pts
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

            //10.- Inserta en nombre tabla; 2pts
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
                                sw.Write(l + " ");
                            }
                            sw.Write("|");
                            sw.WriteLine();
                        }
                    }
                } while (campo != ";");
            }

            //11.- Elimina en (nombre tabla) donde (nombre campo) = (dato);   2pts
            if ((cadena2[0] + cadena2[1]) == "elimina en" /*nombre tabla donde nombre campo = dato*/) 
            { 
                /* string pathdat = path + cadena2[2] + ".dat";
                string pathtemp = path + cadena2[2] + "temp.dat";
                StreamReader lectura;
                StreamWriter escribir;
                string cd,
                    campo;
                bool encontrado;
                encontrado = false;
                int saltos = 0;
                //int cp = 0;
                string pathest = path + cadena2[3] + ".est";//Contar las filas
                using (StreamReader sr = new StreamReader(pathest))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        if (s == "|")
                        {
                            saltos++;
                        }
                    } while (s != null);
                }

                string[] campos = new string[saltos];
                char[] separador = {'|'};
                try 
                {
                    lectura = File.OpenText(pathdat);
                    escribir = File.CreateText(pathtemp);
                    campo = cadena2[6];
                    cd = lectura.ReadLine();
                    while (cadena != null)
                    {
                        campos=cd.Split(separador);
                        if (campos[0].Trim().Equals(campo))
                        {
                            encontrado=true;
                        }
                        else
                        {
                            escribir.WriteLine(cd);
                        }
                        cd = lectura.ReadLine();
                    }
                    if (encontrado==false)
                    {
                        Console.WriteLine("Campo no encontrado.");
                        Console.ReadKey();
                    }
                    lectura.Close();
                    escribir.Close();
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("!Error¡" + fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("!Error¡" + e.Message);
                }
                Console.ReadKey(true); */
            }

            //12.- Modifica en nombre tabla 2pts
            if ((cadena2[0] + " " + cadena2[1]) == "modifica en" /*(nombre tabla) (nombre campo) = dato*/) 
            { 

            }

            //13.- Lista * de nombre tabla; 1pt
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

            //14.- Lista (campo1), (campoN) de (nombre tabla)   1pt
            if ((cadena2[0]) == "lista")
            {
                /* string pathdat = path + cadena2[3] + ".dat";
                int saltos = 0, cp = 0;
                string pathest = path + cadena2[3] + ".est";//Contar las filas
                using (StreamReader sr = new StreamReader(pathest))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        if (s == "|")
                        {
                            saltos++;
                        }
                        if (s != cadena[1])
                        {
                            cp++;
                        }
                    } while (s != null);
                }
                using (StreamReader sr = new StreamReader(pathdat))
                {
                    string s;
                    int x;
                    do
                    {
                        s = sr.ReadLine();
                        string[] cd = s.Split();
                        
                    } while (s != null);
                    Console.ReadKey();
                } */
            }
            
            //15.- Lista * de nombre tabla donde nombre campo = dato;   2pts
            if ((cadena2[0] + " " + cadena2[1]) == "lista * de nombre tabla donde nombre campo = dato") 
            { 
               /*  string pathdat = path + cadena2[3] + ".dat";
                StreamReader lectura;
                string cd,
                    campo;
                bool encontrado;
                encontrado = false;
                int saltos = 0;
                int cp = 0;
                string pathest = path + cadena2[3] + ".est";//Contar las filas
                using (StreamReader sr = new StreamReader(pathest))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        if (s == "|")
                        {
                            saltos++;
                        }
                        if (s != cadena[1])
                        {
                            cp++;
                        }
                    } while (s != null);
                }

                string[] campos = new string[saltos];
                char[] separador = {' '};
                try 
                {
                    lectura = File.OpenText(pathdat);
                    campo = cadena2[cp];
                    cd = lectura.ReadLine();
                    while (cadena != null && encontrado == false)
                    {
                        campos=cd.Split(separador);
                        if (campos[0].Trim().Equals(campo))
                        {
                            Console.WriteLine(campos[0].Trim());
                            encontrado=true;
                        }
                        else
                        {
                            cd = lectura.ReadLine();
                        }
                    }
                    if (encontrado==false)
                    {
                        Console.WriteLine("Campo no encontrado.");
                        Console.ReadKey();
                    }
                    lectura.Close();
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("!Error¡" + fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("!Error¡" + e.Message);
                }
                Console.ReadKey(true); */
            }
            
            //16.- Lista (campo1), (campoN) de nombre tabla donde nombre campo = dato; 2pts
            if ((cadena2[0] + " " + cadena2[1]) == "Lista campo1,campo2,…, campoN de nombre tabla donde nombre campo = dato") 
            { 
               /*  string pathdat = path + cadena2[3] + ".dat";
                StreamReader lectura;
                string cd,
                    campo;
                bool encontrado;
                encontrado = false;
                int saltos = 0;
                int cp = 0;
                string pathest = path + cadena2[3] + ".est";//Contar las filas
                using (StreamReader sr = new StreamReader(pathest))
                {
                    string s;
                    do
                    {
                        s = sr.ReadLine();
                        if (s == "|")
                        {
                            saltos++;
                        }
                        if (s != cadena[1])
                        {
                            cp++;
                        }
                    } while (s != null);
                }

                string[] campos = new string[saltos];
                char[] separador = {' '};
                try 
                {
                    lectura = File.OpenText(pathdat);
                    campo = cadena2[cp];
                    cd = lectura.ReadLine();
                    while (cadena != null && encontrado == false)
                    {
                        campos=cd.Split(separador);
                        if (campos[0].Trim().Equals(campo))
                        {
                            Console.WriteLine(campos[0].Trim());
                            encontrado=true;
                        }
                        else
                        {
                            cd = lectura.ReadLine();
                        }
                    }
                    if (encontrado==false)
                    {
                        Console.WriteLine("Campo no encontrado.");
                        Console.ReadKey();
                    }
                    lectura.Close();
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine("!Error¡" + fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("!Error¡" + e.Message);
                }
                Console.ReadKey(true); */
            }
            
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
        return String.Format("{0} {1} {2}|", nombreT, tipoT, longT);
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
            txtOut.WriteLine("{0} {1} {2}|", p.nombreT, p.tipoT, p.longT);
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
            string[] Columnas = line.Split(' ');

            FormatoEst p = new FormatoEst(Columnas[0], Columnas[1], Columnas[2]);
            filas.Add(p);
        }
        return filas;
    }
}
