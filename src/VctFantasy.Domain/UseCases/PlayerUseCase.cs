using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class PlayerUseCase
    {
        private readonly VctFantasyContext _context;
        public PlayerUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string RegisterPlayer(List<PlayerDto> players)
        {
            try
            {
                foreach (var player in players)
                {
                    var playerEntity = new Player
                    {
                        Nickname = player.Nickname,
                        OrganizationId = player.OrganizationId,
                        PathProfile = player.PathProfile,
                    };
                    _context.Players.Add(playerEntity);
                }

                _context.SaveChanges();

                return "Player registered successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
