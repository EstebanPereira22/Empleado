using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace Colecciones_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        } // Fin Main

        // Operación para pedir un double
        static double PidoNumero()
        {
            double numero;

            while (true)
            {
                try
                {
                    numero = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Número incorrecto: " + ex.Message);
                    Console.Write("Vuelva a ingresarlo: ");
                }
            }
            return numero;
        }

        // Operación para pedir un entero
        static int PidoNumero(string mensaje, int minimo, int maximo)
        {
            int numero;

            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < minimo || numero > maximo)
                    {
                        Console.WriteLine
                            ("Debe ingresar un valor entre " + minimo + " y " + maximo);
                        Console.ReadLine();
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();
                }
            }
            return numero;
        }

        // Operación para pedir un texto
        static string PidoPalabra(string mensaje)
        {
            string palabra;

            while (true)
            {
                Console.Write(mensaje);
                palabra = Console.ReadLine().Trim();

                if (palabra == "")
                {
                    Console.WriteLine("Debe ingresar una palabra");
                    Console.WriteLine();
                }
                else
                    break;
            }
            return palabra;
        }

        // Operación para dar la opción de salir del menú donde se encuentra
        static bool SalirDeLaOpcion()
        {
            Console.Write("Ingrese la letra S si desea salir de la opción en la que se encuentra: ");
            return ("S" == Console.ReadLine().Trim().ToUpper());
        }

        // Operación que despliega un Menú y procesa los pedidos
        public static void Menu()
        {
            // Creamos una Empresa
            Empresa bios = new Empresa();

            ArrayList empleados;
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("\tMenú principal");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("0 - Salir");
                    Console.WriteLine("1 - Agregar un Asalariado");
                    Console.WriteLine("2 - Agregar un Jornalero");
                    Console.WriteLine("3 - Buscar por CI");
                    Console.WriteLine("4 - Eliminar un Empleado");
                    Console.WriteLine("5 - Modificar un Asalariado");
                    Console.WriteLine("6 - Listar todos los Empleados");
                    Console.WriteLine("7 - Buscar Empleados por edad");
                    Console.WriteLine("8 - Agregar Cargo");

                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese una opción: ", 0, 8);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Chauuuuuuu");
                            Console.ReadLine();
                            break;

                        case 1:
                            if (bios.ContarCargos() > 0)
                                AgregarAsalariado(bios);

                            else
                            {
                                Console.WriteLine("No hay cargos registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 2:
                            if (bios.ContarCargos() > 0)
                                AgregarJornalero(bios);

                            else
                            {
                                Console.WriteLine("No hay cargos registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 3:
                            if (bios.ContarEmpleados() > 0)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        // Solicitamos la cédula 
                                        int cedula = PidoNumero("Ingrese la CI a buscar: ", 10000000, 99999999);

                                        Empleado empleado = bios.BuscarEmpleado(cedula);

                                        // Dependiendo de lo que retorne, tomamos una acción
                                        if (empleado == null) // Habilito alta (le paso la cédula)
                                            Console.WriteLine("No existe el empleado");

                                        else // Habilito baja o modificar (le paso la referencia)
                                            Console.WriteLine("\n" + empleado.ToString());

                                        Console.ReadLine();

                                        if (SalirDeLaOpcion())
                                            break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error inesperado" + ex.Message);
                                        Console.ReadLine();

                                        if (SalirDeLaOpcion())
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay empleados registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 4:
                            if (bios.ContarEmpleados() > 0)
                                EliminarEmpleado(bios);

                            else
                            {
                                Console.WriteLine("No hay empleados registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 5:
                            if (bios.ContarEmpleados() > 0)
                                ModificarAsalariado(bios);

                            else
                            {
                                Console.WriteLine("No hay empleados registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 6:
                            if (bios.ContarEmpleados() > 0)
                            {
                                Console.WriteLine("Listado de Empleados");
                                Console.WriteLine();

                                empleados = bios.OrdenarPorNombre();
                                Console.WriteLine();
                                // Usamos una variable implícita 
                                //(adquiere el tipo de dato en tiempo de diseño)     
                                foreach (var variable in empleados)
                                {
                                    // La ventaja de ToString es que está definida en Object
                                    // Por polimorfismo, se usa el método redefinido 
                                    //en la clase concreta
                                    Console.WriteLine(variable.ToString());
                                    Console.WriteLine();
                                }
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("No hay empleados registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 7:
                            if (bios.ContarEmpleados() > 0)
                            {
                                int edad = PidoNumero("Ingrese la edad para buscar: ", 18, int.MaxValue);

                                empleados = bios.ListarPorEdad(edad);

                                if (empleados.Count > 0)
                                {
                                    Console.WriteLine();
                                    foreach (var variable in empleados)
                                    {
                                        Console.WriteLine(variable.ToString());
                                        Console.WriteLine();
                                    }
                                }
                                else
                                    Console.WriteLine("No hay empleados con esa edad para mostrar");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("No hay empleados registrados en el sistema");
                                Console.ReadLine();
                            }
                            break;

                        case 8:
                            AgregarCargo(bios);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado: " + ex.Message);
                    Console.ReadLine();
                }
            }
        }

        // Agregar Asalariado
        public static void AgregarAsalariado(Empresa bios)
        {
            // Petición y validación de datos
            while (true)
            {
                try
                {
                    int cedula = PidoNumero("Ingrese la cédula: ", 10000000, 99999999);

                    if (bios.BuscarEmpleado(cedula) != null)
                        throw new Exception("Ya existe un Empleado con esa cédula");

                    int codigo = PidoNumero("Ingrese el código del cargo: ", 1000, int.MaxValue);

                    Cargo unCargo = bios.BuscarCargo(codigo);

                    if (unCargo == null)
                        throw new Exception("No existe un Cargo con ese código");

                    string nombre = PidoPalabra("Ingrese el nombre: ");

                    int edad = PidoNumero("Ingrese la edad: ", 18, int.MaxValue);

                    Console.Write("Ingrese el sueldo: ");
                    double sueldo = PidoNumero();

                    Asalariado asalariado = new Asalariado(cedula, nombre, edad, sueldo, unCargo);

                    // Intentamos agregarlo a la colección de la clase Empresa
                    if (bios.Agregar(asalariado))
                    {
                        Console.WriteLine("\nAlta con éxito");
                        Console.ReadLine();

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNo se realizó el alta");
                        Console.ReadLine();

                        if (SalirDeLaOpcion())
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Agregar Jornalero
        public static void AgregarJornalero(Empresa bios)
        {
            // Petición y validación de datos
            while (true)
            {
                try
                {
                    int cedula = PidoNumero("Ingrese la cédula: ", 10000000, 99999999);

                    if (bios.BuscarEmpleado(cedula) != null)
                        throw new Exception("Ya existe un Empleado con esa cédula");

                    int codigo = PidoNumero("Ingrese el código del cargo: ", 1000, int.MaxValue);

                    Cargo unCargo = bios.BuscarCargo(codigo);

                    if (unCargo == null)
                        throw new Exception("No existe un Cargo con ese código");

                    string nombre = PidoPalabra("Ingrese el nombre: ");

                    int edad = PidoNumero("Ingrese la edad: ", 18, int.MaxValue);

                    int horas = PidoNumero("Ingrese la cantidad de horas: ", 0, int.MaxValue);

                    Console.Write("Ingrese el precio por hora: ");
                    double precio = PidoNumero();

                    Jornalero jornalero = new Jornalero(cedula, nombre, edad, horas, precio, unCargo);

                    // Intentamos agregarlo a la colección de la clase Empresa
                    if (bios.Agregar(jornalero))
                    {
                        Console.WriteLine("\nAlta con éxito");
                        Console.ReadLine();

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNo se realizó el alta");
                        Console.ReadLine();

                        if (SalirDeLaOpcion())
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Eliminar Empleado
        public static void EliminarEmpleado(Empresa bios)
        {
            while (true)
            {
                try
                {
                    int cedula = PidoNumero("Ingrese la cédula: ", 10000000, 99999999);

                    Empleado empleado = bios.BuscarEmpleado(cedula);

                    if (empleado == null)
                        throw new Exception("No existe un empleado con esa cédula");

                    if (bios.Eliminar(empleado))
                        Console.WriteLine("Eliminación con éxito");

                    else
                        Console.WriteLine("No se pudo realizar la eliminación");

                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Modificar Asalariado
        public static void ModificarAsalariado(Empresa bios)
        {
            bool modificar;

            while (true)
            {
                try
                {
                    // Primero, solicitamos la cédula (no se modifica)               
                    int cedula = PidoNumero("Ingrese la cédula: ", 10000000, 99999999);

                    // Segundo, verificamos si existe
                    Empleado empleado = bios.BuscarEmpleado(cedula);

                    if (empleado == null)
                        throw new Exception("No hay empleado registrado con esa cédula");

                    else if (empleado is Jornalero)
                        throw new Exception("La cédula pertenece a un jornalero");

                    // Si llegamos hasta acá es porque tenemos una asalariado

                    // Nombre
                    Console.Write("Ingrese la letra S si quiere modificar el nombre: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        empleado.Nombre = PidoPalabra("Ingrese el nuevo nombre: ");
                        Console.WriteLine("El nombre se modificó con éxito");
                    }
                    // Edad
                    Console.Write("Ingrese la letra S si quiere modificar la edad: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        empleado.Edad = PidoNumero("Ingrese la nueva edad: ", 18, int.MaxValue);
                        Console.WriteLine("La edad se modificó con éxito");
                    }
                    // Sueldo
                    Console.Write("Ingrese la letra S si quiere modificar el sueldo: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        // Debemos castear porque es una propiedad de Asalariado
                        Console.Write("Ingrese el nuevo sueldo: ");
                        ((Asalariado)empleado).Sueldo = PidoNumero();
                        Console.WriteLine("El sueldo se modificó con éxito");
                    }
                    Console.WriteLine("\nDatos actuales del empleado:");
                    Console.WriteLine("\n" + empleado.ToString());
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Agregar Cargo
        public static void AgregarCargo(Empresa bios)
        {
            while (true)
            {
                try
                {
                    string nombre = PidoPalabra("Ingrese el nombre (5 letras): ");
                    Cargo cargo = new Cargo(nombre);

                    // Intentamos agregarlo a la colección de la clase Empresa (no debería dar error)
                    bios.Agregar(cargo);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }
    }
}