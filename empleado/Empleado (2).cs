using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colecciones_ArrayList
{
    // Clase abstracta (no se pueden crear instancias directas de esta clase)
    public abstract class Empleado
    {
        // Atributos
        private int cedula;
        private string nombre;
        private int edad;

        // Atributo de asociación
        private Cargo cargoEmp;

        // Propiedades
        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value.ToString().Length != 8)
                    throw new Exception("La cédula debe tener 8 caracteres");

                cedula = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío");

                else if (value.Trim().Length > 50)
                    throw new Exception("El nombre no puede exceder los 50 caracteres");

                nombre = value;
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value >= 18)
                    edad = value;

                else
                    throw new Exception("Debe ingresar una edad mayor o igual a 18");
            }
        }

        public Cargo CargoEmp
        {
            get { return cargoEmp; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar el cargo del empleado");

                cargoEmp = value;
            }
        }

        // Constructor
        public Empleado(int pCedula, string pNombre, int pEdad, Cargo pCargo)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            Edad = pEdad;
            CargoEmp = pCargo;
        }

        // Operaciones       
        public override string ToString()
        {
            return ("Cédula " + Cedula + "\nNombre: " + Nombre + "\nEdad: " + Edad + "\nCargo: " + CargoEmp.Nombre);
        }
    }
}