namespace ApiMvc.Service.Cores.Services
{
    public interface ICrudService<TDto, TSaveDto, TSmallDto, ID>:
        IQueryService<TDto, TSmallDto, ID>,
        ISaveService<TDto, TSaveDto, TSmallDto, ID>,
        IDisableService<TSmallDto, ID>
    {
    }
}
