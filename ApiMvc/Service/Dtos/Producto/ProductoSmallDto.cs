using ApiMvc.Models.Cores.Model;

namespace ApiMvc.Models
{
    public class ProductoSmallDto : CoreModel
    {
        public string Nombre { get; set; } = string.Empty;

        public static implicit operator ProductoSmallDto?(List<ProductoSmallDto>? v)
        {
            throw new NotImplementedException();
        }
    }
}
