using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_Facturación.Modelo
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
