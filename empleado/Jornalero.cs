using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colecciones_ArrayList
{
    public class Jornalero : Empleado
    {
        // Atributos
        private int cantHoras;
        private double precioHora;

        // Propiedades
        public int CantHoras
        {
            get { return CantHoras; }
            set
            {
                if (value >= 0)
                    cantHoras = value;

                else
                    throw new Exception("La cantidad de horas no puede ser negativa");
            }
        }

        public double PrecioHora
        {
            get { return precioHora; }
            set
            {
                if (value > 0)
                    precioHora = value;

                else
                    throw new Exception("El precio de la hora debe ser mayor que cero");
            }
        }

        // Constructor              
        public Jornalero(int pCedula, string pNombre, int pEdad, int pCantHoras, double pPrecioHora, Cargo pCargo)
            : base(pCedula, pNombre, pEdad, pCargo)
        {
            CantHoras = pCantHoras;
            PrecioHora = pPrecioHora;
        }

        // Operaciones        
        public override string ToString()
        {
            return base.ToString() + "\nHoras: " + CantHoras + "\nPrecio: " + PrecioHora;
        }
    }
}