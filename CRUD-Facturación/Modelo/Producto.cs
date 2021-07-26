using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_Facturación.Modelo
{
    public partial class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int ExistenciaProducto { get; set; }
    }
}
