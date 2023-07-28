using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colecciones_ArrayList
{
    public class Asalariado : Empleado
    {
        // Atributos
        private double sueldo;

        // Propiedades
        public double Sueldo
        {
            get { return sueldo; }
            set
            {
                if (value >= 0)
                    sueldo = value;

                else
                    throw new Exception("El sueldo no puede ser negativo");
            }
        }

        // Constructor        
        public Asalariado(int pCedula, string pNombre, int pEdad, double pSueldo, Cargo pCargo)
            : base(pCedula, pNombre, pEdad, pCargo)
        {
            Sueldo = pSueldo;
        }

        // Operaciones        
        public override string ToString()
        {
            return base.ToString() + "\nSueldo: " + Sueldo;
        }
    }
}