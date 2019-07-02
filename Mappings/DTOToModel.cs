using AutoMapper;
using LojaDiscosAPI.DTO;
using LojaDiscosAPI.Models;

namespace LojaDiscosAPI.Mappings
{
    public class DTOToModel : Profile
    {
        public DTOToModel()
        {
            CreateMap<NewVendaDTO, Venda>();
         }
    }
}
