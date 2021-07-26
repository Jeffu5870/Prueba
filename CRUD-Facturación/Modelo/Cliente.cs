using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_Facturación.Modelo
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public long Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
