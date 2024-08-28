using ApiMvc.Models.Cores.Model;
using ApiMvc.Service.Dtos.Fabricantes;

namespace ApiMvc.Service.Dtos.Productos
{
    public class ProductoDto : CoreModel
    {
        public string Nombre { get; set; } = string.Empty;
        public  double Precio { get; set; }
        public int FabricanteId { get; set; }
        public FabricanteSmallDto? Fabricante { get; set; }
    }
}
