using Werewolf.Core.Models;
using Werewolf.Core.Models.DataTransferObjects;
using Werewolf.Core.Models.Entities;

namespace Werewolf.Core.Interfaces;

public interface IRoleAssignmentService
{
    public IEnumerable<Villager> AssignRoles(IEnumerable<PlayerDto> players);
}