using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.ToDo;
using Authentication_JWT_RBAC.Domain.DTOs.User;
using AutoMapper;

namespace Authentication_JWT_RBAC.Infrastructure
{
    public class MappingProfile: Profile {
        public MappingProfile() {
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<Todo, TodoDTO>();
            CreateMap<Todo, UpdateTodoDTO>();
            CreateMap<CreateTodoDTO, Todo>();
            CreateMap<UpdateTodoDTO, Todo>();
        }
    }
}
