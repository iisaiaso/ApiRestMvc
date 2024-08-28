using ApiMvc.Models.Cores.Model;
using ApiMvc.Service.Dtos.Productos;

namespace ApiMvc.Service.Dtos.Fabricantes
{
    public class FabricanteDto : CoreModel
    {
        public string Nombre { get; set; } = string.Empty;
        public List<ProductoSmallDto>?  Productos { get; set; }
    }
}
