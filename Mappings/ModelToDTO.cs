using AutoMapper;
using LojaDiscosAPI.DTO;
using LojaDiscosAPI.Models;

namespace LojaDiscosAPI.Mappings
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO()
        {
            CreateMap<Venda, NewVendaDTO>();
        }
    }
}
