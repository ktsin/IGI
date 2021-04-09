using AutoMapper;
using DAL.Entities;
using System;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public DateTime Born { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string PhotoPath { get; set; }

        public string Deliverydate { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public static readonly MapperConfiguration mapConfig = new(e => { e.CreateMap<DAL.Entities.User, UserDTO>(); e.CreateMap<UserDTO, User>(); });
    }
}
