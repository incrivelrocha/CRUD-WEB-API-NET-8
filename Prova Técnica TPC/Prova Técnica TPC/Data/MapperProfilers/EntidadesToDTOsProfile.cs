using AutoMapper;
using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Models.Entities;

namespace ProvaTecnicaTPC.Data.MapperProfilers
{
    public class EntidadesToDTOsProfile : Profile
    {
        public EntidadesToDTOsProfile()
        {
            CreateMap<StatusEntity, StatusDTO>().ReverseMap();

            CreateMap<TarefasEntity, TarefasDTO>().ReverseMap();
            CreateMap<TarefasEntity, TarefasListDTO>().ReverseMap();
            CreateMap<TarefasDTO, TarefasListDTO>().ReverseMap();

            CreateMap<UsuariosEntity, UsuarioDTO>().ReverseMap();
            CreateMap<UsuariosEntity, UsuariosListDTO>().ReverseMap();

        }
    }
}
