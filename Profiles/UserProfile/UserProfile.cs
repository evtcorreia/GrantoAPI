using AutoMapper;
using Granto.Data.Dtos.User;
using Granto.Models;


namespace Granto.Profiles.UserProfile
{
    public class UserProfile :Profile
    {

        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}
