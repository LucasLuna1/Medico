using AutoMapper;
using TurneroMedico.DTOs;
using TurneroMedico.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Turno, TurnoDTO>()
            .ForMember(dest => dest.PacienteId, opt => opt.MapFrom(src => src.PacienteId))
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
            .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => $"{src.Paciente.Nombre}"))
            .ForMember(dest => dest.DoctorNombre, opt => opt.MapFrom(src => src.Doctor.Nombre))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.FechaHora.Date))
            .ForMember(dest => dest.Hora, opt => opt.MapFrom(src => src.FechaHora.TimeOfDay));

        CreateMap<TurnoDTO, Turno>()
            .ForMember(dest => dest.PacienteId, opt => opt.MapFrom(src => src.PacienteId))
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
            .ForMember(dest => dest.FechaHora, opt => opt.MapFrom(src => src.Fecha.Add(src.Hora)));
    }
}
