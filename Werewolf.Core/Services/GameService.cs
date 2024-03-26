using Werewolf.Core.Interfaces;
using Werewolf.Core.Models.DataTransferObjects;
using Werewolf.Core.Models.Entities;

namespace Werewolf.Core.Services;

public class GameService(IRoleAssignmentService roleAssignmentService) : IGameService
{
    public Task<IEnumerable<Villager>> StartGameAsync(IList<PlayerDto> players)
    {
        var roles = roleAssignmentService.AssignRoles(players);
        return Task.FromResult(roles);
    }
}