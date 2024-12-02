using AutoMapper;
using TurneroMedico.Models;
using TurneroMedico.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Turno, TurnoDTO>()
            .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente != null ? src.Paciente.Nombre : "No asignado"))
            .ForMember(dest => dest.DoctorNombre, opt => opt.MapFrom(src => src.Doctor != null ? src.Doctor.Nombre : "No asignado"));
    }
}

