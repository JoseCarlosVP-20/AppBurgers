using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
