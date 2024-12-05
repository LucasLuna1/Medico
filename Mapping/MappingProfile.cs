using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;

namespace TiendaAlmacenMVC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Turno, TurnoDTO>().ReverseMap();
        }
    }
}
