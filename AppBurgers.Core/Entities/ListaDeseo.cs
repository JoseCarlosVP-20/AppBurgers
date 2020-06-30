using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class ListaDeseo
    {
        public int IdListaDeseo { get; set; }
        public int IdRestaurante { get; set; }
        public int IdUsuario { get; set; }

        public virtual Restaurante IdRestauranteNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
