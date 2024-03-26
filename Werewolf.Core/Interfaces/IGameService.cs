using System.Collections;
using Werewolf.Core.Models.DataTransferObjects;
using Werewolf.Core.Models.Entities;

namespace Werewolf.Core.Interfaces;

public interface IGameService
{
    public Task<IEnumerable<Villager>> StartGameAsync(IList<PlayerDto> players);
}