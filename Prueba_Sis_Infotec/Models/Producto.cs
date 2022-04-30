using System;
using System.Collections.Generic;

namespace Prueba_Sis_Infotec.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int CateogoriaId { get; set; }

        public virtual Categoria Cateogoria { get; set; } = null!;
    }
}
