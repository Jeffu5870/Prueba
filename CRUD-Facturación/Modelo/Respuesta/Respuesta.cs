using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Facturación.Modelo.Respuesta
{
    public class Respuesta
    {
        public int Verdadero { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }


        public Respuesta()
        {
            this.Verdadero = 0;
        }
    }
}
