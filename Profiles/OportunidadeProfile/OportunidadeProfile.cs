using AutoMapper;
using Granto.Data.Dtos.Oportunidades;
using Granto.Models;


namespace Granto.Profiles.OportunidadeProfile
{
    public class OportunidadeProfile :Profile
    {

        public OportunidadeProfile()
        {
            CreateMap<CreateOportunidadeDto, Oportunidade>();
            //CreateMap<UpdateUserDto, User>();
            //CreateMap<User, ReadUserDto>();
        }
    }
}
