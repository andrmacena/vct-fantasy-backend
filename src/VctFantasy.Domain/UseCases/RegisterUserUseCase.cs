using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.Services;

namespace VctFantasy.Domain.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly VctFantasyContext _context;
        private readonly PasswordHasherService _hasherService;
        public RegisterUserUseCase(VctFantasyContext context, PasswordHasherService passwordHasher)
        {
            _context = context;
            _hasherService = passwordHasher;
        }

        public string RegisterUser(User user)
        {
            try
            {

                var salt = _hasherService.GenerateSalt();
                var passwordHash = _hasherService.GenerateHash(user.PasswordHash, salt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = salt;

                _context.Users.Add(user);
                _context.SaveChanges();

                return "User registered successfully";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }

        }
    }
}
