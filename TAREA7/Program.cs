using System;
using System.Collections.Generic;
using System.IO;

class CuentaBancaria
{
    private string titular;
    private int saldo;

    public CuentaBancaria(string titular, int saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public string Titular
    {
        get { return titular; }
    }

    public int Saldo
    {
        get { return saldo; }
    }

    public void Depositar(int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El deposito debe ser mayor a 0");
            return;
        }
        saldo += monto;
        Console.WriteLine("Deposito de " + monto + " Bs. Saldo: " + saldo + " Bs");
    }

    public void Retirar(int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El retiro debe ser mayor a 0");
            return;
        }
        if (monto > saldo)
        {
            Console.WriteLine("Saldo insuficiente. Saldo: " + saldo + " Bs");
            return;
        }
        saldo -= monto;
        Console.WriteLine("Retiro de " + monto + " Bs. Saldo: " + saldo + " Bs");
    }

    public void MostrarResumen()
    {
        Console.WriteLine("Cuenta de " + titular + " | Saldo final: " + saldo + " Bs");
    }
}

class Libro
{
    private string titulo;
    private bool disponible;

    public Libro(string titulo)
    {
        this.titulo = titulo;
        this.disponible = true;
    }

    public string Titulo
    {
        get { return titulo; }
    }

    public bool Disponible
    {
        get { return disponible; }
    }

    public bool Prestar()
    {
        if (!disponible)
        {
            return false;
        }
        disponible = false;
        return true;
    }
}

class Contacto
{
    private string nombre;
    private string telefono;

    public Contacto(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public string Nombre
    {
        get { return nombre; }
    }

    public string Telefono
    {
        get { return telefono; }
    }

    public string ALinea()
    {
        return nombre + ";" + telefono;
    }
}

// Clase propia para el Ejercicio 4: Cancion
class Cancion
{
    private string titulo;
    private string artista;
    private int duracionSegundos;

    public Cancion(string titulo, string artista, int duracionSegundos)
    {
        this.titulo = titulo;
        this.artista = artista;
        DuracionSegundos = duracionSegundos;
    }

    public string Titulo
    {
        get { return titulo; }
    }

    public string Artista
    {
        get { return artista; }
    }

    public int DuracionSegundos
    {
        get { return duracionSegundos; }
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("duracionSegundos");
            duracionSegundos = value;
        }
    }

    public void Reproducir()
    {
        Console.WriteLine("Reproduciendo: " + titulo + " de " + artista);
    }

    public string ALinea()
    {
        return titulo + ";" + artista + ";" + duracionSegundos;
    }
}

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine("===== TAREA 7: CLASES Y ARCHIVOS =====");
            Console.WriteLine("Estudiante: Alejandra Knaudt");
            Console.WriteLine("1. Cuenta bancaria");
            Console.WriteLine("2. Prestamo de libros");
            Console.WriteLine("3. Agenda de contactos con archivo");
            Console.WriteLine("4. Mi propia clase");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opcion: ");
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1: Ejercicio1(); break;
                case 2: Ejercicio2(); break;
                case 3: Ejercicio3(); break;
                case 4: Ejercicio4(); break;
                case 0: Console.WriteLine("Hasta luego"); break;
                default: Console.WriteLine("Opcion no valida"); break;
            }
        } while (opcion != 0);
    }

    // Ejercicio 1: Cuenta bancaria
    static void Ejercicio1()
    {
        Console.Write("Titular: ");
        string titular = Console.ReadLine();
        Console.Write("Saldo inicial: ");
        int saldoInicial = int.Parse(Console.ReadLine());

        CuentaBancaria cuenta = new CuentaBancaria(titular, saldoInicial);

        Console.Write("Monto a depositar: ");
        int deposito = int.Parse(Console.ReadLine());
        cuenta.Depositar(deposito);

        Console.Write("Monto a retirar: ");
        int retiro = int.Parse(Console.ReadLine());
        cuenta.Retirar(retiro);

        cuenta.MostrarResumen();
    }

    // Ejercicio 2: Préstamo de libros
    static void Ejercicio2()
    {
        List<Libro> libros = new List<Libro>();
        libros.Add(new Libro("El Principito"));
        libros.Add(new Libro("Don Quijote"));
        libros.Add(new Libro("Rayuela"));

        for (int i = 0; i < 2; i++)
        {
            Console.Write("Titulo del libro a pedir: ");
            string buscado = Console.ReadLine();

            Libro encontrado = null;
            foreach (Libro l in libros)
            {
                if (l.Titulo.ToLower() == buscado.ToLower())
                {
                    encontrado = l;
                    break;
                }
            }

            if (encontrado == null)
            {
                Console.WriteLine("No existe el libro " + buscado);
            }
            else
            {
                bool exito = encontrado.Prestar();
                if (exito)
                {
                    Console.WriteLine("Prestado: " + encontrado.Titulo);
                }
                else
                {
                    Console.WriteLine(encontrado.Titulo + " ya esta prestado");
                }
            }
        }

        Console.WriteLine("Estado de la biblioteca:");
        foreach (Libro l in libros)
        {
            string estado = l.Disponible ? "Disponible" : "Prestado";
            Console.WriteLine(l.Titulo + " - " + estado);
        }
    }

    // Ejercicio 3: Agenda de contactos con archivo
    static void Ejercicio3()
    {
        Console.Write("Cantidad de contactos: ");
        int n = int.Parse(Console.ReadLine());
        List<Contacto> contactos = new List<Contacto>();

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Nombre del contacto " + i + ": ");
            string nombre = Console.ReadLine();
            Console.Write("Telefono del contacto " + i + ": ");
            string telefono = Console.ReadLine();
            contactos.Add(new Contacto(nombre, telefono));
        }

        List<string> lineas = new List<string>();
        foreach (Contacto c in contactos)
        {
            lineas.Add(c.ALinea());
        }

        File.WriteAllLines("contactos.txt", lineas);
        Console.WriteLine("Contactos guardados: " + n);
        Console.WriteLine("Leyendo contactos.txt:");

        string[] lineasLeidas = File.ReadAllLines("contactos.txt");
        foreach (string linea in lineasLeidas)
        {
            string[] partes = linea.Split(';');
            Console.WriteLine(partes[0] + " - Tel: " + partes[1]);
        }
    }

    // Ejercicio 4: Mi propia clase (Cancion)
    static void Ejercicio4()
    {
        List<Cancion> canciones = new List<Cancion>();
        canciones.Add(new Cancion("Bohemian Rhapsody", "Queen", 354));
        canciones.Add(new Cancion("Despacito", "Luis Fonsi", 228));
        canciones.Add(new Cancion("Hotel California", "Eagles", 391));

        List<string> lineas = new List<string>();
        foreach (Cancion c in canciones)
        {
            lineas.Add(c.ALinea());
        }

        File.WriteAllLines("canciones.txt", lineas);
        Console.WriteLine("Canciones guardadas: " + canciones.Count);
        Console.WriteLine("Leyendo canciones.txt:");

        string[] lineasLeidas = File.ReadAllLines("canciones.txt");
        foreach (string linea in lineasLeidas)
        {
            string[] partes = linea.Split(';');
            Console.WriteLine("Cancion: " + partes[0] + " | Artista: " + partes[1] + " | Duracion: " + partes[2] + "s");
        }
    }
}
 