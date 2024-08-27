using ApiMvc.Models.Cores.Model;

namespace ApiMvc.Models.Entity
{
    public class Fabricante : CoreModel
    {
        public string Nombre { get; set; } = string.Empty;

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
