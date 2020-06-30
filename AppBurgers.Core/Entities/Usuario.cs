using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            ListaDeseo = new HashSet<ListaDeseo>();
            Rating = new HashSet<Rating>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<ListaDeseo> ListaDeseo { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
