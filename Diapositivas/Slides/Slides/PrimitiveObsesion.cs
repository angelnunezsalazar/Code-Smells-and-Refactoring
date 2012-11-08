using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slides
{
    public class PrimitiveObsesion
    {

        public void Main()
        {
            string direccion = "Calle: Las Flores - Ciudad: Lima - Pais: Perú";

            string calle = direccion.Substring(7, 10);
            string ciudad = direccion.Substring(28, 4);
            string pais = direccion.Substring(41, 4);
        }
    }
}
