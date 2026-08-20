using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.Services;

namespace VctFantasy.Domain.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly VctFantasyContext _context;
        private readonly IPasswordHasherService _hasherService;
        public UserUseCase(VctFantasyContext context, IPasswordHasherService passwordHasher)
        {
            _context = context;
            _hasherService = passwordHasher;
        }

        public string GetUserRole(int userId)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == userId);

            return user.Role.Name;
        }

        public string Register(UserDto userDto)
        {
            try
            {

                var salt = _hasherService.GenerateSalt();
                var passwordHash = _hasherService.GenerateHash(userDto.Password, salt);

                var user = new User
                {
                    Email = userDto.Email,
                    Nickname = userDto.Nickname,
                };

                user.PasswordHash = passwordHash;
                user.PasswordSalt = salt;

                _context.Users.Add(user);
                _context.SaveChanges();

                return "User registered successfully";
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }

        }
    }
}
