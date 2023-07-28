using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Para poder usar expresiones regulares debemos agregar este using
using System.Text.RegularExpressions;

namespace Colecciones_ArrayList
{
    public class Cargo
    {
        // Atributo de clase (un único valor compartido por todas los objetos que se creen de esta clase, que puede ir cambiando)
        private static long numeracion = 1000;

        // Atributos de instancia (para cada objeto creado se le va a asignar un valor)
        private long codigo;
        private string nombre;

        // Propiedades
        public long Codigo
        {
            get { return codigo; }
        }

        // Suponemos que el nombre debe tener 5 letras         
        public string Nombre
        {
            get { return nombre; }
            set
            {
                // Expresión regular que controla que el texto sea de exactamente 5 letras (mayúsculas o minúsculas)
                if (!Regex.IsMatch(value, "^[a-zA-Z]{5}$")) // Alt+94 ^
                    throw new Exception("El nombre debe estar compuesto por cinco letras");

                nombre = value;
            }
        }

        // Cada vez que se crea un objeto aumentamos la numeración con el atributo de clase
        // No se recibe el código por parámero porque su valor se genera de forma automática (constructor común)
        public Cargo(string pNombre)
        {
            codigo = numeracion;
            numeracion++;
            Nombre = pNombre;
        }
    }
}
