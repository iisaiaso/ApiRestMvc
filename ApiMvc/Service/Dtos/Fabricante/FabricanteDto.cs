using ApiMvc.Models;
using ApiMvc.Models.Cores.Model;

namespace ApiMvc.Service.Dtos.Fabricante
{
    public class FabricanteDto : CoreModel
    {
        public string Nombre { get; set; } = string.Empty;
        public List<ProductoSmallDto>?  Productos { get; set; }
    }
}
