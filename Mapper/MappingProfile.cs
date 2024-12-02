using AutoMapper;
using TurneroMedico.Models;
using TurneroMedico.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Turno, TurnoDTO>()
            .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente.Nombre))
            .ForMember(dest => dest.DoctorNombre, opt => opt.MapFrom(src => src.Doctor.Especialidad));
    }
}
