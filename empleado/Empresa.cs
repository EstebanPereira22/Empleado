using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Para poder trabajar con la clase ArrayList debemos agregar este using
using System.Collections;

namespace Colecciones_ArrayList
{
    public class Empresa
    {

        //jugo cambiasso papi
        private List<Empleado> colEmpleados;
        private List<Cargo> colCargos;

        // Constructor
        public Empresa()
        {
            colEmpleados = new List <Empleado>();//solo va a guardar empleados o derivados de empleado, en trabajo final, terminales nacionales o inter
            colCargos = new List<Cargo>();
        }

        #region Empleado

        // Devuelve la cantidad de empleados
        public int ContarEmpleados()
        {
            return colEmpleados.Count;
        }

        // Dada una cédula, busca el Empleado
        public Empleado BuscarEmpleado(int pCi)
        {
            foreach (Empleado empleado in colEmpleados)
            {
                // Casteamos sin consultar, sólo porque estamos
                //seguros de que son empleados
                if (empleado.Cedula == pCi)
                {
                    return empleado;
                }
            }
            return null;
        }

        // Permite agregar un nuevo Empleado
        public bool Agregar(Empleado pEmp)
        {
            if (BuscarEmpleado(pEmp.Cedula) == null)
            {
                colEmpleados.Add(pEmp);
                return true;
            }
            return false;
        }

        // Permite eliminar un Empleado
        public bool Eliminar(Empleado pEmp)//se usa for en vez de for each porque pide una ubicacion puntual
        {
            for (int indice = 0; indice < colEmpleados.Count; indice++)
            {
                if (colEmpleados[indice].Cedula == pEmp.Cedula)
                {
                    colEmpleados.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        // Ordena la colección de empleados por nombre
        public List<Empleado> OrdenarPorNombre()
        {
            Empleado swap;

            for (int i = 0; i < colEmpleados.Count; i++)
            {
                for (int j = colEmpleados.Count - 1; j > i; j--)
                {
                    if (colEmpleados[j].Nombre.CompareTo
                       (colEmpleados[j - 1].Nombre) < 0)
                    {
                        swap = colEmpleados[j];
                        colEmpleados[j] = colEmpleados[j - 1];
                        colEmpleados[j - 1] = swap;
                    }
                }
            }
            return colEmpleados;
        }

        // Lista los empleados de una edad determinada
        public List<Empleado> ListarPorEdad(int pEdad)
        {
            List<Empleado> coleccion = new List<Empleado>();

            foreach (Empleado empleado in colEmpleados)
            {
                if (empleado.Edad == pEdad)
                {
                    coleccion.Add(empleado);
                }
            }
            return coleccion;
        }

        #endregion

        #region Cargo

        // Devuelve la cantidad de cargos
        public int ContarCargos()
        {
            return colCargos.Count;
        }

        // Dado un código, busca el Cargo
        public Cargo BuscarCargo(int pCod)
        {
            foreach(Cargo cargo in colCargos)
            {
                if (cargo.Codigo == pCod)
                
return cargo;
                
            }
            return null;
        }

        // Permite agregar un nuevo Cargo (sobrecarga)
        // No hacemos una búsqueda previa porque el código se genera automáticamente
        public void Agregar(Cargo pCargo)
        {
            colCargos.Add(pCargo);
        }

        // Ejemplo para comprobar si un elemento se puede eliminar o no
        //(no lo estamos usando en Program)
        private bool EstaEnUso(Cargo pCargo)
        {
            foreach (Empleado empleado in colEmpleados) 
            {
                if (empleado.CargoEmp.Codigo == pCargo.Codigo)
                    return true;
            }
            
            return false;
        }

        // Permite eliminar un Cargo (si no está en uso por algún Empleado) (sobrecarga)
        public bool Eliminar(Cargo pCargo)
        {
            if (EstaEnUso(pCargo))
                throw new Exception("El cargo está en uso. No se puede eliminar");

            for (int indice = 0; indice < colCargos.Count; indice++)
            {
                if (colCargos[indice].Codigo == pCargo.Codigo)
                {
                    colCargos.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
