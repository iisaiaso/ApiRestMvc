namespace ApiMvc.Service.Dtos.Producto
{
    public class ProductoSaveDto

    {
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; }
        public int FabricanteId { get; set; }
    }
}
