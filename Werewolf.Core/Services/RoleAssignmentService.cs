using Werewolf.Core.Extensions;
using Werewolf.Core.Interfaces;
using Werewolf.Core.Models;
using Werewolf.Core.Models.DataTransferObjects;
using Werewolf.Core.Models.Entities;

namespace Werewolf.Core.Services;

public class RoleAssignmentService(IRandomNumberGenerator randomNumberGenerator) : IRoleAssignmentService
{
    public IEnumerable<Villager> AssignRoles(IList<PlayerDto> players, GameConfiguration gameConfiguration)
    {
        int werewolfCount = gameConfiguration.Werewolves;
        IList<Villager> newPlayers = new List<Villager>();

        foreach (var player in players)
        {
            if (werewolfCount > 0)
            {
                newPlayers.Add(new Villager
                {
                    Id = player.Id,
                    Character = Character.Werewolf
                });
                werewolfCount--;
            }
            else
            {
                newPlayers.Add(new Villager
                {
                    Id = player.Id,
                    Character = Character.Villager
                });
            }
        }

        return newPlayers.Shuffle();
    }
}