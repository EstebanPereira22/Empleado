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
        // Atributos de asociación       
        // Ventaja: es dinámica. Desventaja: no es fuertemente tipada
        private ArrayList colEmpleados;
        private ArrayList colCargos;

        // Constructor
        public Empresa()
        {
            colEmpleados = new ArrayList();
            colCargos = new ArrayList();
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
            for (int indice = 0; indice < colEmpleados.Count; indice++)
            {
                // Casteamos sin consultar, sólo porque estamos
                //seguros de que son empleados
                if (((Empleado)colEmpleados[indice]).Cedula == pCi)
                {
                    return (Empleado)colEmpleados[indice];
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
        public bool Eliminar(Empleado pEmp)
        {
            for (int indice = 0; indice < colEmpleados.Count; indice++)
            {
                if (((Empleado)colEmpleados[indice]).Cedula == pEmp.Cedula)
                {
                    colEmpleados.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        // Ordena la colección de empleados por nombre
        public ArrayList OrdenarPorNombre()
        {
            Empleado swap;

            for (int i = 0; i < colEmpleados.Count; i++)
            {
                for (int j = colEmpleados.Count - 1; j > i; j--)
                {
                    if (((Empleado)colEmpleados[j]).Nombre.CompareTo
                       (((Empleado)colEmpleados[j - 1]).Nombre) < 0)
                    {
                        swap = (Empleado)colEmpleados[j];
                        colEmpleados[j] = colEmpleados[j - 1];
                        colEmpleados[j - 1] = swap;
                    }
                }
            }
            return colEmpleados;
        }

        // Lista los empleados de una edad determinada
        public ArrayList ListarPorEdad(int pEdad)
        {
            ArrayList coleccion = new ArrayList();

            for (int indice = 0; indice < colEmpleados.Count; indice++)
            {
                if (((Empleado)colEmpleados[indice]).Edad == pEdad)
                {
                    coleccion.Add(colEmpleados[indice]);
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
            for (int indice = 0; indice < colCargos.Count; indice++)
            {
                if (((Cargo)colCargos[indice]).Codigo == pCod)
                {
                    return (Cargo)colCargos[indice];
                }
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
            for (int indice = 0; indice < colEmpleados.Count; indice++)
            {
                if (((Empleado)colEmpleados[indice]).CargoEmp.Codigo == pCargo.Codigo)
                {
                    return true;
                }
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
                if (((Cargo)colCargos[indice]).Codigo == pCargo.Codigo)
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
