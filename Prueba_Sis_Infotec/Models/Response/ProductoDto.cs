namespace Prueba_Sis_Infotec.Models.Response
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int CateogoriaId { get; set; }
    }
}
