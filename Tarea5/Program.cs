using System;
using System.Collections.Generic;

// Clase Validador para entradas seguras
static class Validador
{
    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            int numero;
            if (int.TryParse(texto, out numero) && numero >= min && numero <= max)
            {
                return numero;
            }
            Console.WriteLine("Dato invalido. Escribe un numero entre " + min + " y " + max);
        }
    }

    public static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }
            Console.WriteLine("El texto no puede estar vacio");
        }
    }

    public static bool LeerSiNo(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                string respuesta = texto.Trim().ToLower();
                if (respuesta == "s")
                {
                    return true;
                }
                if (respuesta == "n")
                {
                    return false;
                }
            }
            Console.WriteLine("Responde solo s o n");
        }
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
            Console.WriteLine("===== TAREA 5: VALIDACION =====");
            Console.WriteLine("Estudiante: Alejandra Knaudt");
            Console.WriteLine("1. Registro de notas validado");
            Console.WriteLine("2. Carrito de compras");
            Console.WriteLine("3. Calculadora con historial");
            Console.WriteLine("4. Fila de la cafeteria");
            Console.WriteLine("0. Salir");
            opcion = Validador.LeerEntero("Elige una opcion: ", 0, 4);

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

    // Ejercicio 1: Registro de notas validado
    static void Ejercicio1()
    {
        int n = Validador.LeerEntero("Cantidad de estudiantes (1 a 10): ", 1, 10);
        int suma = 0;
        int aprobados = 0;
        int mayor = -1;

        for (int i = 1; i <= n; i++)
        {
            int nota = Validador.LeerEntero("Nota del estudiante " + i + " (0 a 100): ", 0, 100);
            suma += nota;

            if (nota >= 51)
            {
                aprobados++;
            }

            if (i == 1 || nota > mayor)
            {
                mayor = nota;
            }
        }

        Console.WriteLine("Suma de notas: " + suma);
        Console.WriteLine("Aprobados: " + aprobados + " de " + n);
        Console.WriteLine("Nota mas alta: " + mayor);
    }

    // Ejercicio 2: Carrito de compras
    static void Ejercicio2()
    {
        int total = 0;
        int productos = 0;
        bool otro;

        do
        {
            string nombre = Validador.LeerTexto("Nombre del producto: ");
            int precio = Validador.LeerEntero("Precio (1 a 1000 Bs): ", 1, 1000);
            int cantidad = Validador.LeerEntero("Cantidad (1 a 50): ", 1, 50);

            int subtotal = cantidad * precio;
            total += subtotal;
            productos++;

            Console.WriteLine(nombre + ": " + cantidad + " x " + precio + " = " + subtotal + " Bs");

            otro = Validador.LeerSiNo("Agregar otro producto? (s/n): ");
        } while (otro);

        Console.WriteLine("Productos distintos: " + productos);
        Console.WriteLine("Total a pagar: " + total + " Bs");
    }

    // Ejercicio 3: Calculadora con historial (pila)
    static void Ejercicio3()
    {
        Stack<int> resultados = new Stack<int>();
        int opcionSub;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Sumar  2. Ver ultimo resultado  3. Borrar ultimo  4. Salir");
            opcionSub = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            switch (opcionSub)
            {
                case 1:
                    int a = Validador.LeerEntero("Ingresa el primer numero (-1000 a 1000): ", -1000, 1000);
                    int b = Validador.LeerEntero("Ingresa el segundo numero (-1000 a 1000): ", -1000, 1000);
                    int r = a + b;
                    Console.WriteLine(a + " + " + b + " = " + r);
                    resultados.Push(r);
                    break;

                case 2:
                    if (resultados.Count > 0)
                    {
                        Console.WriteLine("Ultimo resultado: " + resultados.Peek());
                    }
                    else
                    {
                        Console.WriteLine("No hay resultados");
                    }
                    break;

                case 3:
                    if (resultados.Count > 0)
                    {
                        int borrado = resultados.Pop();
                        Console.WriteLine("Se borro: " + borrado);
                    }
                    else
                    {
                        Console.WriteLine("No hay resultados para borrar");
                    }
                    break;

                case 4:
                    Console.WriteLine("Resultados guardados: " + resultados.Count);
                    break;
            }
        } while (opcionSub != 4);
    }

    // Ejercicio 4: Fila de la cafetería (cola)
    static void Ejercicio4()
    {
        Queue<string> fila = new Queue<string>();
        int fichasEntregadas = 0;
        int atendidosHoy = 0;
        int opcionSub;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Sacar ficha  2. Atender  3. Ver fila  4. Salir");
            opcionSub = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            switch (opcionSub)
            {
                case 1:
                    string nombre = Validador.LeerTexto("Nombre de la persona: ");
                    fichasEntregadas++;
                    fila.Enqueue(nombre);
                    Console.WriteLine("Ficha " + fichasEntregadas + " para " + nombre);
                    break;

                case 2:
                    if (fila.Count > 0)
                    {
                        string atendido = fila.Dequeue();
                        Console.WriteLine("Atendiendo a " + atendido);
                        atendidosHoy++;
                    }
                    else
                    {
                        Console.WriteLine("No hay nadie en la fila");
                    }
                    break;

                case 3:
                    Console.WriteLine("Personas en la fila: " + fila.Count);
                    break;

                case 4:
                    Console.WriteLine("Atendidos hoy: " + atendidosHoy);
                    break;
            }
        } while (opcionSub != 4);
    }
}