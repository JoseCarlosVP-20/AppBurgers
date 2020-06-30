using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            ListaDeseo = new HashSet<ListaDeseo>();
            Producto = new HashSet<Producto>();
            Rating = new HashSet<Rating>();
        }

        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<ListaDeseo> ListaDeseo { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
