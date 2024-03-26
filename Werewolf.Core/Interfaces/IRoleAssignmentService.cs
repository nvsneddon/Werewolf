using Werewolf.Core.Models;
using Werewolf.Core.Models.DataTransferObjects;
using Werewolf.Core.Models.Entities;

namespace Werewolf.Core.Interfaces;

public interface IRoleAssignmentService
{
    public IEnumerable<Villager> AssignRoles(IList<PlayerDto> players);
    public IEnumerable<Villager> AssignRoles(IList<PlayerDto> players, GameConfiguration gameConfiguration);
}