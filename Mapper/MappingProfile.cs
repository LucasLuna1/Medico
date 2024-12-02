using AutoMapper;
using TurneroMedico.Models;
using TurneroMedico.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Paciente, PacienteDto>();
        CreateMap<Doctor, DoctorDto>();
        CreateMap<Turno, TurnoDto>();
    }
}
