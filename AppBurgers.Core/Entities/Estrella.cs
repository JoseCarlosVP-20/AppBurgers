using System;
using System.Collections.Generic;

namespace AppBurgers.Core.Entities
{
    public partial class Estrella
    {
        public Estrella()
        {
            Rating = new HashSet<Rating>();
        }

        public int IdEstrella { get; set; }
        public int? Numeración { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }
    }
}
