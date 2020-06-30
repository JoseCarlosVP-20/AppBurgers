using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class Rating
    {
        public int IdRating { get; set; }
        public int IdRestaurante { get; set; }
        public int IdEstrella { get; set; }
        public int IdUsuario { get; set; }
        public decimal? Calificacion { get; set; }

        public virtual Estrella IdEstrellaNavigation { get; set; }
        public virtual Restaurante IdRestauranteNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
