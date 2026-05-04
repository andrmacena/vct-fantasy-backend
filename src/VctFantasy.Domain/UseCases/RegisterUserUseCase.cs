using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly VctFantasyContext _context;
        public RegisterUserUseCase(VctFantasyContext context) { _context = context; }

        public string RegisterUser(User user)
        {
            try
            {

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
