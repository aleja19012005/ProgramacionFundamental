using System;
using System.Collections.Generic;

// Ejercicio 1: Clases para Peaje de vehículos
class Vehiculo
{
    protected string placa;

    public Vehiculo(string placa)
    {
        this.placa = placa;
    }

    public string Placa
    {
        get { return placa; }
    }

    public virtual string Tipo()
    {
        return "Vehiculo";
    }

    public virtual int CalcularPeaje()
    {
        return 10;
    }

    public void Mostrar()
    {
        Console.WriteLine(Tipo() + " " + placa + ": " + CalcularPeaje() + " Bs");
    }
}

class Auto : Vehiculo
{
    public Auto(string placa) : base(placa) { }

    public override string Tipo()
    {
        return "Auto";
    }
}

class Moto : Vehiculo
{
    public Moto(string placa) : base(placa) { }

    public override string Tipo()
    {
        return "Moto";
    }

    public override int CalcularPeaje()
    {
        return 5;
    }
}

class Camion : Vehiculo
{
    private int ejes;

    public Camion(string placa, int ejes) : base(placa)
    {
        this.ejes = ejes;
    }

    public override string Tipo()
    {
        return "Camion";
    }

    public override int CalcularPeaje()
    {
        return 10 + (8 * ejes);
    }
}

// Ejercicio 2: Clases para Cuenta de ahorro y corriente
class Cuenta
{
    protected string titular;
    protected int saldo;

    public Cuenta(string titular, int saldo)
    {
        this.titular = titular;
        this.saldo = saldo;
    }

    public string Titular
    {
        get { return titular; }
    }

    public int Saldo
    {
        get { return saldo; }
    }

    public virtual bool Retirar(int monto)
    {
        if (monto <= saldo)
        {
            saldo -= monto;
            return true;
        }
        return false;
    }

    public void IntentarRetiro(int monto)
    {
        bool exito = Retirar(monto);
        string estado = exito ? "aprobado" : "rechazado";
        Console.WriteLine(titular + ": retiro de " + monto + " Bs " + estado + ". Saldo: " + saldo + " Bs");
    }
}

class CuentaCorriente : Cuenta
{
    private int limiteSobregiro = 500;

    public CuentaCorriente(string titular, int saldo) : base(titular, saldo) { }

    public override bool Retirar(int monto)
    {
        if (saldo - monto >= -limiteSobregiro)
        {
            saldo -= monto;
            return true;
        }
        return false;
    }
}

// Ejercicio 3: Jerarquía propia (Empleados de un restaurante: Cocinero y Mesero)
class EmpleadoRestaurante
{
    protected string nombre;
    protected int sueldoBase;

    public EmpleadoRestaurante(string nombre, int sueldoBase)
    {
        this.nombre = nombre;
        this.sueldoBase = sueldoBase;
    }

    public virtual int CalcularPagoTotal()
    {
        return sueldoBase;
    }

    public virtual void MostrarDetalle()
    {
        Console.WriteLine("Empleado " + nombre + " | Pago total: " + CalcularPagoTotal() + " Bs");
    }
}

class Cocinero : EmpleadoRestaurante
{
    private int horasExtra;

    public Cocinero(string nombre, int sueldoBase, int horasExtra) : base(nombre, sueldoBase)
    {
        this.horasExtra = horasExtra;
    }

    public override int CalcularPagoTotal()
    {
        return sueldoBase + (horasExtra * 40);
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine("Cocinero " + nombre + " | Pago total (con " + horasExtra + "h extra): " + CalcularPagoTotal() + " Bs");
    }
}

class Mesero : EmpleadoRestaurante
{
    private int propinas;

    public Mesero(string nombre, int sueldoBase, int propinas) : base(nombre, sueldoBase)
    {
        this.propinas = propinas;
    }

    public override int CalcularPagoTotal()
    {
        return sueldoBase + propinas;
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine("Mesero " + nombre + " | Pago total (incluyendo propinas): " + CalcularPagoTotal() + " Bs");
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
            Console.WriteLine("===== TAREA 8: HERENCIA Y POLIMORFISMO =====");
            Console.WriteLine("Estudiante: Alejandra Knaudt");
            Console.WriteLine("1. Peaje de vehiculos");
            Console.WriteLine("2. Cuenta de ahorro y corriente");
            Console.WriteLine("3. Mi propia jerarquia");
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
                case 0: Console.WriteLine("Hasta luego"); break;
                default: Console.WriteLine("Opcion no valida"); break;
            }
        } while (opcion != 0);
    }

    // Ejercicio 1: Peaje de vehículos
    static void Ejercicio1()
    {
        Console.Write("Cantidad de vehiculos: ");
        int n = int.Parse(Console.ReadLine());
        List<Vehiculo> vehiculos = new List<Vehiculo>();

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Tipo (1 Auto, 2 Moto, 3 Camion): ");
            int tipo = int.Parse(Console.ReadLine());
            Console.Write("Placa: ");
            string placa = Console.ReadLine();

            if (tipo == 1)
            {
                vehiculos.Add(new Auto(placa));
            }
            else if (tipo == 2)
            {
                vehiculos.Add(new Moto(placa));
            }
            else if (tipo == 3)
            {
                Console.Write("Cantidad de ejes: ");
                int ejes = int.Parse(Console.ReadLine());
                vehiculos.Add(new Camion(placa, ejes));
            }
        }

        int totalRecaudado = 0;
        foreach (Vehiculo v in vehiculos)
        {
            v.Mostrar();
            totalRecaudado += v.CalcularPeaje();
        }
        Console.WriteLine("Total recaudado: " + totalRecaudado + " Bs");
    }

    // Ejercicio 2: Cuenta de ahorro y cuenta corriente
    static void Ejercicio2()
    {
        Console.Write("Saldo inicial para ambas cuentas: ");
        int saldoInicial = int.Parse(Console.ReadLine());
        Console.Write("Monto a retirar: ");
        int montoRetiro = int.Parse(Console.ReadLine());

        Cuenta ahorro = new Cuenta("Ahorro", saldoInicial);
        Cuenta corriente = new CuentaCorriente("Corriente", saldoInicial);

        ahorro.IntentarRetiro(montoRetiro);
        corriente.IntentarRetiro(montoRetiro);
    }

    // Ejercicio 3: Mi propia jerarquía (Empleados de restaurante)
    static void Ejercicio3()
    {
        List<EmpleadoRestaurante> empleados = new List<EmpleadoRestaurante>();
        empleados.Add(new Cocinero("Carlos", 2500, 10));
        empleados.Add(new Mesero("Sofia", 1800, 350));
        empleados.Add(new EmpleadoRestaurante("Roberto", 2000));

        foreach (EmpleadoRestaurante e in empleados)
        {
            e.MostrarDetalle();
        }
    }
}
