using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class Producto
    {
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int IdRestaurante { get; set; }
        public int IdCategoria { get; set; }

        public virtual Restaurante IdCategoria1 { get; set; }
        public virtual CategoriaProducto IdCategoriaNavigation { get; set; }
    }
}
