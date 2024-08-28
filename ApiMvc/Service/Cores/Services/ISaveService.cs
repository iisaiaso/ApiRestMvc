namespace ApiMvc.Service.Cores.Services
{
    public interface ISaveService<TDto,TSaveDto,TSmallDto, ID>
    {
        Task<TDto> CreateAsync(TSaveDto saveDto);
        Task<TSmallDto> EditAsync(ID id, TSaveDto saveDto);
    }
}
