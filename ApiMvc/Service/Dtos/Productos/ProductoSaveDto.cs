namespace ApiMvc.Service.Dtos.Productos
{
    public class ProductoSaveDto

    {
        public string Nombre { get; set; } = default!;
        public double Precio { get; set; } 
        public int FabricanteId { get; set; }
    }
}
