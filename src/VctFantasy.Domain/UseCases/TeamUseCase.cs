using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class TeamUseCase
    {
        private readonly VctFantasyContext _context;
        public TeamUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string RegisterTeam(TeamDto teamDto, string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                var team = new Team
                {
                    Name = teamDto.Name,
                    PathLogoTeam = teamDto.PathLogoTeam
                };

                team.UserID = user.Id;

                _context.Teams.Add(team);
                _context.SaveChanges();

                return "Time registrado com sucesso!";

            }
            catch (SqlException ex)
            {

                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
