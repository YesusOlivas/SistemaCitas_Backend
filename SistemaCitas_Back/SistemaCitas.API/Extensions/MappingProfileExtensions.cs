using AutoMapper;
using SistemaCitas.API.Models;
using SistemaCitas.Entities.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaCitas.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<Citas, CitasViewModel>().ReverseMap();
        }
    }
}
