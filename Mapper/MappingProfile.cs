using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo de Turno a TurnoDTO
        CreateMap<Turno, TurnoDTO>()
            .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente.Nombre))
            .ForMember(dest => dest.DoctorNombre, opt => opt.MapFrom(src => src.Doctor.Nombre));

        // Mapeo de TurnoDTO a Turno
        CreateMap<TurnoDTO, Turno>();
    }
}